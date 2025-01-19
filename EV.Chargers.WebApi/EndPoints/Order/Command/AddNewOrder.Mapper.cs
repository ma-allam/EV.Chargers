
using AutoMapper;
using EV.Chargers.Application.Business.Order.Command;

namespace EV.Chargers.WebApi.EndPoints.Order.Command
{
    public class AddNewOrderMapper : Profile
    {
        public AddNewOrderMapper()
        {
            CreateMap<AddNewOrderEndPointRequest, AddNewOrderHandlerInput>()
                .ConstructUsing(src => new AddNewOrderHandlerInput(src.CorrelationId()));
            CreateMap<AddNewOrderHandlerOutput, AddNewOrderEndPointResponse>()
               .ConstructUsing(src => new AddNewOrderEndPointResponse(src.CorrelationId()));
        }

    }
}
