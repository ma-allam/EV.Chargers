using EV.Chargers.Core.Auth.JWT;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.User.Command
{
    public class LoginHandlerOutput : BaseResponse
    {
        public LoginHandlerOutput() { }
        public LoginHandlerOutput(Guid correlationId) : base(correlationId) { }
        public TokenContext Context { get; set; }
    }

}
