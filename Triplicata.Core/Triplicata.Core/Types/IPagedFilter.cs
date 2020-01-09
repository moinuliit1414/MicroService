using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triplicata.Core.Types
{
    public interface IPagedFilter<TResult, in TQuery> where TQuery : IQuery
    {
        PagedResult<TResult> Filter(IEnumerable<TResult> values, TQuery query);
    }
}
