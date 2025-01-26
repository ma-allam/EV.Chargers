using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.Chargers.Command
{
    public class AddNewChargerHandlerOutput : BaseResponse
    {
        public AddNewChargerHandlerOutput() { }
        public AddNewChargerHandlerOutput(Guid correlationId) : base(correlationId) { }

        public string Message { get;  set; }
    }
}
