using System.ComponentModel.DataAnnotations;
using MediatR;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.User.Command
{
    public class AddRoleHandlerInput : BaseRequest, IRequest<AddRoleHandlerOutput>
    {
        public AddRoleHandlerInput() { }
        public AddRoleHandlerInput(Guid correlationId) : base(correlationId) { }
        [Required]
        public string RoleName { get; set; }
    }
}
