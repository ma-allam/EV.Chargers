
using AutoMapper;
using EV.Chargers.Application.Business.Clients.Command;

namespace EV.Chargers.WebApi.EndPoints.Client.Command
{
    public class AddNewClientMapper : Profile
    {
        public AddNewClientMapper()
        {
            CreateMap<AddNewClientEndPointRequest, AddNewClientHandlerInput>()
                .ConstructUsing(src => new AddNewClientHandlerInput(src.CorrelationId()));
            CreateMap<AddNewClientHandlerOutput, AddNewClientEndPointResponse>()
               .ConstructUsing(src => new AddNewClientEndPointResponse(src.CorrelationId()));
        }

    }
}
