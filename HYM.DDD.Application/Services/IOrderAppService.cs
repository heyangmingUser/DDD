using HYM.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace HYM.Application.Services
{
    public interface IOrderAppService:IDisposable
    {
        void Register(OrderViewModel OrderViewModel);
        IEnumerable<OrderViewModel> GetAll();
    }
}
