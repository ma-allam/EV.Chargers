using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.Stations.Command
{
    public class AddNewStationHandlerOutput : BaseResponse
    {
        public AddNewStationHandlerOutput() { }
        public AddNewStationHandlerOutput(Guid correlationId) : base(correlationId) { }
        public string Mwssage { get; set; }

    }
}
