using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triplicata.Core.FileStorage
{
    public class TransferProgressArgs : EventArgs
    {
        public TransferProgressArgs() { }
        public string RemoteFileName { get; set; }
        public string LocalFileName { get; set; }
        public int Percent { get; set; }
        public long TotalBytes { get; set; }
        public long Transferred { get; set; }
    }
}
