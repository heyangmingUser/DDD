using HYM.Domain.Core.Events;
using HYM.Infrastruct.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace HYM.Infrastruct.Repository.EventStore
{
    public class EventStoreSQLRepository : IEventStoreRepository
    {

        // 注入事件存储数据库上下文
        private readonly EventStoreSQLContext _context;

        public EventStoreSQLRepository(EventStoreSQLContext context)
        {
            _context = context;
        }
        public IList<StoredEvent> All(Guid aggregateId)
        {
            return (from e in _context.StoredEvent where e.AggregateId == aggregateId select e).ToList();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void Store(StoredEvent theEvent)
        {
            _context.StoredEvent.Add(theEvent);
            _context.SaveChanges();
        }
    }
}
