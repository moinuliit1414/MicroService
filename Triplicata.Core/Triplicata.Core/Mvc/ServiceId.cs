using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triplicata.Core.Mvc
{
    public class ServiceId : IServiceId
    {
        private static readonly string UniqueId = $"{Guid.NewGuid():N}";

        public string Id => UniqueId;
    }
}
