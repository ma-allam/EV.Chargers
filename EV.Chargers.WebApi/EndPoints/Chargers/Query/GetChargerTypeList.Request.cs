using EV.Chargers.Core.Messages;
using Microsoft.AspNetCore.Mvc;

namespace EV.Chargers.WebApi.EndPoints.Chargers.Query
{
    public class GetChargerTypeListEndPointRequest : BaseRequest
    {
        public const string Route = "/api/charger/v{version:apiVersion}/GetChargerTypeList/";
    }
}
