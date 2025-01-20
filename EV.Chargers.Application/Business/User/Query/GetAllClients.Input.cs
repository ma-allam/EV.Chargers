using EV.Chargers.Core.Messages;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace EV.Chargers.Application.Business.User.Query
{
    public class GetAllClientsHandlerInput : BaseRequest, IRequest<GetAllClientsHandlerOutput>
    {
        public GetAllClientsHandlerInput() { }
        public GetAllClientsHandlerInput(Guid correlationId) : base(correlationId) { }
    }
}
