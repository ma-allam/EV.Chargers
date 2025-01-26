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
    public class GetChargersEndPoint : EndpointBaseAsync
    .WithRequest<GetChargersEndPointRequest>
    .WithActionResult<GetChargersEndPointResponse>
    {
        private readonly ILogger<GetChargersEndPoint> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public GetChargersEndPoint(ILogger<GetChargersEndPoint> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;

        }
        [Authorize]
        [ApiVersion("0.0")]
        [HttpGet(GetChargersEndPointRequest.Route)]
        [SwaggerOperation(Summary = "GetChargers", Description = "GetChargers ", OperationId = "EV.Chargers.WebApi.EndPoints.Chargers.Query.GetChargers", Tags = new[] { "EV.Chargers.WebApi.EndPoints.Chargers" })]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetChargersEndPointResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ExceptionOutput))]
        public override async Task<ActionResult<GetChargersEndPointResponse>> HandleAsync([FromQuery]GetChargersEndPointRequest request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Information : Starting GetChargers handling");
            var Appinput = _mapper.Map<GetChargersHandlerInput>(request);
            var result = await _mediator.Send(Appinput, cancellationToken);

            return Ok(_mapper.Map<GetChargersEndPointResponse>(result));
        }
    }
}
