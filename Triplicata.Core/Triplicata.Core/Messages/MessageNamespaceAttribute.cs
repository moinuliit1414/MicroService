using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triplicata.Core.Messages
{
    [AttributeUsage(AttributeTargets.Class)]
    public class MessageNamespaceAttribute : Attribute
    {
        public string Namespace { get; }

        public MessageNamespaceAttribute(string @namespace)
        {
            Namespace = @namespace?.ToLowerInvariant();
        }
    }
}
