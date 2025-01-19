﻿using System.Net;
using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EV.Chargers.Application.Business.Clients.Command;
using EV.Chargers.Core.Exceptions;
using Swashbuckle.AspNetCore.Annotations;

namespace EV.Chargers.WebApi.EndPoints.Client.Command
{
    public class AddNewClientEndPoint : EndpointBaseAsync
    .WithRequest<AddNewClientEndPointRequest>
    .WithActionResult<AddNewClientEndPointResponse>
    {
        private readonly ILogger<AddNewClientEndPoint> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public AddNewClientEndPoint(ILogger<AddNewClientEndPoint> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;

        }
        [Authorize]
        [ApiVersion("0.0")]
        [HttpPost(AddNewClientEndPointRequest.Route)]
        [SwaggerOperation(Summary = "AddNewClient", Description = "AddNewClient ", OperationId = "EV.Chargers.WebApi.EndPoints.Client.Command.AddNewClient", Tags = new[] { "EV.Chargers.WebApi.EndPoints.Client" })]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(AddNewClientEndPointResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ExceptionOutput))]
        public override async Task<ActionResult<AddNewClientEndPointResponse>> HandleAsync([FromBody] AddNewClientEndPointRequest request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Information : Starting AddNewClient handling");
            var Appinput = _mapper.Map<AddNewClientHandlerInput>(request);
            var result = await _mediator.Send(Appinput, cancellationToken);

            return Ok(_mapper.Map<AddNewClientEndPointResponse>(result));
        }
    }
}
