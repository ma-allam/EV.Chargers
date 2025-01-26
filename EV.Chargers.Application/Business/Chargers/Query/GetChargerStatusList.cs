using EV.Chargers.Application.Business.Stations.Query;
using EV.Chargers.Application.Contract;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EV.Chargers.Application.Business.Chargers.Query
{
    public class GetChargerStatusListHandler : IRequestHandler<GetChargerStatusListHandlerInput, GetChargerStatusListHandlerOutput>
    {
        private readonly IDataBaseService _databaseService;
        private readonly ILogger<GetChargerStatusListHandler> _logger;
        public GetChargerStatusListHandler(ILogger<GetChargerStatusListHandler> logger, IDataBaseService databaseService)
        {
            _logger = logger;
            _databaseService = databaseService;
        }
        public async Task<GetChargerStatusListHandlerOutput> Handle(GetChargerStatusListHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling GetChargerStatusList business logic");
            GetChargerStatusListHandlerOutput output = new GetChargerStatusListHandlerOutput(request.CorrelationId());
            output.ChargerStatusList = await _databaseService.ChargerStatus.Select(o => new ChargerStatusData
            {
                Id = o.Id,
                Name = o.Status
            }).ToListAsync(); 
            
            return output;
        }
    }
}
