using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triplicata.Core.Database.MsSql
{
    public class MsSqlOptions
    {
        public string ConnectionString { get; set; }
        public bool UsePool { get; set; }
    }
}
