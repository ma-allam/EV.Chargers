using EV.Chargers.Core.Messages;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace EV.Chargers.Application.Business.Chargers.Query
{
    public class GetChargerTypeListHandlerInput : BaseRequest, IRequest<GetChargerTypeListHandlerOutput>
    {
        public GetChargerTypeListHandlerInput() { }
        public GetChargerTypeListHandlerInput(Guid correlationId) : base(correlationId) { }
    }
}
