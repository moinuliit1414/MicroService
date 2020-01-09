using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Triplicata.Core.Types;

namespace Triplicata.Core.Database.MsSql
{
    public interface IMsSqlRepository<TEntity> : IRepository<TEntity> where TEntity : IIdentifiable
    {
        IEnumerable<TData> Execute<TData>(IDbCommand command) where TData : class;
    }
}
