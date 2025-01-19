

using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.UploadDownloadAttach
{
    public class UploadAttachmentEndPointResponse : BaseResponse
    {
        public UploadAttachmentEndPointResponse() { }
        public UploadAttachmentEndPointResponse(Guid correlationId) : base(correlationId) { }
        public string Message { get; set; }

    }
}
