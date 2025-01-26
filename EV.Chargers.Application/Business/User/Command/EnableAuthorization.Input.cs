using EV.Chargers.Core.Messages;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace EV.Chargers.Application.Business.User.Command
{
    public class EnableAuthorizationHandlerInput : BaseRequest, IRequest<EnableAuthorizationHandlerOutput>
    {
        public EnableAuthorizationHandlerInput() { }
        public EnableAuthorizationHandlerInput(Guid correlationId) : base(correlationId) { }
        public bool EnableAuthorization { get; set; }
    }
}
