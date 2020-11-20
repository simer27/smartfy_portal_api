using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace smartfy.portal_api.domain.Entities
{
    public class Camera : Entity, IEntityTypeConfiguration<Camera>
    {
        public Camera() { }
        public Camera(
            string code, 
            string model, 
            string manufacturer, 
            Guid teamId)
        {
            Code = code;
            Model = model;
            Manufacturer = manufacturer;
            TeamId = teamId;    
        }

        public string Code { get; set; }
        public string Model { get; set; }
        public long LastTotalLength { get; set; }
        public long LastUsageLength { get; set; }
        public string Manufacturer { get; set; }
        public bool InOperation { get; set; }
        public DateTime DtActivation { get; set; }
        public DateTime DtLastSeen { get; set; }
        public DateTime DtLastCopy { get; set; }
        public virtual Team Team { get; set; }
        public virtual Guid TeamId { get; set; }
        public virtual ICollection<File> Files { get; set; }

        public void Configure(EntityTypeBuilder<Camera> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Model).IsRequired();
            builder.Property(x => x.Manufacturer).IsRequired();

            builder.Property(x => x.Id).IsRequired();
            builder.HasOne(camera => camera.Team)
                .WithMany(team => team.Cameras)
                .HasForeignKey(f => f.TeamId)
                .IsRequired();
        }
    }
}