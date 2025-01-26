using Ardalis.ApiEndpoints;
using AutoMapper;
using EV.Chargers.Application.Business.Stations.Command;
using EV.Chargers.Application.Contract;
using EV.Chargers.Core.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace EV.Chargers.WebApi.EndPoints.Stations.Command
{
    public class AddNewStationEndPoint : EndpointBaseAsync
    .WithRequest<AddNewStationEndPointRequest>
    .WithActionResult<AddNewStationEndPointResponse>
    {
        private readonly ILogger<AddNewStationEndPoint> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public AddNewStationEndPoint(ILogger<AddNewStationEndPoint> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;

        }
        [Authorize]
        [ApiVersion("0.0")]
        [HttpPost(AddNewStationEndPointRequest.Route)]
        [SwaggerOperation(Summary = "AddNewStation", Description = "AddNewStation ", OperationId = "EV.Chargers.WebApi.EndPoints.Stations.Command.AddNewStation", Tags = new[] { "EV.Chargers.WebApi.EndPoints.Stations" })]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(AddNewStationEndPointResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ExceptionOutput))]
        public override async Task<ActionResult<AddNewStationEndPointResponse>> HandleAsync([FromBody]AddNewStationEndPointRequest request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Information : Starting AddNewStation handling");
            var Appinput = _mapper.Map<AddNewStationHandlerInput>(request);
            var result = await _mediator.Send(Appinput, cancellationToken);

            return Ok(_mapper.Map<AddNewStationEndPointResponse>(result));
        }
    }
}
