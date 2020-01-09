using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triplicata.Core
{
    public interface IInitializer
    {
        Task InitializeAsync();
    }
}
