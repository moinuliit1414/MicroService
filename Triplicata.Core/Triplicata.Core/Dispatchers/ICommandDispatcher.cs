using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Triplicata.Core.Messages;

namespace Triplicata.Core.Dispatchers
{
    public interface ICommandDispatcher
    {
        Task SendAsync<T>(T command) where T : ICommand;
    }
}
