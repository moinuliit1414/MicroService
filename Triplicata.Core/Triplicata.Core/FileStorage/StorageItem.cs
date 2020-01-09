using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triplicata.Core.FileStorage
{
    public class StorageItem
    {
        public string Url { get; set; }
        public DateTime LastModified { get; set; }
        public long Size { get; set; }
    }
}
