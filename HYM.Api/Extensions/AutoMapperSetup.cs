using HYM.Application.AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HYM.Api.Extensions
{
    public static class AutoMapperSetup
    {

        public static void AddAutoMapperSetup(this IServiceCollection services) 
        {
            services.AddAutoMapper(typeof(AutoMapperConfig));
            AutoMapperConfig.RegisterMappings();
        }
    }
}
