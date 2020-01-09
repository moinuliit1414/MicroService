using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triplicata.Core.FileStorage
{
    public interface IStorageSettings
    {
        string RootLocation { get; set; }
        string StorageRelativePath { get; set; }
    }
}
