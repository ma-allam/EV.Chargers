using EV.Chargers.Core.Auth.JWT;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.User.Command
{
    public class LoginEndPointResponse : BaseResponse
    {
        public LoginEndPointResponse() { }
        public LoginEndPointResponse(Guid correlationId) : base(correlationId) { }
        public TokenContext Context { get; set; }

    }
}
