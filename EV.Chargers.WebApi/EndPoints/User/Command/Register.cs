﻿using System.Net;
using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EV.Chargers.Application.Business.User.Command;
using EV.Chargers.Application.Contract;
using Swashbuckle.AspNetCore.Annotations;

namespace EV.Chargers.WebApi.EndPoints.User.Command
{
    public class RegisterEndPoint : EndpointBaseAsync
    .WithRequest<RegisterEndPointRequest>
    .WithActionResult<RegisterEndPointResponse>
    {
        private readonly ILogger<RegisterEndPoint> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public RegisterEndPoint(ILogger<RegisterEndPoint> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;

        }
        //[Authorize]
        [NoCache]
        [ApiVersion("0.0")]
        [HttpPost(RegisterEndPointRequest.Route)]
        [SwaggerOperation(Summary = "Register", Description = "Register ", OperationId = "EV.Chargers.WebApi.EndPoints.User.Command.Register", Tags = new[] { "EV.Chargers.WebApi.EndPoints.User" })]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(RegisterEndPointResponse))]
        //[SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ExceptionOutput))]
        public override async Task<ActionResult<RegisterEndPointResponse>> HandleAsync([FromBody] RegisterEndPointRequest request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Information : Starting Register handling");
            var Appinput = _mapper.Map<RegisterHandlerInput>(request);
            var result = await _mediator.Send(Appinput, cancellationToken);

            return Ok(_mapper.Map<RegisterEndPointResponse>(result));
        }
    }
}
