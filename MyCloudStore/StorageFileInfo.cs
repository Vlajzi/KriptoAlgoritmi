using System.Runtime.Serialization;

namespace MyCloudStore
{
    [DataContract]
    public class StorageFileInfo
    {
        [DataMember]
        public long Size { get;  set; }
        [DataMember]
        public string VirtualPath { get; set; }
        [DataMember]
        public string hesh { get; set; }

        public override string ToString()
        {
            return string.Format(VirtualPath + "\t\t" + Size + "\t\t");
        }

    }
}