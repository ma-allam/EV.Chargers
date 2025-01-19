using MediatR;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.Clients.Query
{
    public class GetAddClientDataHandlerInput : BaseRequest, IRequest<GetAddClientDataHandlerOutput>
    {
        public GetAddClientDataHandlerInput() { }
        public GetAddClientDataHandlerInput(Guid correlationId) : base(correlationId) { }
    }
}
