
using AutoMapper;
using EV.Chargers.Application.Business.Clients.Command;

namespace EV.Chargers.WebApi.EndPoints.Client.Command
{
    public class UpdateClientMapper : Profile
    {
        public UpdateClientMapper()
        {
            CreateMap<UpdateClientEndPointRequest, UpdateClientHandlerInput>()
                .ConstructUsing(src => new UpdateClientHandlerInput(src.CorrelationId()));
            CreateMap<UpdateClientHandlerOutput, UpdateClientEndPointResponse>()
               .ConstructUsing(src => new UpdateClientEndPointResponse(src.CorrelationId()));
        }

    }
}
