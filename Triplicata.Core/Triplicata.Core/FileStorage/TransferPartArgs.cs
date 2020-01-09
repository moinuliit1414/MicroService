using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triplicata.Core.FileStorage
{
    public class TransferPartArgs : EventArgs
    {
        public string RemoteFileName { get; set; }
        public string LocalFileName { get; set; }
        public TransferredPartsInfo Data { get; set; }
    }
}
