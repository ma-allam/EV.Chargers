using EV.Chargers.Application.Business.User.Query;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.User.Query
{
    public class GetAllClientsEndPointResponse : BaseResponse
    {
        public GetAllClientsEndPointResponse() { }
        public GetAllClientsEndPointResponse(Guid correlationId) : base(correlationId) { }
        public List<Client> Clients { get; set; }

    }
}
