
using AutoMapper;
using EV.Chargers.Application.Business.Chargers.Command;

namespace EV.Chargers.WebApi.EndPoints.Chargers.Command
{
    public class AddNewChargerMapper : Profile
    {
        public AddNewChargerMapper()
        {
            CreateMap<AddNewChargerEndPointRequest, AddNewChargerHandlerInput>()
                .ConstructUsing(src => new AddNewChargerHandlerInput(src.CorrelationId()));
            CreateMap<AddNewChargerHandlerOutput, AddNewChargerEndPointResponse>()
               .ConstructUsing(src => new AddNewChargerEndPointResponse(src.CorrelationId()));
        }

    }
}
