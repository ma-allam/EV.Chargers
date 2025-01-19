

using EV.Chargers.Application.Business.ContractManagement.Query;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.ContractManagement.Query
{
    public class GetContractByIdEndPointResponse : BaseResponse
    {
        public GetContractByIdEndPointResponse() { }
        public GetContractByIdEndPointResponse(Guid correlationId) : base(correlationId) { }
        public ContractDto Contract { get; set; }
        public string Message { get; set; }
    }
}
