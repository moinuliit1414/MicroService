using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triplicata.Core.Types
{
    //Marker
    public interface IQuery
    {
    }

    public interface IQuery<T> : IQuery
    {
    }
}
