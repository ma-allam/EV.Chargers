using EV.Chargers.Application.Business.Stations.Query;
using EV.Chargers.Application.Contract;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EV.Chargers.Application.Business.Chargers.Query
{
    public class GetChargerTypeListHandler : IRequestHandler<GetChargerTypeListHandlerInput, GetChargerTypeListHandlerOutput>
    {
        private readonly IDataBaseService _databaseService;
        private readonly ILogger<GetChargerTypeListHandler> _logger;
        public GetChargerTypeListHandler(ILogger<GetChargerTypeListHandler> logger, IDataBaseService databaseService)
        {
            _logger = logger;
            _databaseService = databaseService;
        }
        public async Task<GetChargerTypeListHandlerOutput> Handle(GetChargerTypeListHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling GetChargerTypeList business logic");
            GetChargerTypeListHandlerOutput output = new GetChargerTypeListHandlerOutput(request.CorrelationId());
            output.ChargerTypeList = await _databaseService.ChargerType.Select(o => new ChargerTypeData
            {
                Id = o.Id,
                Type = o.Name
            }).ToListAsync(); 
            return output;
        }
    }
}
