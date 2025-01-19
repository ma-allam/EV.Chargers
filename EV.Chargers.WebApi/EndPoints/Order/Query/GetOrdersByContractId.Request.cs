using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.Order.Query
{
    public class GetOrdersByContractIdEndPointRequest : BaseRequest
    {
        public const string Route = "/api/Order/v{version:apiVersion}/GetOrdersByContractId/";
        public decimal ContractId { get; set; }

    }
}
