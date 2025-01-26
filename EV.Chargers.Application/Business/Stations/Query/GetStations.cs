using EV.Chargers.Application.Business.Stations.Command;
using EV.Chargers.Application.Contract;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NetTopologySuite.Geometries;

namespace EV.Chargers.Application.Business.Stations.Query
{
    public class GetStationsHandler : IRequestHandler<GetStationsHandlerInput, GetStationsHandlerOutput>
    {
        private readonly IDataBaseService _databaseService;
        private readonly ILogger<GetStationsHandler> _logger;
        public GetStationsHandler(ILogger<GetStationsHandler> logger, IDataBaseService databaseService)
        {
            _logger = logger;
            _databaseService = databaseService;
        }
        public async Task<GetStationsHandlerOutput> Handle(GetStationsHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling GetStations business logic");
            GetStationsHandlerOutput output = new GetStationsHandlerOutput(request.CorrelationId());
            var query = _databaseService.Station.AsQueryable();

            // Apply filters
            if (!string.IsNullOrWhiteSpace(request.Name))
                query = query.Where(s => s.Name.Contains(request.Name));

            if (!string.IsNullOrWhiteSpace(request.Address))
                query = query.Where(s => s.Address.Contains(request.Address));

        

            if (request.StatusId.HasValue)
                query = query.Where(s => s.StatusId == request.StatusId);

            if (request.AreaCoordinates != null && request.AreaCoordinates.Any())
            {
                // Example: Perform filtering based on area coordinates (bounding box or polygon)
                // Convert AreaCoordinates to a Polygon or MultiPolygon for spatial filtering
                var areaPolygon = CreatePolygonFromCoordinates(request.AreaCoordinates);
                query = query.Where(s => areaPolygon.Contains(s.Location));
            }


            if (request.ChargerStatusId.HasValue)
                query = query.Where(s => s.Charger.Any(a=>a.StatusId == request.ChargerStatusId));


            if (request.ChargerTypeId.HasValue)
                query = query.Where(s => s.Charger.Any(a => a.ChargerTypeId == request.ChargerTypeId));


            // Execute query and map results
            output.Stations = await query.Select(s => new StationData
            {
                Name = s.Name,
                Address = s.Address,
                ContactNumber = s.ContactNumber,
                StatusId =(short) s.StatusId,
                Location = s.Location
            }).ToListAsync();

            return output;
        }
        private Polygon CreatePolygonFromCoordinates(List<LocationLatLong> coordinates)
        {
            var shell = coordinates.Select(c => new Coordinate(c.Longitude, c.Latitude)).ToArray();
            return new Polygon(new LinearRing(shell));
        }
    }
}
