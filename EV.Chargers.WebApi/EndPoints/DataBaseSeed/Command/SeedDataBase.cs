using Ardalis.ApiEndpoints;
using AutoMapper;
using EV.Chargers.Application.Business.DataBaseSeed.Command;
using EV.Chargers.Application.Contract;
using EV.Chargers.Core.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace EV.Chargers.WebApi.EndPoints.DataBaseSeed.Command
{
    public class SeedDataBaseEndPoint : EndpointBaseAsync
    .WithRequest<SeedDataBaseEndPointRequest>
    .WithActionResult<SeedDataBaseEndPointResponse>
    {
        private readonly ILogger<SeedDataBaseEndPoint> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public SeedDataBaseEndPoint(ILogger<SeedDataBaseEndPoint> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;

        }
        [Authorize]
        [ApiVersion("0.0")]
        [HttpPost(SeedDataBaseEndPointRequest.Route)]
        [SwaggerOperation(Summary = "SeedDataBase", Description = "SeedDataBase ", OperationId = "EV.Chargers.WebApi.EndPoints.DataBaseSeed.SeedDataBase", Tags = new[] { "EV.Chargers.WebApi.EndPoints.DataBaseSeed" })]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(SeedDataBaseEndPointResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ExceptionOutput))]
        public override async Task<ActionResult<SeedDataBaseEndPointResponse>> HandleAsync([FromBody]SeedDataBaseEndPointRequest request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Information : Starting SeedDataBase handling");
            var Appinput = _mapper.Map<SeedDataBaseHandlerInput>(request);
            var result = await _mediator.Send(Appinput, cancellationToken);

            return Ok(_mapper.Map<SeedDataBaseEndPointResponse>(result));
        }
    }
}
