using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Triplicata.Core.FileStorage.FTP
{
    public class FTPStorage : IStorage
    {
        private FTPFileOptions _fTPFileOptions { get; set; }
        public FTPStorage(string credentials) {
            _fTPFileOptions= JsonConvert.DeserializeObject<FTPFileOptions>(credentials);
        }
        public IStorageSettings StorageSettings { get; private set; }

        public bool CheckIsAccessible()
        {
            return true;
        }

        public void ApplyKeys(IStorageKeys keys)
        {
            
        }

        public Task UploadAsync(string localFileName, string remoteFileName)
        {
            return Task.Factory.StartNew(() => {
                FtpWebRequest request = GetFtpClient(_fTPFileOptions.FTPServer + remoteFileName);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                using (Stream fileStream = File.OpenRead(localFileName))
                using (Stream ftpStream = request.GetRequestStream())
                {
                    fileStream.CopyTo(ftpStream);
                }
            });
        }

        public Task UploadAsync(string localFileName, string remoteFileName, string bucket)
        {
            return Task.Factory.StartNew(() => {
                FtpWebRequest request = GetFtpClient(_fTPFileOptions.FTPServer + bucket + remoteFileName);
                request.Method = WebRequestMethods.Ftp.UploadFile;
                using (Stream fileStream = File.OpenRead(localFileName))
                using (Stream ftpStream = request.GetRequestStream())
                {
                    fileStream.CopyTo(ftpStream);
                }
            });
        }

        public Task UploadAsync(Stream stream, string remoteFileName)
        {
            return Task.Factory.StartNew(() => { });
        }

        public Task UploadAsync(Stream stream, string remoteFileName, string bucket)
        {
            return Task.Factory.StartNew(() => { });
        }

        public Task DownloadAsync(string remoteFileName, string localFileName)
        {
            return Task<Stream>.Factory.StartNew(() => new MemoryStream());
        }

        public Task DownloadAsync(string remoteFileName, string localFileName, string bucket)
        {
            return Task<Stream>.Factory.StartNew(() => new MemoryStream());
        }

        public Task UploadAsync(string localFileName, string remoteFileName, TransferredPartsInfo parts)
        {
            return Task.Factory.StartNew(() => { });
        }

        public Task UploadAsync(string localFileName, string remoteFileName, TransferredPartsInfo parts, string bucket)
        {
            return Task.Factory.StartNew(() => { });
        }

        public Task UploadAsync(Stream stream, string remoteFileName, TransferredPartsInfo parts)
        {
            return Task.Factory.StartNew(() => { });
        }

        public Task UploadAsync(Stream stream, string remoteFileName, TransferredPartsInfo parts, string bucket)
        {
            return Task.Factory.StartNew(() => { });
        }

        public Task DownloadAsync(string remoteFileName, string localFileName, TransferredPartsInfo parts)
        {
            return Task<Stream>.Factory.StartNew(() => new MemoryStream());
        }

        public Task CreateFolderAsync(string folderName)
        {
            return Task.Factory.StartNew(() => {
                FtpWebRequest request = GetFtpClient(folderName);
                request.Method = WebRequestMethods.Ftp.MakeDirectory;
                using (var resp = (FtpWebResponse)request.GetResponse())
                {
                    Console.WriteLine(resp.StatusCode);
                }
            });
        }

        public Task DeleteFolderAsync(string folderName)
        {
            return Task.Factory.StartNew(() => {
                FtpWebRequest request = GetFtpClient(folderName);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                using (var resp = (FtpWebResponse)request.GetResponse())
                {
                    Console.WriteLine(resp.StatusCode);
                }
            });
        }

        public Task DeleteFileAsync(string fileName)
        {
            return Task.Factory.StartNew(() => {
                FtpWebRequest request = GetFtpClient(fileName);
                request.Method = WebRequestMethods.Ftp.DeleteFile;
                using (var resp = (FtpWebResponse)request.GetResponse())
                {
                    Console.WriteLine(resp.StatusCode);
                }
            });
        }

        public void CopyObject(string sourceBucket, string sourceKey, string destinationBucket, string destinationKey)
        {
        }

        public bool IsObjectExists(string sourceBucket, string sourceKey)
        {
            FtpWebRequest request =GetFtpClient(_fTPFileOptions.FTPServer+sourceBucket+sourceKey);
            request.Method = WebRequestMethods.Ftp.GetFileSize;

            try
            {
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                return true;
            }
            catch (WebException ex)
            {
                FtpWebResponse response = (FtpWebResponse)ex.Response;
                if (response.StatusCode ==
                    FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    return false;
                }
                return false;
            }
        }

        public Task DownloadAsync(string remoteFileName, string localFileName, TransferredPartsInfo parts, string bucket)
        {
            return Task<Stream>.Factory.StartNew(() => new MemoryStream());
        }

        public Task DeleteFilesAsync(string key)
        {
            return Task.Factory.StartNew(() => { });
        }

        public IEnumerable<StorageItem> FindFiles(string searchPattern = null, int filesLimit = 100)
        {
            throw new NotImplementedException("FindFiles");
        }

        FtpWebRequest GetFtpClient(String url) {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(url);
            request.Credentials = new NetworkCredential(_fTPFileOptions.FTPUserID, _fTPFileOptions.FTPPassword);
            return request;
        }

        public event EventHandler<TransferProgressArgs> TransferProgress;
        public event EventHandler<TransferPartArgs> PartTransferred;
    }
}
