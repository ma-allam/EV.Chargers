using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.UploadDownloadAttach
{
    public class UploadAttachmentHandlerOutput : BaseResponse
    {
        public UploadAttachmentHandlerOutput() { }
        public UploadAttachmentHandlerOutput(Guid correlationId) : base(correlationId) { }
        public string Message { get; set; }
    }
}
