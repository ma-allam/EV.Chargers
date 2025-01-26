using System.ComponentModel.DataAnnotations;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.User.Command
{
    public class LoginEndPointRequest : BaseRequest
    {
        public const string Route = "/api/user/v{version:apiVersion}/Login/";
        /// <summary>
        /// Firebase Id
        /// </summary>
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string FireBaseToken { get; set; }
    }
}
