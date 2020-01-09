using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Triplicata.Core.Types;

namespace Triplicata.Core.Database.Mongo
{
    public interface IMongoRepository<TEntity> : IRepository<TEntity> where TEntity : IIdentifiable
    {
    }
}
