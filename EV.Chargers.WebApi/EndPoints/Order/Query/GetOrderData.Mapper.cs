
using AutoMapper;
using EV.Chargers.Application.Business.Order.Query;

namespace EV.Chargers.WebApi.EndPoints.Order.Query
{
    public class GetOrderDataMapper : Profile
    {
        public GetOrderDataMapper()
        {
            CreateMap<GetOrderDataEndPointRequest, GetOrderDataHandlerInput>()
                .ConstructUsing(src => new GetOrderDataHandlerInput(src.CorrelationId()));
            CreateMap<GetOrderDataHandlerOutput, GetOrderDataEndPointResponse>()
               .ConstructUsing(src => new GetOrderDataEndPointResponse(src.CorrelationId()));
        }

    }
}
