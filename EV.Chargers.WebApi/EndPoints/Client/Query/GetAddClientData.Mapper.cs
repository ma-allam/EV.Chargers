
using AutoMapper;
using EV.Chargers.Application.Business.Clients.Query;

namespace EV.Chargers.WebApi.EndPoints.Client.Query
{
    public class GetAddClientDataMapper : Profile
    {
        public GetAddClientDataMapper()
        {
            CreateMap<GetAddClientDataEndPointRequest, GetAddClientDataHandlerInput>()
                .ConstructUsing(src => new GetAddClientDataHandlerInput(src.CorrelationId()));
            CreateMap<GetAddClientDataHandlerOutput, GetAddClientDataEndPointResponse>()
               .ConstructUsing(src => new GetAddClientDataEndPointResponse(src.CorrelationId()));
        }

    }
}
