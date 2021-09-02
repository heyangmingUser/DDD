using HYM.Domain.Core.Bus;
using HYM.Domain.Core.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HYM.Infrastruct.Bus
{
    public sealed class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        public InMemoryBus(IMediator mediator) 
        {
            _mediator = mediator;
        }
        public Task SendCommand<T>(T command) where T : Command
        {
            return _mediator.Send(command);
        }
    }
}
