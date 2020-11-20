using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace smartfy.portal_api.domain.Entities
{
    public class Partner : Entity, IEntityTypeConfiguration<Partner>
    {
        public Partner() {}
        public Partner(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public virtual ICollection<Team> Teams { get; set; }
        public void Configure(EntityTypeBuilder<Partner> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(400);
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Contact).IsRequired(false);
            builder
                .HasMany(team => team.Teams)
                .WithOne(partner => partner.Partner)
                .HasForeignKey(f => f.PartnerId)
                .IsRequired();
        }
    }

    public class PartnerDto
    {
        public string Name { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
    }
}
