using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.User.Query
{
    public class GetAllClientsHandlerOutput : BaseResponse
    {
        public GetAllClientsHandlerOutput() { }
        public GetAllClientsHandlerOutput(Guid correlationId) : base(correlationId) { }
        public List<Client> Clients { get; set; }
    }
    public class Client
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
    }
}
