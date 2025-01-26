
using AutoMapper;
using EV.Chargers.Application.Business.User.Query;

namespace EV.Chargers.WebApi.EndPoints.User.Query
{
    public class GetAllClientsMapper : Profile
    {
        public GetAllClientsMapper()
        {
            CreateMap<GetAllClientsEndPointRequest, GetAllClientsHandlerInput>()
                .ConstructUsing(src => new GetAllClientsHandlerInput(src.CorrelationId()));
            CreateMap<GetAllClientsHandlerOutput, GetAllClientsEndPointResponse>()
               .ConstructUsing(src => new GetAllClientsEndPointResponse(src.CorrelationId()));
        }

    }
}
