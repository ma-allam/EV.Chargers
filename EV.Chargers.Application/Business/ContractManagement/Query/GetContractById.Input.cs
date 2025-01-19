using System.ComponentModel.DataAnnotations;
using MediatR;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.ContractManagement.Query
{
    public class GetContractByIdHandlerInput : BaseRequest, IRequest<GetContractByIdHandlerOutput>
    {
        public GetContractByIdHandlerInput() { }
        public GetContractByIdHandlerInput(Guid correlationId) : base(correlationId) { }
        [Required]
        public int ContractId { get; set; }
    }
}
