using HYM.Domain.Core.Bus;
using HYM.Domain.Core.Commands;
using HYM.Domain.Core.Notifications;
using HYM.Domain.Interfaces;
using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;

namespace HYM.Domain.CommandHandlers
{
    /// <summary>
    /// 领域命令处理程序
    /// 用来作为全部处理程序的基类，提供公共方法和接口数据
    /// </summary>
    public class CommandHandler
    {
        // 注入工作单元
        private readonly IUnitOfWork _uow;
        // 注入中介处理接口（目前用不到，在领域事件中用来发布事件）
        private readonly IMediatorHandler _bus;
        // 注入缓存，用来存储错误信息（目前是错误方法，以后用领域通知替换）
        private IMemoryCache _cache;
        public CommandHandler(IUnitOfWork uow, IMediatorHandler bus, IMemoryCache cache) 
        {
            _uow = uow;
            _bus = bus;
            _cache = cache;
        }

        protected void NotifyValidationErrors(Command message)
        {
            List<string> errorInfo = new List<string>();
            foreach (var error in message.ValidationResult.Errors)
            {
                //errorInfo.Add(error.ErrorMessage);
                _bus.RaiseEvent(new DomainNotification("", error.ErrorMessage));

            }
            //将错误信息收集
            //_cache.Set("ErrorData", errorInfo);

        }
        //工作单元提交
        //如果有错误，下一步会在这里添加领域通知
        public bool Commit()
        {
            if (_uow.Commit()) return true;

            return false;
        }
    }
}
