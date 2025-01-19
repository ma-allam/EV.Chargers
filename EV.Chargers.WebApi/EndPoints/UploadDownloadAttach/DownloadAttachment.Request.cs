using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.UploadDownloadAttach
{
    public class DownloadAttachmentEndPointRequest : BaseRequest
    {
        public const string Route = "/api/UploadDownloadAttach/v{version:apiVersion}/DownloadAttachment/";

        public Guid AttachmentId { get; set; }

    }
}
