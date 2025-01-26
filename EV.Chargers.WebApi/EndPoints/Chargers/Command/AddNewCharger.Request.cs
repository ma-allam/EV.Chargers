using EV.Chargers.Core.Messages;
using Microsoft.AspNetCore.Mvc;

namespace EV.Chargers.WebApi.EndPoints.Chargers.Command
{
    public class AddNewChargerEndPointRequest : BaseRequest
    {
        public const string Route = "/api/charger/v{version:apiVersion}/AddNewCharger/";
        public long StationId { get; set; }
        public short ChargerTypeId { get; set; }
        public short StatusId { get; set; }
    }
}
