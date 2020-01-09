using RawRabbit.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triplicata.Core.Mq.RabbitMq
{
    public class RabbitMqOptions : RawRabbitConfiguration
    {
        public string Namespace { get; set; }
        public int Retries { get; set; }
        public int RetryInterval { get; set; }
    }
}
