using Ardalis.ApiEndpoints;
using AutoMapper;
using EV.Chargers.Application.Business.User.Command;
using EV.Chargers.Application.Contract;
using EV.Chargers.Core.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace EV.Chargers.WebApi.EndPoints.User.Command
{
    public class EnableAuthorizationEndPoint : EndpointBaseAsync
    .WithRequest<EnableAuthorizationEndPointRequest>
    .WithActionResult<EnableAuthorizationEndPointResponse>
    {
        private readonly ILogger<EnableAuthorizationEndPoint> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public EnableAuthorizationEndPoint(ILogger<EnableAuthorizationEndPoint> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;

        }
        //[Authorize]
        [ApiVersion("0.0")]
        [HttpPost(EnableAuthorizationEndPointRequest.Route)]
        [SwaggerOperation(Summary = "EnableAuthorization", Description = "EnableAuthorization ", OperationId = "EV.Chargers.WebApi.EndPoints.User.Command.EnableAuthorization", Tags = new[] { "EV.Chargers.WebApi.EndPoints.User.Command" })]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(EnableAuthorizationEndPointResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ExceptionOutput))]
        public override async Task<ActionResult<EnableAuthorizationEndPointResponse>> HandleAsync([FromBody]EnableAuthorizationEndPointRequest request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Information : Starting EnableAuthorization handling");
            var Appinput = _mapper.Map<EnableAuthorizationHandlerInput>(request);
            var result = await _mediator.Send(Appinput, cancellationToken);

            return Ok(_mapper.Map<EnableAuthorizationEndPointResponse>(result));
        }
    }
}
