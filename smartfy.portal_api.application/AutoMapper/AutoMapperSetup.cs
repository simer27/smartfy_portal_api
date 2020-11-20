
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using smartfy.portal_api.application.AutoMapper;
using System;

namespace smartfy.portal_api.application.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper();

            AutoMapperConfig.RegisterMappings();
        }
    }
}
