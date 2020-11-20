using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace smartfy.portal_api.domain.Entities
{
    public class Disk : Entity, IEntityTypeConfiguration<Disk>
    {
        public string Name { get; set; }
        public long LengthGB { get; set; }
        public DateTime DtLastCopy { get; set; }
        public Guid DockstationId { get; set; }
        public virtual Dockstation Dockstation { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public Disk() { }

        public Disk(Guid dockstationId,string name,long lengthGB)
        {
            DockstationId = dockstationId;
            Name = name;
            LengthGB = lengthGB;
        }

        public void Configure(EntityTypeBuilder<Disk> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.LengthGB).IsRequired();

            builder.HasOne(curr => curr.Dockstation)
                .WithMany(fk => fk.Disks)
                .HasForeignKey(f => f.DockstationId)
                .IsRequired();

            builder
                .HasMany(current => current.Files)
                .WithOne(foreign => foreign.Disk)
                .HasForeignKey(f => f.DiskId)
                .IsRequired();
        }
    }
}