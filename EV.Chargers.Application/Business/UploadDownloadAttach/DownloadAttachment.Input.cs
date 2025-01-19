using MediatR;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.UploadDownloadAttach
{
    public class DownloadAttachmentHandlerInput : BaseRequest, IRequest<DownloadAttachmentHandlerOutput>
    {
        public DownloadAttachmentHandlerInput() { }
        public DownloadAttachmentHandlerInput(Guid correlationId) : base(correlationId) { }

        public Guid AttachmentId { get; set; }
    }
}
