
using AutoMapper;
using EV.Chargers.Application.Business.ContractManagement.Command;

namespace EV.Chargers.WebApi.EndPoints.ContractManagement.Command
{
    public class UpdateContractMapper : Profile
    {
        public UpdateContractMapper()
        {
            CreateMap<UpdateContractEndPointRequest, UpdateContractHandlerInput>()
                .ConstructUsing(src => new UpdateContractHandlerInput(src.CorrelationId()));
            CreateMap<UpdateContractHandlerOutput, UpdateContractEndPointResponse>()
               .ConstructUsing(src => new UpdateContractEndPointResponse(src.CorrelationId()));
        }

    }
}
