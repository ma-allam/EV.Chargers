using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.User.Command
{
    public class RefreshTokenEndPointRequest : BaseRequest
    {
        public const string Route = "/api/user/v{version:apiVersion}/RefreshToken/";
        public string? Token { get; set; }

    }
}
