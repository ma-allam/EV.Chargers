using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.Chargers.Query
{
    public class GetChargersHandlerOutput : BaseResponse
    {
        public GetChargersHandlerOutput() { }
        public GetChargersHandlerOutput(Guid correlationId) : base(correlationId) { }
        public List<ChargerData> Chargers { get; set; } 

    }
    public class ChargerData
    {
        public long Id { get; set; }
        public long? StationId { get; set; }
        public short? ChargerTypeId { get; set; }
        public short? StatusId { get; set; }
    }
}
