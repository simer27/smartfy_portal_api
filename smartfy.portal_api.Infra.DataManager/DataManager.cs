using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using smartfy.portal_api.Infra.CrossCutting.Identity.Data;
using System;
using System.IO;

namespace smartfy.portal_api.Infra.DataManager
{
    public abstract class DataManager
    {
        protected readonly ApplicationDbContext _dbContext;

        protected readonly IConfigurationRoot Configuration;

        public DataManager()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Path.Combine(AppContext.BaseDirectory))
                .AddJsonFile("appsettings.json", optional: true);

            Configuration = builder.Build();

            var identityContextOptions = new DbContextOptionsBuilder<ApplicationDbContext>();
            identityContextOptions.UseNpgsql(Configuration.GetConnectionString("DefaultConnection"));

            _dbContext = new ApplicationDbContext(identityContextOptions.Options,null);

            Seed();
        }

        public abstract void Seed();
    }
}
