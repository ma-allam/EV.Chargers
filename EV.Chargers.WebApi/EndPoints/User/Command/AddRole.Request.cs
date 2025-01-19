using System.ComponentModel.DataAnnotations;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.User.Command
{
    public class AddRoleEndPointRequest : BaseRequest
    {
        public const string Route = "/api/user/v{version:apiVersion}/AddRole/";

        [Required]
        public string RoleName { get; set; }
    }
}
