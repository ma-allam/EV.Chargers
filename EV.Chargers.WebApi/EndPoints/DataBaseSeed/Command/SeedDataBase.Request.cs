using EV.Chargers.Core.Messages;
using Microsoft.AspNetCore.Mvc;

namespace EV.Chargers.WebApi.EndPoints.DataBaseSeed.Command
{
    public class SeedDataBaseEndPointRequest : BaseRequest
    {
        public const string Route = "/api/databaseseed/v{version:apiVersion}/SeedDataBase/";
    }
}
