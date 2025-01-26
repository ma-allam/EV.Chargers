using EV.Chargers.Core.Messages;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;

namespace EV.Chargers.WebApi.EndPoints.Stations.Query
{
    public class GetStationsEndPointRequest : BaseRequest
    {
        public const string Route = "/api/station/v{version:apiVersion}/GetStations/";
        public string? Name { get; set; }
        public string? Address { get; set; }
        public short? StatusId { get; set; }
        public short? ChargerTypeId { get; set; }

        public short? ChargerStatusId { get; set; }

        //public Geometry? Area { get; set; } // Search based on area (polygon or multipolygon)
    }
}
