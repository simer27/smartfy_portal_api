using AutoMapper;
using System;

namespace smartfy.portal_api.services.WebAPI.Mappings
{
    public class ConfigureIMapper
    {
        public static IMapper GetMapper()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new DtOToEntityProfile());
            });

            return config.CreateMapper();
        }
    }

    public class AutoMapperFixture : ConfigureIMapper, IDisposable
    {
        public void Dispose() { }
    }
}
