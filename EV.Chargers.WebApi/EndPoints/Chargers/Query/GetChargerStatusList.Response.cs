using EV.Chargers.Application.Business.Chargers.Query;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.Chargers.Query
{
    public class GetChargerStatusListEndPointResponse : BaseResponse
    {
        public GetChargerStatusListEndPointResponse() { }
        public GetChargerStatusListEndPointResponse(Guid correlationId) : base(correlationId) { }
        public List<ChargerStatusData> ChargerStatusList { get; set; }

    }
}
