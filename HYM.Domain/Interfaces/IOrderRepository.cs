using HYM.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HYM.Domain.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        /// <summary>
        /// order独有的接口
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Order GetByName(string name);
    }
}
