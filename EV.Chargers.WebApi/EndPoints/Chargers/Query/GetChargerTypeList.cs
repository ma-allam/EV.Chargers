using Ardalis.ApiEndpoints;
using AutoMapper;
using EV.Chargers.Application.Business.Chargers.Query;
using EV.Chargers.Application.Contract;
using EV.Chargers.Core.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace EV.Chargers.WebApi.EndPoints.Chargers.Query
{
    public class GetChargerTypeListEndPoint : EndpointBaseAsync
    .WithRequest<GetChargerTypeListEndPointRequest>
    .WithActionResult<GetChargerTypeListEndPointResponse>
    {
        private readonly ILogger<GetChargerTypeListEndPoint> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public GetChargerTypeListEndPoint(ILogger<GetChargerTypeListEndPoint> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;

        }
        [Authorize]
        [ApiVersion("0.0")]
        [HttpGet(GetChargerTypeListEndPointRequest.Route)]
        [SwaggerOperation(Summary = "GetChargerTypeList", Description = "GetChargerTypeList ", OperationId = "EV.Chargers.WebApi.EndPoints.Chargers.Query.GetChargerTypeList", Tags = new[] { "EV.Chargers.WebApi.EndPoints.Chargers" })]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetChargerTypeListEndPointResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ExceptionOutput))]
        public override async Task<ActionResult<GetChargerTypeListEndPointResponse>> HandleAsync([FromQuery]GetChargerTypeListEndPointRequest request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Information : Starting GetChargerTypeList handling");
            var Appinput = _mapper.Map<GetChargerTypeListHandlerInput>(request);
            var result = await _mediator.Send(Appinput, cancellationToken);

            return Ok(_mapper.Map<GetChargerTypeListEndPointResponse>(result));
        }
    }
}
