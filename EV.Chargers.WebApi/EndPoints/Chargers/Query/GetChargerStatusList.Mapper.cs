
using AutoMapper;
using EV.Chargers.Application.Business.Chargers.Query;

namespace EV.Chargers.WebApi.EndPoints.Chargers.Query
{
    public class GetChargerStatusListMapper : Profile
    {
        public GetChargerStatusListMapper()
        {
            CreateMap<GetChargerStatusListEndPointRequest, GetChargerStatusListHandlerInput>()
                .ConstructUsing(src => new GetChargerStatusListHandlerInput(src.CorrelationId()));
            CreateMap<GetChargerStatusListHandlerOutput, GetChargerStatusListEndPointResponse>()
               .ConstructUsing(src => new GetChargerStatusListEndPointResponse(src.CorrelationId()));
        }

    }
}
