using MediatR;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.Order.Query
{
    public class GetOrderDataHandlerInput : BaseRequest, IRequest<GetOrderDataHandlerOutput>
    {
        public GetOrderDataHandlerInput() { }
        public GetOrderDataHandlerInput(Guid correlationId) : base(correlationId) { }
        public decimal ContractId { get; set; }
    }
}
