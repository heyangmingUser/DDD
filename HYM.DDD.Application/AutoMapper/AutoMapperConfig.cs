using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace HYM.Application.AutoMapper
{
    /// <summary>
    /// 静态全局AutoMapper配置文件
    /// </summary>
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings() 
        {
            return new MapperConfiguration(config=> 
            {
                config.AddProfile<DomainToViewModelProfile>();
                config.AddProfile<ViewModelToDomainProfile>();
            });
        }
    }
}
