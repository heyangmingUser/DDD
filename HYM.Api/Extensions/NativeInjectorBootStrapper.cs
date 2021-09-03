using HYM.Application.EventSourcing;
using HYM.Application.Services;
using HYM.Domain.CommandHandlers;
using HYM.Domain.Commands;
using HYM.Domain.Core.Bus;
using HYM.Domain.Core.Events;
using HYM.Domain.Core.Notifications;
using HYM.Domain.EventHandlers;
using HYM.Domain.Events;
using HYM.Domain.Interfaces;
using HYM.Infrastruct;
using HYM.Infrastruct.Bus;
using HYM.Infrastruct.Context;
using HYM.Infrastruct.Repository;
using HYM.Infrastruct.Repository.EventStore;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HYM.Api.Extensions
{
    /// <summary>
    /// 注册服务
    /// </summary>
    public  class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services) 
        {
            //应用层
            services.AddScoped<IStudentAppService, StudentAppService>();

            // 命令总线Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            //基础设施层-数据
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<StudyContext>();
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IRequestHandler<RegisterStudentCommand, Unit>, StudentCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateStudentCommand, Unit>, StudentCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveStudentCommand, Unit>, StudentCommandHandler>();
            services.AddScoped<INotificationHandler<StudentRegisteredEvent>, StudentEventHandler>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();


            // 注入 基础设施层 - 事件溯源
            services.AddScoped<IEventStoreRepository, EventStoreSQLRepository>();
            services.AddScoped<IEventStoreService, SqlEventStoreService>();
            services.AddScoped<EventStoreSQLContext>();
        }
    }
}
