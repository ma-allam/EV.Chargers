using MediatR;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.Order.Query
{
    public class GetOrdersByContractIdHandlerInput : BaseRequest, IRequest<GetOrdersByContractIdHandlerOutput>
    {
        public GetOrdersByContractIdHandlerInput() { }
        public GetOrdersByContractIdHandlerInput(Guid correlationId) : base(correlationId) { }
        public decimal ContractId { get; set; }
    }
}
