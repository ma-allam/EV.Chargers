﻿using System.Net;
using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EV.Chargers.Application.Business.ContractManagement.Command;
using EV.Chargers.Core.Exceptions;
using Swashbuckle.AspNetCore.Annotations;

namespace EV.Chargers.WebApi.EndPoints.ContractManagement.Command
{
    public class AddNewContractEndPoint : EndpointBaseAsync
    .WithRequest<AddNewContractEndPointRequest>
    .WithActionResult<AddNewContractEndPointResponse>
    {
        private readonly ILogger<AddNewContractEndPoint> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public AddNewContractEndPoint(ILogger<AddNewContractEndPoint> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;

        }
        [Authorize]
        [ApiVersion("0.0")]
        [HttpPost(AddNewContractEndPointRequest.Route)]
        [SwaggerOperation(Summary = "AddNewContract", Description = "AddNewContract ", OperationId = "EV.Chargers.WebApi.EndPoints.ContractManagement.Command.AddNewContract", Tags = new[] { "EV.Chargers.WebApi.EndPoints.ContractManagement" })]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(AddNewContractEndPointResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ExceptionOutput))]
        public override async Task<ActionResult<AddNewContractEndPointResponse>> HandleAsync([FromBody] AddNewContractEndPointRequest request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Information : Starting AddNewContract handling");
            var Appinput = _mapper.Map<AddNewContractHandlerInput>(request);
            var result = await _mediator.Send(Appinput, cancellationToken);

            return Ok(_mapper.Map<AddNewContractEndPointResponse>(result));
        }
    }
}
