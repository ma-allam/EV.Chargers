using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.DataBaseSeed
{
    public class SeedDatabaseHandlerOutput : BaseResponse
    {
        public SeedDatabaseHandlerOutput() { }
        public SeedDatabaseHandlerOutput(Guid correlationId) : base(correlationId) { }

    }
}
