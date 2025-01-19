using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.Order.Query
{
    public class SearchOrdersEndPointRequest : BaseRequest
    {
        public const string Route = "/api/Order/v{version:apiVersion}/SearchOrders/";

        public decimal? ClientId { get; set; }
        public decimal? ContractId { get; set; }

        public bool ContractEnabled { get; set; }
        public int OrderStatus { get; set; }
        public DateOnly FromDate { get; set; }
    }
}
