using System.Threading.Tasks;
using Autofac;
using Triplicata.Core.Handlers;
using Triplicata.Core.Messages;
using Triplicata.Core.Types;

namespace Triplicata.Core.Dispatchers
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private readonly IComponentContext _context;

        public CommandDispatcher(IComponentContext context)
        {
            _context = context;
        }

        public async Task SendAsync<T>(T command) where T : ICommand
            => await _context.Resolve<ICommandHandler<T>>().HandleAsync(command, CorrelationContext.Empty);
    }
}
