
using AutoMapper;
using EV.Chargers.Application.Business.User.Command;

namespace EV.Chargers.WebApi.EndPoints.User.Command
{
    public class RegisterMapper : Profile
    {
        public RegisterMapper()
        {
            CreateMap<RegisterEndPointRequest, RegisterHandlerInput>()
                .ConstructUsing(src => new RegisterHandlerInput(src.CorrelationId()));
            CreateMap<RegisterHandlerOutput, RegisterEndPointResponse>()
               .ConstructUsing(src => new RegisterEndPointResponse(src.CorrelationId()));
        }

    }
}
