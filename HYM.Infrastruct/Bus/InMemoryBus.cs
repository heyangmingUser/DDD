﻿using HYM.Domain.Core.Bus;
using HYM.Domain.Core.Commands;
using HYM.Domain.Core.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HYM.Infrastruct.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        // 事件仓储服务
        private readonly IEventStoreService _eventStoreService;
        public InMemoryBus(IMediator mediator, IEventStoreService eventStoreService) 
        {
            _mediator = mediator;
            _eventStoreService = eventStoreService;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="command"></param>
        /// <returns></returns>
        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }

        /// <summary>
        /// 引发事件的实现方法
        /// </summary>
        /// <typeparam name="T">泛型 继承 Event：INotification</typeparam>
        /// <param name="event">事件模型，比如StudentRegisteredEvent</param>
        /// <returns></returns>
        public Task RaiseEvent<T>(T @event) where T : Event
        {
            // 除了领域通知以外的事件都保存下来
            if (!@event.MessageType.Equals("DomainNotification"))
                _eventStoreService?.Save(@event);
            // MediatR中介者模式中的第二种方法，发布/订阅模式
            return _mediator.Publish(@event);
        }
    }
}
