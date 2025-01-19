
using AutoMapper;
using EV.Chargers.Application.Business.ContractManagement.Query;

namespace EV.Chargers.WebApi.EndPoints.ContractManagement.Query
{
    public class GetAddNewContractDataMapper : Profile
    {
        public GetAddNewContractDataMapper()
        {
            CreateMap<GetAddNewContractDataEndPointRequest, GetAddNewContractDataHandlerInput>()
                .ConstructUsing(src => new GetAddNewContractDataHandlerInput(src.CorrelationId()));
            CreateMap<GetAddNewContractDataHandlerOutput, GetAddNewContractDataEndPointResponse>()
               .ConstructUsing(src => new GetAddNewContractDataEndPointResponse(src.CorrelationId()));
        }

    }
}
