

using EV.Chargers.Application.Business.Order.Query;
using EV.Chargers.Core.Messages;
using EV.Chargers.Domain.Entities;

namespace EV.Chargers.WebApi.EndPoints.Order.Query
{
    public class GetOrderDataEndPointResponse : BaseResponse
    {
        public GetOrderDataEndPointResponse() { }
        public GetOrderDataEndPointResponse(Guid correlationId) : base(correlationId) { }
        public List<ContractImageModeOutput> ContractImageModes { get; set; }
        public List<ContractImageTypeOutput> ImageTypes { get; set; }

        public List<ContractImageResolutionOutput> ContractImageResolutions { get; set; }
        public List<ContractOrderPriorityOutput> ContractOrderPriorities { get; set; }
        public List<ContractServiceOutput> ContractServices { get; set; }

        public List<OrderStatusData> OrderStatus { get; set; }
    }

}
