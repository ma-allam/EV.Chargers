using EV.Chargers.Application.Contract;
using EV.Chargers.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EV.Chargers.Application.Business.DataBaseSeed.Command
{
    public class SeedDataBaseHandler : IRequestHandler<SeedDataBaseHandlerInput, SeedDataBaseHandlerOutput>
    {
        private readonly IDataBaseService _databaseService;
        private readonly ILogger<SeedDataBaseHandler> _logger;
        public SeedDataBaseHandler(ILogger<SeedDataBaseHandler> logger, IDataBaseService databaseService)
        {
            _logger = logger;
            _databaseService = databaseService;
        }
        public async Task<SeedDataBaseHandlerOutput> Handle(SeedDataBaseHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling SeedDataBase business logic");
            SeedDataBaseHandlerOutput output = new SeedDataBaseHandlerOutput(request.CorrelationId());
            var stationstatus = new List<StationStatus>
            {
                new StationStatus
                {
                    Id = 1,
                    Status = "Available"
                },
                new StationStatus
                {
                    Id = 2,
                    Status = "Under Maintenance"
                }
            };
            await _databaseService.StationStatus.ExecuteDeleteAsync(cancellationToken);
            await _databaseService.StationStatus.AddRangeAsync(stationstatus);
            await _databaseService.DBSaveChangesAsync();


            var chargerstatus = new List<ChargerStatus>
            {
                new ChargerStatus
                {
                    Id = 1,
                    Status = "Available"
                },
                 new ChargerStatus
                {
                    Id = 2,
                    Status = "Occupied"
                },
                new ChargerStatus
                {
                    Id = 3,
                    Status = "Under Maintenance"
                }
            };
            await _databaseService.ChargerStatus.ExecuteDeleteAsync(cancellationToken);
            await _databaseService.ChargerStatus.AddRangeAsync(chargerstatus);
            await _databaseService.DBSaveChangesAsync();



            var chargertype = new List<ChargerType>
            {
                new ChargerType
                {
                    Id = 1,
                    Name = "Standard"
                },
                  new ChargerType
                {
                    Id = 2,
                    Name = "Fast"
                },
            };
            await _databaseService.ChargerType.ExecuteDeleteAsync(cancellationToken);
            await _databaseService.ChargerType.AddRangeAsync(chargertype);
            await _databaseService.DBSaveChangesAsync();


            var sysparam = new List<SysParam>
            {
                new SysParam
                {
                    Id = 1,
                    ParamName = "isAuthorizationRequired",
                    ParamValue = false

                }
            };
            await _databaseService.SysParam.ExecuteDeleteAsync(cancellationToken);
            await _databaseService.SysParam.AddRangeAsync(sysparam);
            await _databaseService.DBSaveChangesAsync();
            output.Message = "Database seeded successfully";
            return output;
        }
    }
}
