using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.DataBaseSeed
{
    public class SeedDatabaseEndPointRequest : BaseRequest
    {
        public const string Route = "/api/user/v{version:apiVersion}/DataBaseSeed/";
    }
}
