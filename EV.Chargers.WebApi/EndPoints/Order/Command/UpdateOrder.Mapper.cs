
using AutoMapper;
using EV.Chargers.Application.Business.Order.Command;

namespace EV.Chargers.WebApi.EndPoints.Order.Command
{
    public class UpdateOrderMapper : Profile
    {
        public UpdateOrderMapper()
        {
            CreateMap<UpdateOrderEndPointRequest, UpdateOrderHandlerInput>()
                .ConstructUsing(src => new UpdateOrderHandlerInput(src.CorrelationId()));
            CreateMap<UpdateOrderHandlerOutput, UpdateOrderEndPointResponse>()
               .ConstructUsing(src => new UpdateOrderEndPointResponse(src.CorrelationId()));
        }

    }
}
