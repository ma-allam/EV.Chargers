using MediatR;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.DataBaseSeed
{
    public class SeedDatabaseHandlerInput : BaseRequest, IRequest<SeedDatabaseHandlerOutput>
    {
        public SeedDatabaseHandlerInput() { }
        public SeedDatabaseHandlerInput(Guid correlationId) : base(correlationId) { }
    }
}
