using System.ComponentModel.DataAnnotations;
using EV.Chargers.Application.Business.ContractManagement.Query;
using EV.Chargers.Core.Messages;
using EV.Chargers.Domain.Entities;

namespace EV.Chargers.Application.Business.Clients.Query
{
    public class GetAllClientsHandlerOutput : BaseResponse
    {
        public GetAllClientsHandlerOutput() { }
        public GetAllClientsHandlerOutput(Guid correlationId) : base(correlationId) { }
        public List<ClientData> Clients { get; set; }
    }
    public class ClientData
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Data Country { get; set; }
        public Data ClientType { get; set; }
        public List<ContractDto> Contracts { get; set; }
    }
    public class Data
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
