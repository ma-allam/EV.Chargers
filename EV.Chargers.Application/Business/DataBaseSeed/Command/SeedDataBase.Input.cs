using EV.Chargers.Core.Messages;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace EV.Chargers.Application.Business.DataBaseSeed.Command
{
    public class SeedDataBaseHandlerInput : BaseRequest, IRequest<SeedDataBaseHandlerOutput>
    {
        public SeedDataBaseHandlerInput() { }
        public SeedDataBaseHandlerInput(Guid correlationId) : base(correlationId) { }
    }
}
