using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using EV.Chargers.Application.Business.ContractManagement.Command;
using MediatR;
using NetTopologySuite.Geometries;
using EV.Chargers.Core.Messages;
using EV.Chargers.Domain.Entities;

namespace EV.Chargers.Application.Business.Order.Command
{
    public class AddNewOrderHandlerInput : BaseRequest, IRequest<AddNewOrderHandlerOutput>
    {
        public AddNewOrderHandlerInput() { }
        public AddNewOrderHandlerInput(Guid correlationId) : base(correlationId) { }


        public int ClientId { get; set; }

        public int ContractId { get; set; }

        //public DateOnly OrderDate { get; set; }

        public int ContractImageResolutionId { get; set; }

        public int ContractImageModeId { get; set; }

        public int ContractOrderPirorityId { get; set; }

        public double ShootingAngle { get; set; }

        public double PredictedConsumedCredit { get; set; }

        public double ActualConsumedCredit { get; set; }

        public double Discount { get; set; }

        public string? Notes { get; set; }

        public double CompeletedPercentage { get; set; }

        public double TotalOrderAreaInKm { get; set; }

        public Geometry? OrderGeometry { get; set; } = null!;

        public DateOnly DueDate { get; set; }

        public int OrderStatusId { get; set; }
        public List<int> Services { get; set; }



    }

}
