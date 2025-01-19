
using AutoMapper;
using EV.Chargers.Application.Business.User.Command;

namespace EV.Chargers.WebApi.EndPoints.User.Command
{
    public class RefreshTokenMapper : Profile
    {
        public RefreshTokenMapper()
        {
            CreateMap<RefreshTokenEndPointRequest, RefreshTokenHandlerInput>()
                .ConstructUsing(src => new RefreshTokenHandlerInput(src.CorrelationId()));
            CreateMap<RefreshTokenHandlerOutput, RefreshTokenEndPointResponse>()
               .ConstructUsing(src => new RefreshTokenEndPointResponse(src.CorrelationId()));
        }

    }
}
