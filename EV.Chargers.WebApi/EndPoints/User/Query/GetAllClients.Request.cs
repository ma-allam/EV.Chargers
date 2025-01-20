using EV.Chargers.Core.Messages;
using Microsoft.AspNetCore.Mvc;

namespace EV.Chargers.WebApi.EndPoints.User.Query
{
    public class GetAllClientsEndPointRequest : BaseRequest
    {
        public const string Route = "/api/v{version:apiVersion}/GetAllClients/";
    }
}
