using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.Chargers.Command
{
    public class AddNewChargerEndPointResponse : BaseResponse
    {
        public AddNewChargerEndPointResponse() { }
        public AddNewChargerEndPointResponse(Guid correlationId) : base(correlationId) { }
        public string Message { get; set; }

    }
}
