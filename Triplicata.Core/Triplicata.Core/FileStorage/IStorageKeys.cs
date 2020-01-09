using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triplicata.Core.FileStorage
{
    public interface IStorageKeys
    {
        string StorageRelativePath { get; set; }
    }
}
