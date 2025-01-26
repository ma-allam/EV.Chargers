using System.ComponentModel.DataAnnotations;
using MediatR;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.User.Command
{
    public class LoginHandlerInput : BaseRequest, IRequest<LoginHandlerOutput>
    {
        public LoginHandlerInput() { }
        public LoginHandlerInput(Guid correlationId) : base(correlationId) { }
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
