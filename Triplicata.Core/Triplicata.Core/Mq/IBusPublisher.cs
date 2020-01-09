using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Triplicata.Core.Messages;
using Triplicata.Core.Types;

namespace Triplicata.Core.Mq
{
    public interface IBusPublisher
    {
        Task SendAsync<TCommand>(TCommand command, ICorrelationContext context)
            where TCommand : ICommand;

        Task PublishAsync<TEvent>(TEvent @event, ICorrelationContext context)
            where TEvent : IEvent;
    }
}
