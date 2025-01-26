
using AutoMapper;
using EV.Chargers.Application.Business.Chargers.Query;

namespace EV.Chargers.WebApi.EndPoints.Chargers.Query
{
    public class GetChargerTypeListMapper : Profile
    {
        public GetChargerTypeListMapper()
        {
            CreateMap<GetChargerTypeListEndPointRequest, GetChargerTypeListHandlerInput>()
                .ConstructUsing(src => new GetChargerTypeListHandlerInput(src.CorrelationId()));
            CreateMap<GetChargerTypeListHandlerOutput, GetChargerTypeListEndPointResponse>()
               .ConstructUsing(src => new GetChargerTypeListEndPointResponse(src.CorrelationId()));
        }

    }
}
