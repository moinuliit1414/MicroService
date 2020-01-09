using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triplicata.Core.RestEase
{
    public class RestEaseServiceNotFoundException : Exception
    {
        public string ServiceName { get; set; }

        public RestEaseServiceNotFoundException(string serviceName) : this(string.Empty, serviceName)
        {
        }

        public RestEaseServiceNotFoundException(string message, string serviceName) : base(message)
        {
            ServiceName = serviceName;
        }
    }

}
