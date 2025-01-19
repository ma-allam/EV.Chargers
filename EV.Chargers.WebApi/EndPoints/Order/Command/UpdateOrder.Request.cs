using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.Order.Command
{
    public class UpdateOrderEndPointRequest : BaseRequest
    {
        public const string Route = "/api/Order/v{version:apiVersion}/UpdateOrder/";

        public decimal OrderId { get; set; }
        public double? CompeletedPercentage { get; set; }
        public int? OrderStatusId { get; set; }
    }
}
