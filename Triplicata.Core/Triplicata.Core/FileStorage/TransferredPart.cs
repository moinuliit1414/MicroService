using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triplicata.Core.FileStorage
{
    [Serializable]
    public class TransferredPart
    {
        public TransferredPart() { }
        public TransferredPart(int partNumber, long offset, string eTag)
        {
            PartNumber = partNumber;
            Offset = offset;
            ETag = eTag;
        }

        public long Offset { get; set; }
        public int PartNumber { get; set; }
        public string ETag { get; set; }
    }
}
