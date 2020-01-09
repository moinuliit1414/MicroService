using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Triplicata.Core.FileStorage
{
    public interface IStorageManager
    {
        IStorage CreateStorage(string rootLocation);
        IStorage CreateStorage(string name, string rootLocation);
        IStorage CreateStorage(string rootLocation, IStorageKeys keys);
        IStorage CreateStorage(string name, string rootLocation, IStorageKeys keys);
    }
}
