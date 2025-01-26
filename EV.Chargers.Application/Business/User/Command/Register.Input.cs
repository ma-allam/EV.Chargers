using System.ComponentModel.DataAnnotations;
using MediatR;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.User.Command
{
    public class RegisterHandlerInput : BaseRequest, IRequest<RegisterHandlerOutput>
    {
        public RegisterHandlerInput() { }
        public RegisterHandlerInput(Guid correlationId) : base(correlationId) { }
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
