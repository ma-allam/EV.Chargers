using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.Client.Query
{
    public class GetAllClientsEndPointRequest : BaseRequest
    {
        public const string Route = "/api/client/v{version:apiVersion}/GetAllClients/";

    }
}
