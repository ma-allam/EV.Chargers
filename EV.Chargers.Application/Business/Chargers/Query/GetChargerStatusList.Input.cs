using EV.Chargers.Core.Messages;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace EV.Chargers.Application.Business.Chargers.Query
{
    public class GetChargerStatusListHandlerInput : BaseRequest, IRequest<GetChargerStatusListHandlerOutput>
    {
        public GetChargerStatusListHandlerInput() { }
        public GetChargerStatusListHandlerInput(Guid correlationId) : base(correlationId) { }
    }
}
