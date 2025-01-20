using Ardalis.ApiEndpoints;
using AutoMapper;
using EV.Chargers.Application.Business.User.Query;
using EV.Chargers.Application.Contract;
using EV.Chargers.Core.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace EV.Chargers.WebApi.EndPoints.User.Query
{
    public class GetAllClientsEndPoint : EndpointBaseAsync
    .WithRequest<GetAllClientsEndPointRequest>
    .WithActionResult<GetAllClientsEndPointResponse>
    {
        private readonly ILogger<GetAllClientsEndPoint> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public GetAllClientsEndPoint(ILogger<GetAllClientsEndPoint> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;

        }
        [Authorize(Roles = "Admin")]
        [ApiVersion("0.0")]
        [HttpGet(GetAllClientsEndPointRequest.Route)]
        [SwaggerOperation(Summary = "GetAllClients", Description = "GetAllClients ", OperationId = "EV.Chargers.WebApi.EndPoints.User.Query.GetAllClients", Tags = new[] { "EV.Chargers.WebApi.EndPoints.User.Query" })]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetAllClientsEndPointResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ExceptionOutput))]
        public override async Task<ActionResult<GetAllClientsEndPointResponse>> HandleAsync([FromQuery]GetAllClientsEndPointRequest request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Information : Starting GetAllClients handling");
            var Appinput = _mapper.Map<GetAllClientsHandlerInput>(request);
            var result = await _mediator.Send(Appinput, cancellationToken);

            return Ok(_mapper.Map<GetAllClientsEndPointResponse>(result));
        }
    }
}
