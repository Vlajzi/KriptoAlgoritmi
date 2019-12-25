using System.IO;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace MyCloudStore
{
    [DataContract]
    public class FileUpload
    {
        [DataMember]
        public StorageFileInfo info {get;set;}

        [DataMember]
        public byte[] Data { get; set; }

        [DataMember]
        public string Hesh { get; set; }
    }

}