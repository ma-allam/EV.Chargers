
using AutoMapper;
using EV.Chargers.Application.Business.Order.Query;

namespace EV.Chargers.WebApi.EndPoints.Order.Query
{
    public class SearchOrdersMapper : Profile
    {
        public SearchOrdersMapper()
        {
            CreateMap<SearchOrdersEndPointRequest, SearchOrdersHandlerInput>()
                .ConstructUsing(src => new SearchOrdersHandlerInput(src.CorrelationId()));
            CreateMap<SearchOrdersHandlerOutput, SearchOrdersEndPointResponse>()
               .ConstructUsing(src => new SearchOrdersEndPointResponse(src.CorrelationId()));
        }

    }
}
