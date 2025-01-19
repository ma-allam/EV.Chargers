

using EV.Chargers.Application.Business.Order.Query;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.Order.Query
{
    public class GetOrdersByContractIdEndPointResponse : BaseResponse
    {
        public GetOrdersByContractIdEndPointResponse() { }
        public GetOrdersByContractIdEndPointResponse(Guid correlationId) : base(correlationId) { }
        public List<OrderData> Orders { get; set; }

    }
}
