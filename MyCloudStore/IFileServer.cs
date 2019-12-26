using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MyCloudStore
{
    [ServiceContract]
    interface IFileServer
    {
        [OperationContract]
        byte[] GetFile(string virtualPath, string username, string password);//Stream?
        [OperationContract]
        void PutFile(FileUpload file, string username, string password);

        [OperationContract]
        void DeleteFile(string virtualPath, string username, string password);

        [OperationContract]
        StorageFileInfo[] List( string username, string password);

    }
}
