using System.Net;
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
    public class RefreshTokenEndPoint : EndpointBaseAsync
    .WithRequest<RefreshTokenEndPointRequest>
    .WithActionResult<RefreshTokenEndPointResponse>
    {
        private readonly ILogger<RefreshTokenEndPoint> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public RefreshTokenEndPoint(ILogger<RefreshTokenEndPoint> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;

        }
        [Authorize]
        [NoCache]
        [ApiVersion("0.0")]
        [HttpPost(RefreshTokenEndPointRequest.Route)]
        [SwaggerOperation(Summary = "RefreshToken", Description = "RefreshToken ", OperationId = "EV.Chargers.WebApi.EndPoints.User.Command.RefreshToken", Tags = new[] { "EV.Chargers.WebApi.EndPoints.User" })]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(RefreshTokenEndPointResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ExceptionOutput))]
        public override async Task<ActionResult<RefreshTokenEndPointResponse>> HandleAsync([FromBody] RefreshTokenEndPointRequest request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Information : Starting RefreshToken handling");
            var Appinput = _mapper.Map<RefreshTokenHandlerInput>(request);
            var result = await _mediator.Send(Appinput, cancellationToken);

            return Ok(_mapper.Map<RefreshTokenEndPointResponse>(result));
        }
    }
}
