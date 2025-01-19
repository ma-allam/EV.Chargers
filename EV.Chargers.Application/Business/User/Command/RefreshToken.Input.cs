using MediatR;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.User.Command
{
    public class RefreshTokenHandlerInput : BaseRequest, IRequest<RefreshTokenHandlerOutput>
    {
        public RefreshTokenHandlerInput() { }
        public RefreshTokenHandlerInput(Guid correlationId) : base(correlationId) { }
        public string? Token { get; set; }

    }
}
