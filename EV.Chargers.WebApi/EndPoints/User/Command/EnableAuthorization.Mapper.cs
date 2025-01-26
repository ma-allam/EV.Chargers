
using AutoMapper;
using EV.Chargers.Application.Business.User.Command;

namespace EV.Chargers.WebApi.EndPoints.User.Command
{
    public class EnableAuthorizationMapper : Profile
    {
        public EnableAuthorizationMapper()
        {
            CreateMap<EnableAuthorizationEndPointRequest, EnableAuthorizationHandlerInput>()
                .ConstructUsing(src => new EnableAuthorizationHandlerInput(src.CorrelationId()));
            CreateMap<EnableAuthorizationHandlerOutput, EnableAuthorizationEndPointResponse>()
               .ConstructUsing(src => new EnableAuthorizationEndPointResponse(src.CorrelationId()));
        }

    }
}
