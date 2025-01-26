
using AutoMapper;
using EV.Chargers.Application.Business.Stations.Query;

namespace EV.Chargers.WebApi.EndPoints.Stations.Query
{
    public class GetStationsMapper : Profile
    {
        public GetStationsMapper()
        {
            CreateMap<GetStationsEndPointRequest, GetStationsHandlerInput>()
                .ConstructUsing(src => new GetStationsHandlerInput(src.CorrelationId()));
            CreateMap<GetStationsHandlerOutput, GetStationsEndPointResponse>()
               .ConstructUsing(src => new GetStationsEndPointResponse(src.CorrelationId()));
        }

    }
}
