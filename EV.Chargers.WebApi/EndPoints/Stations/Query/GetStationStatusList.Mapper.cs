
using AutoMapper;
using EV.Chargers.Application.Business.Stations.Query;

namespace EV.Chargers.WebApi.EndPoints.Stations.Query
{
    public class GetStationStatusListMapper : Profile
    {
        public GetStationStatusListMapper()
        {
            CreateMap<GetStationStatusListEndPointRequest, GetStationStatusListHandlerInput>()
                .ConstructUsing(src => new GetStationStatusListHandlerInput(src.CorrelationId()));
            CreateMap<GetStationStatusListHandlerOutput, GetStationStatusListEndPointResponse>()
               .ConstructUsing(src => new GetStationStatusListEndPointResponse(src.CorrelationId()));
        }

    }
}
