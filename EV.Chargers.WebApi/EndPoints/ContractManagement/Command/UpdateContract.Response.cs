

using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.ContractManagement.Command
{
    public class UpdateContractEndPointResponse : BaseResponse
    {
        public UpdateContractEndPointResponse() { }
        public UpdateContractEndPointResponse(Guid correlationId) : base(correlationId) { }
        public string Message { get; set; }

    }
}
