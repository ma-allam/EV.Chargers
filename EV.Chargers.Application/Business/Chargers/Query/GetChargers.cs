using EV.Chargers.Application.Contract;
using MediatR;
using Microsoft.Extensions.Logging;

namespace EV.Chargers.Application.Business.Chargers.Query
{
    public class GetChargersHandler : IRequestHandler<GetChargersHandlerInput, GetChargersHandlerOutput>
    {
        private readonly IDataBaseService _databaseService;
        private readonly ILogger<GetChargersHandler> _logger;
        public GetChargersHandler(ILogger<GetChargersHandler> logger, IDataBaseService databaseService)
        {
            _logger = logger;
            _databaseService = databaseService;
        }
        public async Task<GetChargersHandlerOutput> Handle(GetChargersHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling GetChargers business logic");
            GetChargersHandlerOutput output = new GetChargersHandlerOutput(request.CorrelationId());
            var query = _databaseService.Charger.AsQueryable();

            // Apply filters
            if (request.StationId.HasValue)
                query = query.Where(c => c.StationId == request.StationId);

            if (request.ChargerTypeId.HasValue)
                query = query.Where(c => c.ChargerTypeId == request.ChargerTypeId);

            if (request.StatusId.HasValue)
                query = query.Where(c => c.StatusId == request.StatusId);

            // Execute query and map results
           output.Chargers = await Task.FromResult(query.Select(c => new ChargerData
            {
                Id = c.Id,
                StationId = c.StationId,
                ChargerTypeId = c.ChargerTypeId,
                StatusId = c.StatusId
            }).ToList());

     
            return output;
        }
    }
}
