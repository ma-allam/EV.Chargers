using Ardalis.ApiEndpoints;
using AutoMapper;
using EV.Chargers.Application.Business.Stations.Query;
using EV.Chargers.Application.Contract;
using EV.Chargers.Core.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace EV.Chargers.WebApi.EndPoints.Stations.Query
{
    public class GetStationsEndPoint : EndpointBaseAsync
    .WithRequest<GetStationsEndPointRequest>
    .WithActionResult<GetStationsEndPointResponse>
    {
        private readonly ILogger<GetStationsEndPoint> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public GetStationsEndPoint(ILogger<GetStationsEndPoint> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;

        }
        [Authorize]
        [ApiVersion("0.0")]
        [HttpGet(GetStationsEndPointRequest.Route)]
        [SwaggerOperation(Summary = "GetStations", Description = "GetStations ", OperationId = "EV.Chargers.WebApi.EndPoints.Stations.Query.GetStations", Tags = new[] { "EV.Chargers.WebApi.EndPoints.Stations" })]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetStationsEndPointResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ExceptionOutput))]
        public override async Task<ActionResult<GetStationsEndPointResponse>> HandleAsync([FromQuery]GetStationsEndPointRequest request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Information : Starting GetStations handling");
            var Appinput = _mapper.Map<GetStationsHandlerInput>(request);
            var result = await _mediator.Send(Appinput, cancellationToken);

            return Ok(_mapper.Map<GetStationsEndPointResponse>(result));
        }
    }
}
