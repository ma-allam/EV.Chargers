using MediatR;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.ContractManagement.Query
{
    public class GetAddNewContractDataHandlerInput : BaseRequest, IRequest<GetAddNewContractDataHandlerOutput>
    {
        public GetAddNewContractDataHandlerInput() { }
        public GetAddNewContractDataHandlerInput(Guid correlationId) : base(correlationId) { }
    }
}
