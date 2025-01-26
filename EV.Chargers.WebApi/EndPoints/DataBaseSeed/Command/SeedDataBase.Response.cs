using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.DataBaseSeed.Command
{
    public class SeedDataBaseEndPointResponse : BaseResponse
    {
        public SeedDataBaseEndPointResponse() { }
        public SeedDataBaseEndPointResponse(Guid correlationId) : base(correlationId) { }

    }
}
