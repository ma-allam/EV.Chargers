
using AutoMapper;
using EV.Chargers.Application.Business.DataBaseSeed.Command;

namespace EV.Chargers.WebApi.EndPoints.DataBaseSeed.Command
{
    public class SeedDataBaseMapper : Profile
    {
        public SeedDataBaseMapper()
        {
            CreateMap<SeedDataBaseEndPointRequest, SeedDataBaseHandlerInput>()
                .ConstructUsing(src => new SeedDataBaseHandlerInput(src.CorrelationId()));
            CreateMap<SeedDataBaseHandlerOutput, SeedDataBaseEndPointResponse>()
               .ConstructUsing(src => new SeedDataBaseEndPointResponse(src.CorrelationId()));
        }

    }
}
