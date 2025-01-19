using System.Net;
using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EV.Chargers.Application.Business.Order.Query;
using EV.Chargers.Core.Exceptions;
using Swashbuckle.AspNetCore.Annotations;

namespace EV.Chargers.WebApi.EndPoints.Order.Query
{
    public class GetOrderDataEndPoint : EndpointBaseAsync
    .WithRequest<GetOrderDataEndPointRequest>
    .WithActionResult<GetOrderDataEndPointResponse>
    {
        private readonly ILogger<GetOrderDataEndPoint> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public GetOrderDataEndPoint(ILogger<GetOrderDataEndPoint> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;

        }
        [Authorize]
        [ApiVersion("0.0")]
        [HttpGet(GetOrderDataEndPointRequest.Route)]
        [SwaggerOperation(Summary = "GetOrderData", Description = "GetOrderData ", OperationId = "EV.Chargers.WebApi.EndPoints.Order.Query.GetOrderData", Tags = new[] { "EV.Chargers.WebApi.EndPoints.Order" })]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetOrderDataEndPointResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ExceptionOutput))]
        public override async Task<ActionResult<GetOrderDataEndPointResponse>> HandleAsync([FromQuery] GetOrderDataEndPointRequest request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Information : Starting GetOrderData handling");
            var Appinput = _mapper.Map<GetOrderDataHandlerInput>(request);
            var result = await _mediator.Send(Appinput, cancellationToken);

            return Ok(_mapper.Map<GetOrderDataEndPointResponse>(result));
        }
    }
}
