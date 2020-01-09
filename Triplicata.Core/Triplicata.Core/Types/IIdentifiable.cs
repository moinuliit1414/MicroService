using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triplicata.Core.Types
{
    public interface IIdentifiable
    {
        Guid Id { get; }
    }
}
