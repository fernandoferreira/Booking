using AutoMapper;

namespace FF.MinhaReserva.Application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(i =>
            {
                i.AddProfile<DomainToViewModelMappingProfile>();
                //i.AddProfile<ViewModelToDomainMappingProfile>();
            });
        }
    }
}
