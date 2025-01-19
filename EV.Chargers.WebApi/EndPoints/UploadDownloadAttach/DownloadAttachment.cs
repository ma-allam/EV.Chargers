using System.Net;
using Ardalis.ApiEndpoints;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using EV.Chargers.Application.Business.UploadDownloadAttach;
using EV.Chargers.Core.Exceptions;
using Swashbuckle.AspNetCore.Annotations;

namespace EV.Chargers.WebApi.EndPoints.UploadDownloadAttach
{
    public class DownloadAttachmentEndPoint : EndpointBaseAsync
    .WithRequest<DownloadAttachmentEndPointRequest>
    .WithActionResult<DownloadAttachmentEndPointResponse>
    {
        private readonly ILogger<DownloadAttachmentEndPoint> _logger;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        public DownloadAttachmentEndPoint(ILogger<DownloadAttachmentEndPoint> logger, IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _logger = logger;
            _mapper = mapper;

        }
        [Authorize]
        [ApiVersion("0.0")]
        [HttpGet(DownloadAttachmentEndPointRequest.Route)]
        [SwaggerOperation(Summary = "DownloadAttachment", Description = "DownloadAttachment ", OperationId = "EV.Chargers.WebApi.EndPoints.UploadDownloadAttach.DownloadAttachment", Tags = new[] { "EV.Chargers.WebApi.EndPoints.UploadDownloadAttach" })]
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(DownloadAttachmentEndPointResponse))]
        [SwaggerResponse((int)HttpStatusCode.BadRequest, Type = typeof(ExceptionOutput))]
        public override async Task<ActionResult<DownloadAttachmentEndPointResponse>> HandleAsync([FromQuery] DownloadAttachmentEndPointRequest request, CancellationToken cancellationToken = default)
        {
            _logger.LogInformation("Information : Starting DownloadAttachment handling");
            var Appinput = _mapper.Map<DownloadAttachmentHandlerInput>(request);
            var result = await _mediator.Send(Appinput, cancellationToken);
            return Ok(_mapper.Map<DownloadAttachmentEndPointResponse>(result));
        }
    }
}
