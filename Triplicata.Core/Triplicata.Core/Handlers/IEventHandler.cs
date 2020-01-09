using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Triplicata.Core.Messages;
using Triplicata.Core.Types;

namespace Triplicata.Core.Handlers
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task HandleAsync(TEvent @event, ICorrelationContext context);
    }
}
