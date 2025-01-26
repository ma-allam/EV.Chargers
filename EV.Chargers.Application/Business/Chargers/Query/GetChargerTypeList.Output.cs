using EV.Chargers.Application.Business.Stations.Query;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.Chargers.Query
{
    public class GetChargerTypeListHandlerOutput : BaseResponse
    {
        public GetChargerTypeListHandlerOutput() { }
        public GetChargerTypeListHandlerOutput(Guid correlationId) : base(correlationId) { }
        public List<ChargerTypeData> ChargerTypeList { get; set; }

    }
    public class ChargerTypeData
    {
        public short Id { get; set; }
        public string Type { get; set; }


    }
}
