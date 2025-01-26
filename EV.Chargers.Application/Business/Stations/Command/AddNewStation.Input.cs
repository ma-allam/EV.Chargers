using EV.Chargers.Core.Messages;
using MediatR;
using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;

namespace EV.Chargers.Application.Business.Stations.Command
{
    public class AddNewStationHandlerInput : BaseRequest, IRequest<AddNewStationHandlerOutput>
    {
        public AddNewStationHandlerInput() { }
        public AddNewStationHandlerInput(Guid correlationId) : base(correlationId) { }
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? ContactNumber { get; set; }

        [Required]
        public short? StatusId { get; set; }

        [Required]
        public LocationLatLong? Location { get; set; }
    }
    public class LocationLatLong
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
