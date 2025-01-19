using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.ContractManagement.Query
{
    public class GetAllContractsEndPointRequest : BaseRequest
    {
        public const string Route = "/api/ContractManagement/v{version:apiVersion}/GetAllContracts/";

    }
}
