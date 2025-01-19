
using AutoMapper;
using EV.Chargers.Application.Business.Order.Query;

namespace EV.Chargers.WebApi.EndPoints.Order.Query
{
    public class GetOrdersByContractIdMapper : Profile
    {
        public GetOrdersByContractIdMapper()
        {
            CreateMap<GetOrdersByContractIdEndPointRequest, GetOrdersByContractIdHandlerInput>()
                .ConstructUsing(src => new GetOrdersByContractIdHandlerInput(src.CorrelationId()));
            CreateMap<GetOrdersByContractIdHandlerOutput, GetOrdersByContractIdEndPointResponse>()
               .ConstructUsing(src => new GetOrdersByContractIdEndPointResponse(src.CorrelationId()));
        }

    }
}
