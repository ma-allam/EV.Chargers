using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.Client.Command
{
    public class AddNewClientEndPointResponse : BaseResponse
    {
        public AddNewClientEndPointResponse() { }
        public AddNewClientEndPointResponse(Guid correlationId) : base(correlationId) { }

    }
}
