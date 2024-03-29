﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triplicata.Core.Messages
{
    public class RejectedEvent : IRejectedEvent
    {
        public string Reason { get; }
        public string Code { get; }

        [JsonConstructor]
        public RejectedEvent(string reason, string code)
        {
            Reason = reason;
            Code = code;
        }

        public static IRejectedEvent For(string name)
            => new RejectedEvent($"There was an error when executing: " +
                                 $"{name}", $"{name}_error");
    }
}
