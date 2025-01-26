using EV.Chargers.Application.Business.Chargers.Query;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.Chargers.Query
{
    public class GetChargerTypeListEndPointResponse : BaseResponse
    {
        public GetChargerTypeListEndPointResponse() { }
        public GetChargerTypeListEndPointResponse(Guid correlationId) : base(correlationId) { }
        public List<ChargerTypeData> ChargerTypeList { get; set; }

    }
}
