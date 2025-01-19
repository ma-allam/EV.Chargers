

using EV.Chargers.Application.Business.Clients.Query;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.Client.Query
{
    public class SearchClientsEndPointResponse : BaseResponse
    {
        public SearchClientsEndPointResponse() { }
        public SearchClientsEndPointResponse(Guid correlationId) : base(correlationId) { }
        public List<ClientData> Clients { get; set; }

    }
}
