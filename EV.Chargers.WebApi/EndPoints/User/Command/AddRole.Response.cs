

using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.User.Command
{
    public class AddRoleEndPointResponse : BaseResponse
    {
        public AddRoleEndPointResponse() { }
        public AddRoleEndPointResponse(Guid correlationId) : base(correlationId) { }
        public string Message { get; set; }

    }
}
