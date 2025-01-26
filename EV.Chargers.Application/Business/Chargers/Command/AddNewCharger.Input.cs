using EV.Chargers.Core.Messages;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace EV.Chargers.Application.Business.Chargers.Command
{
    public class AddNewChargerHandlerInput : BaseRequest, IRequest<AddNewChargerHandlerOutput>
    {
        public AddNewChargerHandlerInput() { }
        public AddNewChargerHandlerInput(Guid correlationId) : base(correlationId) { }
        public long StationId { get; set; }
        public short ChargerTypeId { get; set; }
        public short StatusId { get; set; }
    }
}
