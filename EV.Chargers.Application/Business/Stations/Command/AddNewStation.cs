using EV.Chargers.Application.Contract;
using EV.Chargers.Core.Auth.Contract;
using EV.Chargers.Core.Exceptions;
using EV.Chargers.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;
using NetTopologySuite.Geometries;

namespace EV.Chargers.Application.Business.Stations.Command
{
    public class AddNewStationHandler : IRequestHandler<AddNewStationHandlerInput, AddNewStationHandlerOutput>
    {
        private readonly IDataBaseService _databaseService;
        private readonly ILogger<AddNewStationHandler> _logger;
        private readonly ICurrentUserService _currentUserService;
        public AddNewStationHandler(ILogger<AddNewStationHandler> logger, IDataBaseService databaseService, ICurrentUserService currentUserService)
        {
            _logger = logger;
            _databaseService = databaseService;
            _currentUserService = currentUserService;
        }
        public async Task<AddNewStationHandlerOutput> Handle(AddNewStationHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling AddNewStation business logic");
            AddNewStationHandlerOutput output = new AddNewStationHandlerOutput(request.CorrelationId());
            var station = new Station
            {
                Name = request.Name,
                Address = request.Address,
                ContactNumber = request.ContactNumber,
                StatusId = request.StatusId,
                Location = ConvertLatLongToGeometry( request.Location.Latitude, request.Location.Longitude),
            };
            try
            {
                _databaseService.Station.Add(station);
                await _databaseService.DBSaveChangesAsync();
                output.Mwssage = "Station added successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while adding new station");
                throw new WebApiException("Error while adding new station");
            }
            return output;
        }
        private Geometry ConvertLatLongToGeometry(double latitude, double longitude)
        {
            var point = new Point(longitude, latitude)
            {
                SRID = 4326 // Set SRID for WGS84
            };
            return point;
        }
    }
}
