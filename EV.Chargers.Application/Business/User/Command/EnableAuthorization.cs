using EV.Chargers.Application.Contract;
using EV.Chargers.Core.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace EV.Chargers.Application.Business.User.Command
{
    public class EnableAuthorizationHandler : IRequestHandler<EnableAuthorizationHandlerInput, EnableAuthorizationHandlerOutput>
    {
        private readonly IDataBaseService _databaseService;
        private readonly ILogger<EnableAuthorizationHandler> _logger;
        public EnableAuthorizationHandler(ILogger<EnableAuthorizationHandler> logger, IDataBaseService databaseService)
        {
            _logger = logger;
            _databaseService = databaseService;
        }
        public async Task<EnableAuthorizationHandlerOutput> Handle(EnableAuthorizationHandlerInput request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Handling EnableAuthorization business logic");
            EnableAuthorizationHandlerOutput output = new EnableAuthorizationHandlerOutput(request.CorrelationId());
            var sysparam=await _databaseService.SysParam.FirstOrDefaultAsync(o=>o.Id == 1);
            if (sysparam != null)
            {
                sysparam.ParamValue = request.EnableAuthorization;
                await _databaseService.DBSaveChangesAsync();
                output.IsAuthorizationEnabled = sysparam.ParamValue;
                output.Message = "Authentication Updated successfully";
            }
            else
            {
                throw new WebApiException("System parameter not found");
            }
            return output;
        }
    }
}
