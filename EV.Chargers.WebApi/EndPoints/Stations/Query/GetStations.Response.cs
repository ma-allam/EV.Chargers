using EV.Chargers.Application.Business.Stations.Query;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.Stations.Query
{
    public class GetStationsEndPointResponse : BaseResponse
    {
        public GetStationsEndPointResponse() { }
        public GetStationsEndPointResponse(Guid correlationId) : base(correlationId) { }
        public List<StationData> Stations { get; set; }

    }
}
