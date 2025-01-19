

using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.Client.Command
{
    public class UpdateClientEndPointResponse : BaseResponse
    {
        public UpdateClientEndPointResponse() { }
        public UpdateClientEndPointResponse(Guid correlationId) : base(correlationId) { }
        public string Message { get; set; }

    }
}
