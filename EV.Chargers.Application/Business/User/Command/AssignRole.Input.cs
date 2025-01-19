using System.ComponentModel.DataAnnotations;
using MediatR;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.User.Command
{
    public class AssignRoleHandlerInput : BaseRequest, IRequest<AssignRoleHandlerOutput>
    {
        public AssignRoleHandlerInput() { }
        public AssignRoleHandlerInput(Guid correlationId) : base(correlationId) { }
        [Required]
        public string Username { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
