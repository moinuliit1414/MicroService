using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triplicata.Core.FileStorage
{
    [Serializable]
    public class TransferredPartsInfo
    {
        public string StorageType { get; set; }
        public string Token { get; set; }

        public long FileLength { get; set; }
        public int PartSize { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays")]
        public TransferredPart[] TransferredParts { get; set; }
    }
}
