using System.ComponentModel.DataAnnotations;
using MediatR;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.User.Command
{
    public class RegisterHandlerInput : BaseRequest, IRequest<RegisterHandlerOutput>
    {
        public RegisterHandlerInput() { }
        public RegisterHandlerInput(Guid correlationId) : base(correlationId) { }
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}
