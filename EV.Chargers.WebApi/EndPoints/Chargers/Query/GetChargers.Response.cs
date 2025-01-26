using EV.Chargers.Application.Business.Chargers.Query;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.Chargers.Query
{
    public class GetChargersEndPointResponse : BaseResponse
    {
        public GetChargersEndPointResponse() { }
        public GetChargersEndPointResponse(Guid correlationId) : base(correlationId) { }
        public List<ChargerData> Chargers { get; set; }

    }
}
