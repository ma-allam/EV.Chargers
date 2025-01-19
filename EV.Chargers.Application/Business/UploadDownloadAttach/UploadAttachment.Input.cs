using EV.Chargers.Application.Business.ContractManagement.Command;
using MediatR;
using Microsoft.AspNetCore.Http;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.UploadDownloadAttach
{
    public class UploadAttachmentHandlerInput : BaseRequest, IRequest<UploadAttachmentHandlerOutput>
    {
        public UploadAttachmentHandlerInput() { }
        public UploadAttachmentHandlerInput(Guid correlationId) : base(correlationId) { }
        public int ContractId { get; set; }
        //public List<AttachmentInput> Attachments { get; set; }
        public string Tags { get; set; }
        public string? Notes { get; set; }
        public List<IFormFile> Attachments { get; set; }


    }
}
