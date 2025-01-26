using EV.Chargers.Core.Messages;

namespace EV.Chargers.Application.Business.DataBaseSeed.Command
{
    public class SeedDataBaseHandlerOutput : BaseResponse
    {
        public SeedDataBaseHandlerOutput() { }
        public SeedDataBaseHandlerOutput(Guid correlationId) : base(correlationId) { }

        public string Message { get;  set; }
    }
}
