﻿using System.Net;
using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EV.Chargers.Application.Business.User.Command;
using EV.Chargers.Application.Contract;
using EV.Chargers.Core.Exceptions;
using Swashbuckle.AspNetCore.Annotations;

namespace EV.Chargers.WebApi.EndPoints.User.Command
{
    public class AddRoleEndPoint : EndpointBaseAsync
    .WithRequest<AddRoleEndPointRequest>
    .WithActionResult<AddRoleEndPointResponse>
    {
        private readonly ILogger<AddRoleEndPoint> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public AddRoleEndPoint(ILogger<AddRoleEndPoint> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;

        }
        [Authorize]
        [NoCache]
        [ApiVersion("0.0")]
        [HttpPost(AddRoleEndPointRequest.Route)]
        [SwaggerOperation(Summary = "AddRole", Description = "AddRole ", OperationId = "EV.Chargers.WebApi.EndPoints.User.Command.AddRole", Tags = new[] { "EV.Chargers.WebApi.EndPoints.User" })]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(AddRoleEndPointResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ExceptionOutput))]
        public override async Task<ActionResult<AddRoleEndPointResponse>> HandleAsync([FromBody] AddRoleEndPointRequest request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Information : Starting AddRole handling");
            var Appinput = _mapper.Map<AddRoleHandlerInput>(request);
            var result = await _mediator.Send(Appinput, cancellationToken);

            return Ok(_mapper.Map<AddRoleEndPointResponse>(result));
        }
    }
}
