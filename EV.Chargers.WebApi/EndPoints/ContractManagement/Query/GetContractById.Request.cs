using System.ComponentModel.DataAnnotations;
using EV.Chargers.Core.Messages;

namespace EV.Chargers.WebApi.EndPoints.ContractManagement.Query
{
    public class GetContractByIdEndPointRequest : BaseRequest
    {
        public const string Route = "/api/ContractManagement/v{version:apiVersion}/GetContractById/";
        [Required]
        public int ContractId { get; set; }
    }
}
