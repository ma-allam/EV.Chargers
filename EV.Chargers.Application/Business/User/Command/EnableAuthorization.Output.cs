using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.User.Command
{
    public class EnableAuthorizationHandlerOutput : BaseResponse
    {
        public EnableAuthorizationHandlerOutput() { }
        public EnableAuthorizationHandlerOutput(Guid correlationId) : base(correlationId) { }

        public string Message { get;  set; }
        public bool IsAuthorizationEnabled { get;  set; }
    }
}
