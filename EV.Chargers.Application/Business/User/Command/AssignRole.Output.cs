using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.User.Command
{
    public class AssignRoleHandlerOutput : BaseResponse
    {
        public AssignRoleHandlerOutput() { }
        public AssignRoleHandlerOutput(Guid correlationId) : base(correlationId) { }
        public string Message { get; set; }

    }
}
