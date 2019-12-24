using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCloudStore
{
    class FileServer : IFileServer
    {
        public string Direktorijum { get; set; }
        public void DeleteFile(string virtualPath)
        {
            string filePath = Path.Combine(Direktorijum, virtualPath);

            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }//odgovor treba
        }

        public byte[] GetFile(string virtualPath)
        {
            string filePath = Path.Combine(Direktorijum, virtualPath);

            if (!File.Exists(filePath))
                throw new FileNotFoundException("File was not found",
                                                Path.GetFileName(filePath));

            byte[] fajl = File.ReadAllBytes(filePath);

            return fajl;
        }

        public StorageFileInfo[] List(string virtualPath)
        {
            string basePath = Direktorijum;

            if (!string.IsNullOrEmpty(virtualPath))
                basePath = Path.Combine(Direktorijum, virtualPath);

            DirectoryInfo dirInfo = new DirectoryInfo(basePath);
            FileInfo[] files = dirInfo.GetFiles("*.*", SearchOption.AllDirectories);

            return (from f in files
                    select new StorageFileInfo()
                    {
                        Size = f.Length,
                        VirtualPath = f.FullName.Substring(
                          f.FullName.IndexOf(Direktorijum) +
                          Direktorijum.Length + 1)
                    }).ToArray();
        }

        public void PutFile(FileUploadMessage msg)
        {
            string filePath = Path.Combine(Direktorijum, msg.VirtualPath);
            string dir = Path.GetDirectoryName(filePath);

            if (!Directory.Exists(dir))
                Directory.CreateDirectory(dir);

            File.WriteAllBytes(filePath, msg.DataStream);

        }
    }
}
