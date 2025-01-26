using EV.Chargers.Application.Contract;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EV.Chargers.Application.Business.Stations.Query
{
    public class GetStationStatusListHandler : IRequestHandler<GetStationStatusListHandlerInput, GetStationStatusListHandlerOutput>
    {
        private readonly IDataBaseService _databaseService;
        private readonly ILogger<GetStationStatusListHandler> _logger;
        public GetStationStatusListHandler(ILogger<GetStationStatusListHandler> logger, IDataBaseService databaseService)
        {
            _logger = logger;
            _databaseService = databaseService;
        }
        public async Task<GetStationStatusListHandlerOutput> Handle(GetStationStatusListHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling GetStationStatusList business logic");
            GetStationStatusListHandlerOutput output = new GetStationStatusListHandlerOutput(request.CorrelationId());
            output.StationStatusList = await _databaseService.StationStatus.Select(o=>new StationStatusData
            { 
                Id=o.Id,
                Name=o.Status
            }).ToListAsync();
            return output;
        }
    }
}
