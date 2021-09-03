using HYM.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HYM.Domain.EventHandlers
{
    public class StudentEventHandler : INotificationHandler<StudentRegisteredEvent>
    {
        public Task Handle(StudentRegisteredEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
