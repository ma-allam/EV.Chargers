

using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.User.Command
{
    public class AssignRoleEndPointResponse : BaseResponse
    {
        public AssignRoleEndPointResponse() { }
        public AssignRoleEndPointResponse(Guid correlationId) : base(correlationId) { }
        public string Message { get; set; }

    }
}
