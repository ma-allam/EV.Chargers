using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.Chargers.Query
{
    public class GetChargerStatusListHandlerOutput : BaseResponse
    {
        public GetChargerStatusListHandlerOutput() { }
        public GetChargerStatusListHandlerOutput(Guid correlationId) : base(correlationId) { }
        public List<ChargerStatusData> ChargerStatusList { get; set; }

    }
    public class ChargerStatusData
    {
        public short Id { get; set; }
        public string Name { get; set; }


    }
    

}
