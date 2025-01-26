using EV.Chargers.Application.Contract;
using EV.Chargers.Core.Exceptions;
using EV.Chargers.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EV.Chargers.Application.Business.Chargers.Command
{
    public class AddNewChargerHandler : IRequestHandler<AddNewChargerHandlerInput, AddNewChargerHandlerOutput>
    {
        private readonly IDataBaseService _databaseService;
        private readonly ILogger<AddNewChargerHandler> _logger;
        public AddNewChargerHandler(ILogger<AddNewChargerHandler> logger, IDataBaseService databaseService)
        {
            _logger = logger;
            _databaseService = databaseService;
        }
        public async Task<AddNewChargerHandlerOutput> Handle(AddNewChargerHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling AddNewCharger business logic");
            AddNewChargerHandlerOutput output = new AddNewChargerHandlerOutput(request.CorrelationId());
            var charger = new Charger
            {
                StationId = request.StationId,
                ChargerTypeId = request.ChargerTypeId,
                StatusId = request.StatusId
            };

            try
            {
                _databaseService.Charger.Add(charger);
                await _databaseService.DBSaveChangesAsync();
                output.Message = "Charger added successfully";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error while adding new charger");
                throw new WebApiException("Error while adding new charger");
            }
            return output;
        }
    }
}
