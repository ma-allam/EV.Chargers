using EV.Chargers.Core.Messages;
using Microsoft.AspNetCore.Mvc;
using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EV.Chargers.WebApi.EndPoints.Stations.Command
{
    public class AddNewStationEndPointRequest : BaseRequest
    {
        public const string Route = "/api/station/v{version:apiVersion}/AddNewStation/";
        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Address { get; set; }

        [Required]
        public string? ContactNumber { get; set; }

        [Required]
        public short? StatusId { get; set; }

        //[Required]
        //public Geometry? Location { get; set; }

    }
}
