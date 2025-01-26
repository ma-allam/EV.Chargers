﻿using Ardalis.ApiEndpoints;
using AutoMapper;
using EV.Chargers.Application.Business.Stations.Query;
using EV.Chargers.Application.Contract;
using EV.Chargers.Core.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace EV.Chargers.WebApi.EndPoints.Stations.Query
{
    public class GetStationStatusListEndPoint : EndpointBaseAsync
    .WithRequest<GetStationStatusListEndPointRequest>
    .WithActionResult<GetStationStatusListEndPointResponse>
    {
        private readonly ILogger<GetStationStatusListEndPoint> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public GetStationStatusListEndPoint(ILogger<GetStationStatusListEndPoint> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;

        }
        [Authorize]
        [ApiVersion("0.0")]
        [HttpGet(GetStationStatusListEndPointRequest.Route)]
        [SwaggerOperation(Summary = "GetStationStatusList", Description = "GetStationStatusList ", OperationId = "EV.Chargers.WebApi.EndPoints.Stations.Query.GetStationStatusList", Tags = new[] { "EV.Chargers.WebApi.EndPoints.Stations" })]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(GetStationStatusListEndPointResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ExceptionOutput))]
        public override async Task<ActionResult<GetStationStatusListEndPointResponse>> HandleAsync([FromQuery]GetStationStatusListEndPointRequest request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Information : Starting GetStationStatusList handling");
            var Appinput = _mapper.Map<GetStationStatusListHandlerInput>(request);
            var result = await _mediator.Send(Appinput, cancellationToken);

            return Ok(_mapper.Map<GetStationStatusListEndPointResponse>(result));
        }
    }
}
