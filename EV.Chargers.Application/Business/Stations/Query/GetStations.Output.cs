using EV.Chargers.Core.Messages;
using NetTopologySuite.Geometries;

namespace EV.Chargers.Application.Business.Stations.Query
{
    public class GetStationsHandlerOutput : BaseResponse
    {
        public GetStationsHandlerOutput() { }
        public GetStationsHandlerOutput(Guid correlationId) : base(correlationId) { }
        public List<StationData> Stations { get; set; }
    }
    public class StationData
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string ContactNumber { get; set; }
        public short StatusId { get; set; }
        public Geometry Location { get; set; }
    }
}
