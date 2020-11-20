using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace smartfy.portal_api.domain.Entities
{
    public class Team : Entity, IEntityTypeConfiguration<Team>
    {
        public Team()
        {

        }
        public Team(string code, string plate, Guid areaId, Guid partnerId)
        {
            Code = code;
            Plate = plate;
            AreaId = areaId;
            PartnerId = partnerId;
        }

        public string Code { get; set; }
        public string Plate { get; set; }
        public virtual Area Area { get; set; }
        public Guid AreaId { get; set; }
        public virtual Partner Partner { get; set; }
        public Guid PartnerId { get; set; }
        public DateTime DtActivation { get; set; }
        public DateTime DtLastSeen { get; set; }
        public DateTime DtLastCopy { get; set; }
        public ICollection<Camera> Cameras { get; set; }

        public void Configure(EntityTypeBuilder<Team> builder)
        {
            builder.HasKey(c => c.Id);

            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Code).IsRequired().HasMaxLength(400);
            builder.Property(x => x.Plate).IsRequired().HasMaxLength(10);

            builder
                .HasMany(team => team.Cameras)
                .WithOne(camera => camera.Team)
                .HasForeignKey(f => f.TeamId)
                .IsRequired();

            builder.HasOne(team => team.Area)
                .WithMany(area => area.Teams)
                .HasForeignKey(f => f.AreaId)
                .IsRequired();

            builder.HasOne(team => team.Partner)
                .WithMany(area => area.Teams)
                .HasForeignKey(f => f.PartnerId)
                .IsRequired();
        }
    }
}
