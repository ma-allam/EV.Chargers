using Ardalis.ApiEndpoints;
using AutoMapper;
using EV.Chargers.Application.Business.Chargers.Command;
using EV.Chargers.Application.Contract;
using EV.Chargers.Core.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace EV.Chargers.WebApi.EndPoints.Chargers.Command
{
    public class AddNewChargerEndPoint : EndpointBaseAsync
    .WithRequest<AddNewChargerEndPointRequest>
    .WithActionResult<AddNewChargerEndPointResponse>
    {
        private readonly ILogger<AddNewChargerEndPoint> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public AddNewChargerEndPoint(ILogger<AddNewChargerEndPoint> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;

        }
        [Authorize]
        [ApiVersion("0.0")]
        [HttpPost(AddNewChargerEndPointRequest.Route)]
        [SwaggerOperation(Summary = "AddNewCharger", Description = "AddNewCharger ", OperationId = "EV.Chargers.WebApi.EndPoints.Chargers.Command.AddNewCharger", Tags = new[] { "EV.Chargers.WebApi.EndPoints.Chargers" })]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(AddNewChargerEndPointResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ExceptionOutput))]
        public override async Task<ActionResult<AddNewChargerEndPointResponse>> HandleAsync([FromBody]AddNewChargerEndPointRequest request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Information : Starting AddNewCharger handling");
            var Appinput = _mapper.Map<AddNewChargerHandlerInput>(request);
            var result = await _mediator.Send(Appinput, cancellationToken);

            return Ok(_mapper.Map<AddNewChargerEndPointResponse>(result));
        }
    }
}
