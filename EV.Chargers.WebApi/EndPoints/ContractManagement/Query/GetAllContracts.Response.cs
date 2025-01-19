

using EV.Chargers.Application.Business.ContractManagement.Query;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.ContractManagement.Query
{
    public class GetAllContractsEndPointResponse : BaseResponse
    {
        public GetAllContractsEndPointResponse() { }
        public GetAllContractsEndPointResponse(Guid correlationId) : base(correlationId) { }
        public List<ContractDto> Contracts { get; set; }
        public string Message { get; set; }
    }
}
