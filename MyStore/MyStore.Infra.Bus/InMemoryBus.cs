using MediatR;
using MyStore.Domain.Core.Bus;
using MyStore.Domain.Core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStore.Infra.Bus
{
    public class InMemoryBus : IMediatorHandler
    {
        private readonly IMediator _mediator;
        public InMemoryBus(IMediator mediator)
        {
            _mediator = mediator;
        }

        public Task SendCommand<T>(T command) where T:Command
        {
            return _mediator.Send(command);
        }
    }
}
