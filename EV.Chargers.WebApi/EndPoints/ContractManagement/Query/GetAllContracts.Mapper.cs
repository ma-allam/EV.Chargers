
using AutoMapper;
using EV.Chargers.Application.Business.ContractManagement.Query;

namespace EV.Chargers.WebApi.EndPoints.ContractManagement.Query
{
    public class GetAllContractsMapper : Profile
    {
        public GetAllContractsMapper()
        {
            CreateMap<GetAllContractsEndPointRequest, GetAllContractsHandlerInput>()
                .ConstructUsing(src => new GetAllContractsHandlerInput(src.CorrelationId()));
            CreateMap<GetAllContractsHandlerOutput, GetAllContractsEndPointResponse>()
               .ConstructUsing(src => new GetAllContractsEndPointResponse(src.CorrelationId()));
        }

    }
}
