using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.Order.Command
{
    public class UpdateOrderHandlerOutput : BaseResponse
    {
        public UpdateOrderHandlerOutput() { }
        public UpdateOrderHandlerOutput(Guid correlationId) : base(correlationId) { }
        public string Message { get; set; }
    }
}
