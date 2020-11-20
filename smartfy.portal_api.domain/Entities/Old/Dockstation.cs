using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace smartfy.portal_api.domain.Entities
{
    public class Dockstation : Entity, IEntityTypeConfiguration<Dockstation>
    {
        public string Code { get; set; }
        public long LastTotalLength { get; set; }
        public long LastUsageLength { get; set; }
        public DateTime DtActivation { get; set; }
        public DateTime DtLastSeen { get; set; }
        public DateTime DtLastCopy { get; set; }
        public virtual ICollection<Disk> Disks { get; set; }
        public virtual Partner Partner { get; set; }
        public Guid PartnerId { get; set; }
        public Dockstation() { }
        public Dockstation(Guid partnerId,string code)
        {
            PartnerId = partnerId;
            Code = code;
            DtActivation = DateTime.Now;
            DtLastSeen = DateTime.Now;
        }
        public void Configure(EntityTypeBuilder<Dockstation> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Code).IsRequired();

            builder
                .HasMany(current => current.Disks)
                .WithOne(foreign => foreign.Dockstation)
                .HasForeignKey(f => f.DockstationId)
                .IsRequired();
        }

    }
}