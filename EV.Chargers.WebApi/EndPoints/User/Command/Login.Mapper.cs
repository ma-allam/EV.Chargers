
using AutoMapper;
using EV.Chargers.Application.Business.User.Command;

namespace EV.Chargers.WebApi.EndPoints.User.Command
{
    public class LoginMapper : Profile
    {
        public LoginMapper()
        {
            CreateMap<LoginEndPointRequest, LoginHandlerInput>()
                .ConstructUsing(src => new LoginHandlerInput(src.CorrelationId()));
            CreateMap<LoginHandlerOutput, LoginEndPointResponse>()
               .ConstructUsing(src => new LoginEndPointResponse(src.CorrelationId()));
        }

    }
}
