using AutoMapper;
using HYM.Application.ViewModels;
using HYM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HYM.Application.AutoMapper
{
    /// <summary>
    /// 视图映射领域实体
    /// </summary>
    public class ViewModelToDomainProfile : Profile
    {
        public ViewModelToDomainProfile()
        {
            CreateMap<StudentViewModel, Student>()
                .ForMember(r => r.Address.Province, s => s.MapFrom(r => r.Province))
                .ForMember(r => r.Address.City, s => s.MapFrom(r => r.City))
                .ForMember(r => r.Address.County, s => s.MapFrom(r => r.County))
                .ForMember(r => r.Address.Street, s => s.MapFrom(r => r.Street));
            CreateMap<OrderViewModel, OrderItem>();
            CreateMap<OrderItemViewModel, OrderItem>();
        }
    }
}
