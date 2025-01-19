

using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.DataBaseSeed
{
    public class SeedDatabaseEndPointResponse : BaseResponse
    {
        public SeedDatabaseEndPointResponse() { }
        public SeedDatabaseEndPointResponse(Guid correlationId) : base(correlationId) { }

    }
}
