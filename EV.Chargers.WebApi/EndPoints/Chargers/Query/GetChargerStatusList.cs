using Ardalis.ApiEndpoints;
using AutoMapper;
using EV.Chargers.Application.Business.Chargers.Query;
using EV.Chargers.Application.Contract;
using EV.Chargers.Core.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace EV.Chargers.WebApi.EndPoints.Chargers.Query
{
    public class GetChargerStatusListEndPoint : EndpointBaseAsync
    .WithRequest<GetChargerStatusListEndPointRequest>
    .WithActionResult<GetChargerStatusListEndPointResponse>
    {
        private readonly ILogger<GetChargerStatusListEndPoint> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public GetChargerStatusListEndPoint(ILogger<GetChargerStatusListEndPoint> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;

        }
        [Authorize]
        [ApiVersion("0.0")]
        [HttpGet(GetChargerStatusListEndPointRequest.Route)]
        [SwaggerOperation(Summary = "GetChargerStatusList", Description = "GetChargerStatusList ", OperationId = "EV.Chargers.WebApi.EndPoints.Chargers.Query.GetChargerStatusList", Tags = new[] { "EV.Chargers.WebApi.EndPoints.Chargers.Query" })]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetChargerStatusListEndPointResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ExceptionOutput))]
        public override async Task<ActionResult<GetChargerStatusListEndPointResponse>> HandleAsync([FromQuery]GetChargerStatusListEndPointRequest request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Information : Starting GetChargerStatusList handling");
            var Appinput = _mapper.Map<GetChargerStatusListHandlerInput>(request);
            var result = await _mediator.Send(Appinput, cancellationToken);

            return Ok(_mapper.Map<GetChargerStatusListEndPointResponse>(result));
        }
    }
}
