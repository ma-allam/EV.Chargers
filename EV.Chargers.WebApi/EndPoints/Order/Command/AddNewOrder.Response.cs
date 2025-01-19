

using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.Order.Command
{
    public class AddNewOrderEndPointResponse : BaseResponse
    {
        public AddNewOrderEndPointResponse() { }
        public AddNewOrderEndPointResponse(Guid correlationId) : base(correlationId) { }
        public string Message { get; set; }

    }
}
