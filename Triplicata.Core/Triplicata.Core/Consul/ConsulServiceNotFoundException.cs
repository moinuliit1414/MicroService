using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Triplicata.Core.Types;

namespace Triplicata.Core.Consul
{
    public class ConsulServiceNotFoundException: TriplicataException
    {
        public string ServiceName { get; set; }
        public ConsulServiceNotFoundException(string serviceName) : this(string.Empty, serviceName)
        {
        }
        public ConsulServiceNotFoundException(string message, string serviceName) : base(message)
        {
            ServiceName = serviceName;
        }
    }
}
