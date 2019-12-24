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
        byte[] GetFile(string virtualPath);//Stream?
        [OperationContract]
        void PutFile(FileUploadMessage msg);

        [OperationContract]
        void DeleteFile(string virtualPath);

        [OperationContract]
        StorageFileInfo[] List(string virtualPath);

    }
}
