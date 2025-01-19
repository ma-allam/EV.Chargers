using MediatR;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.Clients.Query
{
    public class GetAllClientsHandlerInput : BaseRequest, IRequest<GetAllClientsHandlerOutput>
    {
        public GetAllClientsHandlerInput() { }
        public GetAllClientsHandlerInput(Guid correlationId) : base(correlationId) { }
    }
}
