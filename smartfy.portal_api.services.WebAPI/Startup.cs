using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.IdentityModel.Tokens;
using smartfy.portal_api.Infra.CrossCutting.Identity.Data;
using smartfy.portal_api.Infra.CrossCutting.Identity.Entities;
using smartfy.portal_api.Infra.CrossCutting.IoC;
using smartfy.portal_api.services.WebAPI.Mappings;
using Swashbuckle.AspNetCore.Swagger;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace smartfy.portal_api.services.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<ApplicationUser, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            //Configure JWT
            #region JWT Configuration
            var jwtSection = Configuration.GetSection("JWTSetup");
            services.Configure<JWTSetup>(jwtSection);

            var jwtSetup = jwtSection.Get<JWTSetup>();
            var key = Encoding.ASCII.GetBytes(jwtSetup.Secret);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = jwtSetup.ValidOn,
                    ValidIssuer = jwtSetup.Emiter
                };
            });
            #endregion

            //Configurando o serviço de documentação do Swagger
            #region Config Swagger
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1",
                        new Info
                        {
                            Title = "Portal API",
                            Version = "v1",
                            Description = "API REST criada para uso do portal",
                            Contact = new Contact
                            {
                                Name = "Smartfy",
                                Url = "https://smartfy.io",
                                Email = "corp@smartfy.net.br"
                            }
                        });

                    // Swagger 2.+ support
                    var security = new Dictionary<string, IEnumerable<string>>
                    {
                        {"Bearer", new string[] { }},
                    };

                    c.AddSecurityDefinition("Bearer", new ApiKeyScheme
                    {
                        Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                        Name = "Authorization",
                        In = "header",
                        Type = "apiKey"
                    });

                    c.AddSecurityRequirement(security);

                    string caminhoAplicacao =
                        PlatformServices.Default.Application.ApplicationBasePath;
                    string nomeAplicacao =
                        PlatformServices.Default.Application.ApplicationName;
                    string caminhoXmlDoc =
                        Path.Combine(caminhoAplicacao, $"{nomeAplicacao}.xml");

                    c.IncludeXmlComments(caminhoXmlDoc);
                });
            #endregion
            
            // .NET Native DI Abstraction
            RegisterServices(services);

            // Configurando AutoMapper
            services.AddSingleton(ConfigureIMapper.GetMapper());
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "Portal API");
            });
            app.UseMvc();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
