
using AutoMapper;
using EV.Chargers.Application.Business.Clients.Query;

namespace EV.Chargers.WebApi.EndPoints.Client.Query
{
    public class SearchClientsMapper : Profile
    {
        public SearchClientsMapper()
        {
            CreateMap<SearchClientsEndPointRequest, SearchClientsHandlerInput>()
                .ConstructUsing(src => new SearchClientsHandlerInput(src.CorrelationId()));
            CreateMap<SearchClientsHandlerOutput, SearchClientsEndPointResponse>()
               .ConstructUsing(src => new SearchClientsEndPointResponse(src.CorrelationId()));
        }

    }
}
