using EV.Chargers.Application.Business.Stations.Query;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.Stations.Query
{
    public class GetStationStatusListEndPointResponse : BaseResponse
    {
        public GetStationStatusListEndPointResponse() { }
        public GetStationStatusListEndPointResponse(Guid correlationId) : base(correlationId) { }
        public List<StationStatusData> StationStatusList { get; set; }

    }
}
