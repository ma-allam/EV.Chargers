using EV.Chargers.Core.Messages;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace EV.Chargers.Application.Business.Stations.Query
{
    public class GetStationStatusListHandlerInput : BaseRequest, IRequest<GetStationStatusListHandlerOutput>
    {
        public GetStationStatusListHandlerInput() { }
        public GetStationStatusListHandlerInput(Guid correlationId) : base(correlationId) { }
    }
}
