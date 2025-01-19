using EV.Chargers.Core.Auth.JWT;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.User.Command
{
    public class RefreshTokenHandlerOutput : BaseResponse
    {
        public RefreshTokenHandlerOutput() { }
        public RefreshTokenHandlerOutput(Guid correlationId) : base(correlationId) { }
        public TokenContext Context { get; set; }
    }
}
