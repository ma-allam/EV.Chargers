

using EV.Chargers.Application.Business.ContractManagement.Query;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.ContractManagement.Query
{
    public class GetAddNewContractDataEndPointResponse : BaseResponse
    {
        public GetAddNewContractDataEndPointResponse() { }
        public GetAddNewContractDataEndPointResponse(Guid correlationId) : base(correlationId) { }
        public List<ContractData> Currency { get; set; }
        public List<ContractData> ImageType { get; set; }
        public List<ContractData> PaymentMethod { get; set; }
    }
}
