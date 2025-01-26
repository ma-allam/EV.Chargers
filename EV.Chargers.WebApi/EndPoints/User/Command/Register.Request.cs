using System.ComponentModel.DataAnnotations;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.User.Command
{
    public class RegisterEndPointRequest : BaseRequest
    {
        public const string Route = "/api/user/v{version:apiVersion}/Register/";
        /// <summary>
        /// Firebase Id
        /// </summary>
        [Required]
        public string Username { get; set; }
        /// <summary>
        /// Full Name Of User
        /// </summary>
        [Required]
        public string FullName { get; set; }
        /// <summary>
        /// Email Of User if exist
        /// </summary>
        //[Required]
        [EmailAddress]
        public string Email { get; set; }
        /// <summary>
        /// Phone Number Of User if exist
        /// </summary>
        //[Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        public string FireBaseToken { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
