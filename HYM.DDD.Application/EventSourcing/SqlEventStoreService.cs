using HYM.Domain.Core.Events;
using HYM.Infrastruct.Repository.EventStore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HYM.Application.EventSourcing
{
    public class SqlEventStoreService : IEventStoreService
    {
        // 注入我们的仓储接口
        private readonly IEventStoreRepository _eventStoreRepository;

        public SqlEventStoreService(IEventStoreRepository eventStoreRepository)
        {
            _eventStoreRepository = eventStoreRepository;
        }
        public void Save<T>(T theEvent) where T : Event
        {
            // 对事件模型序列化
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new StoredEvent(
                theEvent,
                serializedData,
                "Laozhang");

            _eventStoreRepository.Store(storedEvent);
        }
    }
}
