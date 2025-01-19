

using EV.Chargers.Application.Business.Clients.Query;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.Client.Query
{
    public class GetClientByIdEndPointResponse : BaseResponse
    {
        public GetClientByIdEndPointResponse() { }
        public GetClientByIdEndPointResponse(Guid correlationId) : base(correlationId) { }
        public ClientData? Client { get; set; }

    }
}
