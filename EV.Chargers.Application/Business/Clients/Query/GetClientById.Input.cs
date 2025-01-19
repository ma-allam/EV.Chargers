using MediatR;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.Clients.Query
{
    public class GetClientByIdHandlerInput : BaseRequest, IRequest<GetClientByIdHandlerOutput>
    {
        public GetClientByIdHandlerInput() { }
        public GetClientByIdHandlerInput(Guid correlationId) : base(correlationId) { }

        public int ClientId { get; set; }
    }
}
