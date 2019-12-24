using System.IO;
using System.ServiceModel;

namespace MyCloudStore
{
    [MessageContract]
    public class FileUploadMessage
    {
        [MessageHeader(MustUnderstand = true)]
        public string VirtualPath { get; set; }

        [MessageBodyMember(Order = 1)]
        public byte[] DataStream { get; set; }
    }
}