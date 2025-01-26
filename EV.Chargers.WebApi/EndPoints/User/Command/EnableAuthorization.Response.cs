using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.User.Command
{
    public class EnableAuthorizationEndPointResponse : BaseResponse
    {
        public EnableAuthorizationEndPointResponse() { }
        public EnableAuthorizationEndPointResponse(Guid correlationId) : base(correlationId) { }
        public string Message { get; set; }
        public bool IsAuthorizationEnabled { get; set; }
    }
}
