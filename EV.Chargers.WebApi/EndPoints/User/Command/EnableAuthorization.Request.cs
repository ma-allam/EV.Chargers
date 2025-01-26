using EV.Chargers.Core.Messages;
using Microsoft.AspNetCore.Mvc;

namespace EV.Chargers.WebApi.EndPoints.User.Command
{
    public class EnableAuthorizationEndPointRequest : BaseRequest
    {
        public const string Route = "/api/user/v{version:apiVersion}/EnableAuthorization/";
        public bool EnableAuthorization { get; set; }

    }
}
