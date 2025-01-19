using MediatR;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.ContractManagement.Query
{
    public class GetAllContractsHandlerInput : BaseRequest, IRequest<GetAllContractsHandlerOutput>
    {
        public GetAllContractsHandlerInput() { }
        public GetAllContractsHandlerInput(Guid correlationId) : base(correlationId) { }

    }
}
