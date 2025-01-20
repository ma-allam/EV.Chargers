using EV.Chargers.Application.Contract;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EV.Chargers.Application.Business.User.Query
{
    public class GetAllClientsHandler : IRequestHandler<GetAllClientsHandlerInput, GetAllClientsHandlerOutput>
    {
        private readonly IDataBaseService _databaseService;
        private readonly ILogger<GetAllClientsHandler> _logger;
        public GetAllClientsHandler(ILogger<GetAllClientsHandler> logger, IDataBaseService databaseService)
        {
            _logger = logger;
            _databaseService = databaseService;
        }
        public async Task<GetAllClientsHandlerOutput> Handle(GetAllClientsHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling GetAllClients business logic");
            GetAllClientsHandlerOutput output = new GetAllClientsHandlerOutput(request.CorrelationId());
            output.Clients = await _databaseService.UserData.Select(o=>new Client
            {
                Name = o.UserName
            }).ToListAsync();
            return output;
        }
    }
}
