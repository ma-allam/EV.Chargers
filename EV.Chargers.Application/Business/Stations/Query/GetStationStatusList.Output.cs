using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.Stations.Query
{
    public class GetStationStatusListHandlerOutput : BaseResponse
    {
        public GetStationStatusListHandlerOutput() { }
        public GetStationStatusListHandlerOutput(Guid correlationId) : base(correlationId) { }
        public List<StationStatusData> StationStatusList { get; set; }
    }
    public class StationStatusData
    {
        public short Id { get; set; }
        public string Name { get; set; }


    }
}
