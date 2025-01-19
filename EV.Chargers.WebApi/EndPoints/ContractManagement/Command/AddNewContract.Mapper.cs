
using AutoMapper;
using EV.Chargers.Application.Business.ContractManagement.Command;

namespace EV.Chargers.WebApi.EndPoints.ContractManagement.Command
{
    public class AddNewContractMapper : Profile
    {
        public AddNewContractMapper()
        {
            CreateMap<AddNewContractEndPointRequest, AddNewContractHandlerInput>()
                .ConstructUsing(src => new AddNewContractHandlerInput(src.CorrelationId()));
            CreateMap<AddNewContractHandlerOutput, AddNewContractEndPointResponse>()
               .ConstructUsing(src => new AddNewContractEndPointResponse(src.CorrelationId()));
        }

    }
}
