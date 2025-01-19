using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.Clients.Command
{
    public class AddNewClientHandlerOutput : BaseResponse
    {
        public AddNewClientHandlerOutput() { }
        public AddNewClientHandlerOutput(Guid correlationId) : base(correlationId) { }

    }
}
