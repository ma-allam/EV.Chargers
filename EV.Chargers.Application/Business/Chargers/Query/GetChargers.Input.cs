using EV.Chargers.Core.Messages;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace EV.Chargers.Application.Business.Chargers.Query
{
    public class GetChargersHandlerInput : BaseRequest, IRequest<GetChargersHandlerOutput>
    {
        public GetChargersHandlerInput() { }
        public GetChargersHandlerInput(Guid correlationId) : base(correlationId) { }
        public long? StationId { get; set; }
        public short? ChargerTypeId { get; set; }
        public short? StatusId { get; set; }
    }
}
