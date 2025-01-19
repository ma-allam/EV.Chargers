using NetTopologySuite.Geometries;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.Order.Query
{
    public class SearchOrdersHandlerOutput : BaseResponse
    {
        public SearchOrdersHandlerOutput() { }
        public SearchOrdersHandlerOutput(Guid correlationId) : base(correlationId) { }
        public List<OrderData> Orders { get; set; }

    }

}
