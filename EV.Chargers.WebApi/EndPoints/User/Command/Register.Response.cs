using EV.Chargers.Core.Auth.JWT;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.User.Command
{
    public class RegisterEndPointResponse : BaseResponse
    {
        public RegisterEndPointResponse() { }
        public RegisterEndPointResponse(Guid correlationId) : base(correlationId) { }
        public TokenContext Context { get; set; }

    }
}
