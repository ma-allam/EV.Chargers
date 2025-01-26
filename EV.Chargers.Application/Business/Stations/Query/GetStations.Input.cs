using EV.Chargers.Application.Business.Stations.Command;
using EV.Chargers.Core.Messages;
using MediatR;
using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;

namespace EV.Chargers.Application.Business.Stations.Query
{
    public class GetStationsHandlerInput : BaseRequest, IRequest<GetStationsHandlerOutput>
    {
        public GetStationsHandlerInput() { }
        public GetStationsHandlerInput(Guid correlationId) : base(correlationId) { }
        public string? Name { get; set; }
        public string? Address { get; set; }
        public short? StatusId { get; set; }
        public short? ChargerTypeId { get; set; }

        public short? ChargerStatusId { get; set; }

        public List<LocationLatLong>? AreaCoordinates { get; set; } // Search based on area (polygon or multipolygon)
    }
}
