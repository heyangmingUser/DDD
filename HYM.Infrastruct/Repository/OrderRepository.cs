using HYM.Domain.Interfaces;
using HYM.Domain.Models;
using HYM.Infrastruct.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HYM.Infrastruct.Repository
{
    /// <summary>
    /// 订单仓储,在这里操作对象是领域对象
    /// </summary>
    public class OrderRepository : Repository<Order>, IOrderRepository
    {

        public OrderRepository(StudyContext context) :base(context) { }

        public Order GetByName(string name)
        {
            return _db.Orders.FirstOrDefault(r => r.Name == name);
        }
    }
}
