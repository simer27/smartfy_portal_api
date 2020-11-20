using AutoMapper;

namespace smartfy.portal_api.application.AutoMapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return
                new MapperConfiguration(config =>
                {
                    config.AddProfile(new DomainToViewModelMappingProfile());
                    config.AddProfile(new ViewModelToDomainMappingProfile());
                });
        }
    }
}
