using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triplicata.Core.FileStorage
{
    public enum StorageType
    {
        AWS,
        FTP,
        HTTP,
        AZURE
    }

    public static class StorageEnumExtensions
    {
        public static string ToIoCString(this StorageType storage)
        {
            return storage.ToString().ToUpperInvariant();
        }
    }
}
