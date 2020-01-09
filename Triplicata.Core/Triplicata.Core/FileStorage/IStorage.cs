using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Triplicata.Core.FileStorage
{
    public interface IStorage
    {
        IStorageSettings StorageSettings { get; }
        bool CheckIsAccessible();
        void ApplyKeys(IStorageKeys keys);
        Task UploadAsync(Stream stream, string remoteFileName);
        Task UploadAsync(Stream stream, string remoteFileName, TransferredPartsInfo parts);
        Task UploadAsync(string localFileName, string remoteFileName);
        Task UploadAsync(string localFileName, string remoteFileName, TransferredPartsInfo parts);
        Task DownloadAsync(string remoteFileName, string localFileName);
        Task DownloadAsync(string remoteFileName, string localFileName, TransferredPartsInfo parts);
        Task CreateFolderAsync(string folderName);
        Task DeleteFolderAsync(string folderName);
        Task DeleteFileAsync(string fileName);
        Task DeleteFilesAsync(string key);
        void CopyObject(string sourceBucket, string sourceKey, string destinationBucket, string destinationKey);
        bool IsObjectExists(string sourceBucket, string sourceKey);
        IEnumerable<StorageItem> FindFiles(string searchPattern = null, int filesLimit = 100);

        event EventHandler<TransferProgressArgs> TransferProgress;
        event EventHandler<TransferPartArgs> PartTransferred;
    }
}
