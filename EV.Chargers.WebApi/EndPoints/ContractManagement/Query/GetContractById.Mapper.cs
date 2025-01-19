
using AutoMapper;
using EV.Chargers.Application.Business.ContractManagement.Query;

namespace EV.Chargers.WebApi.EndPoints.ContractManagement.Query
{
    public class GetContractByIdMapper : Profile
    {
        public GetContractByIdMapper()
        {
            CreateMap<GetContractByIdEndPointRequest, GetContractByIdHandlerInput>()
                .ConstructUsing(src => new GetContractByIdHandlerInput(src.CorrelationId()));
            CreateMap<GetContractByIdHandlerOutput, GetContractByIdEndPointResponse>()
               .ConstructUsing(src => new GetContractByIdEndPointResponse(src.CorrelationId()));
        }

    }
}
