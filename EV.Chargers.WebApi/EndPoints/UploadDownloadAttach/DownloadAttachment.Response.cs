

using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.UploadDownloadAttach
{
    public class DownloadAttachmentEndPointResponse : BaseResponse
    {
        public DownloadAttachmentEndPointResponse() { }
        public DownloadAttachmentEndPointResponse(Guid correlationId) : base(correlationId) { }
        public byte[] AttachmentFile { get; set; }
        public string FileName { get; set; }
    }
}
