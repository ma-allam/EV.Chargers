using System.ComponentModel.DataAnnotations;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.User.Command
{
    public class AssignRoleEndPointRequest : BaseRequest
    {
        public const string Route = "/api/user/v{version:apiVersion}/AssignRole/";

        [Required]
        public string Username { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
