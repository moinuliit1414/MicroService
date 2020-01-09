using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triplicata.Core.Database.Mongo
{
    public interface IMongoDbSeeder
    {
        Task SeedAsync();
    }
}
