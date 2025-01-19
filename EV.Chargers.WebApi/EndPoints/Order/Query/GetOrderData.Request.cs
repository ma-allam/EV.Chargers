using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.Order.Query
{
    public class GetOrderDataEndPointRequest : BaseRequest
    {
        public const string Route = "/api/Order/v{version:apiVersion}/GetOrderData/";

        public decimal ContractId { get; set; }

    }
}
