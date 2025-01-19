
using AutoMapper;
using EV.Chargers.Application.Business.User.Command;

namespace EV.Chargers.WebApi.EndPoints.User.Command
{
    public class AssignRoleMapper : Profile
    {
        public AssignRoleMapper()
        {
            CreateMap<AssignRoleEndPointRequest, AssignRoleHandlerInput>()
                .ConstructUsing(src => new AssignRoleHandlerInput(src.CorrelationId()));
            CreateMap<AssignRoleHandlerOutput, AssignRoleEndPointResponse>()
               .ConstructUsing(src => new AssignRoleEndPointResponse(src.CorrelationId()));
        }

    }
}
