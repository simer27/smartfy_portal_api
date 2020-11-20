using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;
using smartfy.portal_api.domain.Interfaces;
using smartfy.portal_api.Infra.CrossCutting.Identity.Authorization;
using smartfy.portal_api.Infra.CrossCutting.Identity.Entities;
using smartfy.portal_api.Infra.CrossCutting.Identity.Services;

namespace smartfy.portal_api.Infra.CrossCutting.IoC
{
    public class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Infra - Identity Services
            services.AddTransient<IEmailSender, AuthEmailMessageSender>();
            services.AddTransient<ISmsSender, AuthSMSMessageSender>();

            // ASP.NET Authorization Polices
            services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Infra - Identity
            services.AddScoped<IUser, AspNetUser>();
        }
    }
}
