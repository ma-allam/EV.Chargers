
using AutoMapper;
using EV.Chargers.Application.Business.UploadDownloadAttach;

namespace EV.Chargers.WebApi.EndPoints.UploadDownloadAttach
{
    public class DownloadAttachmentMapper : Profile
    {
        public DownloadAttachmentMapper()
        {
            CreateMap<DownloadAttachmentEndPointRequest, DownloadAttachmentHandlerInput>()
                .ConstructUsing(src => new DownloadAttachmentHandlerInput(src.CorrelationId()));
            CreateMap<DownloadAttachmentHandlerOutput, DownloadAttachmentEndPointResponse>()
               .ConstructUsing(src => new DownloadAttachmentEndPointResponse(src.CorrelationId()));
        }

    }
}
