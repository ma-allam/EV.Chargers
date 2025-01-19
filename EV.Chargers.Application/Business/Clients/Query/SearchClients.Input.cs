﻿using MediatR;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.Clients.Query
{
    public class SearchClientsHandlerInput : BaseRequest, IRequest<SearchClientsHandlerOutput>
    {
        public SearchClientsHandlerInput() { }
        public SearchClientsHandlerInput(Guid correlationId) : base(correlationId) { }
        public string? Name { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
        public int? ClientType { get; set; }
        public int? CountryId { get; set; }
    }
}
