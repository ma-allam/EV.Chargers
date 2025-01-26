using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.Stations.Command
{
    public class AddNewStationEndPointResponse : BaseResponse
    {
        public AddNewStationEndPointResponse() { }
        public AddNewStationEndPointResponse(Guid correlationId) : base(correlationId) { }
        public string Mwssage { get; set; }
    }
}
