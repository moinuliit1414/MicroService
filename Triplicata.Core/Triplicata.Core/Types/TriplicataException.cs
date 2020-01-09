using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triplicata.Core.Types
{
    public class TriplicataException : Exception
    {
        public string Code { get; }

        public TriplicataException()
        {
        }

        public TriplicataException(string code)
        {
            Code = code;
        }

        public TriplicataException(string message, params object[] args)
            : this(string.Empty, message, args)
        {
        }

        public TriplicataException(string code, string message, params object[] args)
            : this(null, code, message, args)
        {
        }

        public TriplicataException(Exception innerException, string message, params object[] args)
            : this(innerException, string.Empty, message, args)
        {
        }

        public TriplicataException(Exception innerException, string code, string message, params object[] args)
            : base(string.Format(message, args), innerException)
        {
            Code = code;
        }
    }

}
