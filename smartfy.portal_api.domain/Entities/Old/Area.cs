using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace smartfy.portal_api.domain.Entities
{
    public class Area : Entity, IEntityTypeConfiguration<Area>
    {
        public string Name { get; set; }
        public virtual ICollection<Team> Teams { get; set; }

        public Area() { }

        public Area(string name)
        {
            Name = name;
        }
        public void Configure(EntityTypeBuilder<Area> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).IsRequired();

            builder.HasMany(area => area.Teams)
                .WithOne(team => team.Area)
                .HasForeignKey(f => f.AreaId)
                .IsRequired();
        }
    }
}