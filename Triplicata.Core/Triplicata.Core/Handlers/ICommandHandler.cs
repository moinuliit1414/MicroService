using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Triplicata.Core.Messages;
using Triplicata.Core.Types;

namespace Triplicata.Core.Handlers
{
    public interface ICommandHandler<in TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command, ICorrelationContext context);
    }
}
