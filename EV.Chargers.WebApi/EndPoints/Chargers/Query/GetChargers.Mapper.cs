
using AutoMapper;
using EV.Chargers.Application.Business.Chargers.Query;

namespace EV.Chargers.WebApi.EndPoints.Chargers.Query
{
    public class GetChargersMapper : Profile
    {
        public GetChargersMapper()
        {
            CreateMap<GetChargersEndPointRequest, GetChargersHandlerInput>()
                .ConstructUsing(src => new GetChargersHandlerInput(src.CorrelationId()));
            CreateMap<GetChargersHandlerOutput, GetChargersEndPointResponse>()
               .ConstructUsing(src => new GetChargersEndPointResponse(src.CorrelationId()));
        }

    }
}
