using System;
using System.Linq;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using smartfy.portal_api.domain.Entities;
using smartfy.portal_api.Infra.CrossCutting.Identity.Entities;


namespace smartfy.portal_api.Infra.CrossCutting.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        private readonly IHostingEnvironment _env;

        public DbSet<Partner> Partners { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Camera> Cameras { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Area> Areas { get; set; }
        public DbSet<Dockstation> Dockstations { get; set; }
        public DbSet<Disk> Disks { get; set; }
        public DbSet<File> Files { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            new Partner().Configure(modelBuilder.Entity<Partner>());
            new Area().Configure(modelBuilder.Entity<Area>());
            new Camera().Configure(modelBuilder.Entity<Camera>());
            new Region(String.Empty).Configure(modelBuilder.Entity<Region>());
            new Team(string.Empty,string.Empty,Guid.Empty,Guid.Empty).Configure(modelBuilder.Entity<Team>());
            new File().Configure(modelBuilder.Entity<File>());
            new Dockstation().Configure(modelBuilder.Entity<Dockstation>());
            new Disk().Configure(modelBuilder.Entity<Disk>());
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IHostingEnvironment env) : base(options)
        {
            _env = env;
        }

        public ApplicationDbContext() { }
    }

    public static class ModelBuilderExtensions
    {
        public static void ApplyAllConfigurations(this ModelBuilder modelBuilder)
        {
            var configurations = Assembly.GetExecutingAssembly().DefinedTypes.Where(t =>
                    t.ImplementedInterfaces.Any(i =>
                        i.IsGenericType &&
                        i.Name.Equals(typeof(IEntityTypeConfiguration<>).Name,
                            StringComparison.InvariantCultureIgnoreCase)
                    ) &&
                    t.IsClass &&
                    !t.IsAbstract &&
                    !t.IsNested)
                .ToList();

            foreach (var configuration in configurations)
            {
                try
                {
                    var entityType = configuration.BaseType.GenericTypeArguments.SingleOrDefault(t => t.IsClass);
                    var applyConfigMethod = typeof(ModelBuilder).GetMethod("Configure");
                    var applyConfigGenericMethod = applyConfigMethod.MakeGenericMethod(entityType);
                    applyConfigGenericMethod.Invoke(modelBuilder, new object[] { Activator.CreateInstance(configuration) });
                }
                catch (Exception e)
                {
                }
            }
        }

        //new Partner().Configure(modelBuilder.Entity<Partner>());
    }
}
