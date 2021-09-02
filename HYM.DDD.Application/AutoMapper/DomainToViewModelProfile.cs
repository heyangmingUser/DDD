using AutoMapper;
using HYM.Application.ViewModels;
using HYM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HYM.Application.AutoMapper
{
    /// <summary>
    /// 实体映射视图模型
    /// </summary>
    public class DomainToViewModelProfile:Profile
    {
        public DomainToViewModelProfile()
        {
            CreateMap<Student, StudentViewModel>()
                .ForMember(r => r.County, d => d.MapFrom(s => s.Address.County))
                .ForMember(r => r.City, d => d.MapFrom(s => s.Address.City))
                .ForMember(r => r.Province, d => d.MapFrom(s => s.Address.Province))
                .ForMember(r => r.Street, d => d.MapFrom(s => s.Address.Street));
            CreateMap<Order, OrderViewModel>();
            CreateMap<OrderItem, OrderItemViewModel>();
        }
    }
}
