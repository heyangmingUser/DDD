using HYM.Application.Services;
using HYM.Domain.Core.Bus;
using HYM.Domain.Interfaces;
using HYM.Infrastruct;
using HYM.Infrastruct.Bus;
using HYM.Infrastruct.Context;
using HYM.Infrastruct.Repository;
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

            //基础设施层-数据
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<StudyContext>();
            services.AddScoped<IMediatorHandler, InMemoryBus>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
