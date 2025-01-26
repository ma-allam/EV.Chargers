using EV.Chargers.Core.Messages;
using Microsoft.AspNetCore.Mvc;

namespace EV.Chargers.WebApi.EndPoints.Stations.Query
{
    public class GetStationStatusListEndPointRequest : BaseRequest
    {
        public const string Route = "/api/station/v{version:apiVersion}/GetStationStatusList/";
    }
}
