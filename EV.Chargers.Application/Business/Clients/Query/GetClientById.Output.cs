using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.Clients.Query
{
    public class GetClientByIdHandlerOutput : BaseResponse
    {
        public GetClientByIdHandlerOutput() { }
        public GetClientByIdHandlerOutput(Guid correlationId) : base(correlationId) { }
        public ClientData? Client { get; set; }

    }
}
