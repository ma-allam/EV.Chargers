
using AutoMapper;
using EV.Chargers.Application.Business.Stations.Command;

namespace EV.Chargers.WebApi.EndPoints.Stations.Command
{
    public class AddNewStationMapper : Profile
    {
        public AddNewStationMapper()
        {
            CreateMap<AddNewStationEndPointRequest, AddNewStationHandlerInput>()
                .ConstructUsing(src => new AddNewStationHandlerInput(src.CorrelationId()));
            CreateMap<AddNewStationHandlerOutput, AddNewStationEndPointResponse>()
               .ConstructUsing(src => new AddNewStationEndPointResponse(src.CorrelationId()));
        }

    }
}
