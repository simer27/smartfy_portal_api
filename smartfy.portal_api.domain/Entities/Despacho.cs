using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace smartfy.portal_api.domain.Entities
{
    public class Despacho : Entity, IEntityTypeConfiguration<Despacho>
    {
        public Guid ClienteId { get; set; }
        public Guid ProdutoId { get; set; }
        public DateTime DtEnvio { get; set; }
        public DateTime DtEntrega { get; set; }
        public DateTime DtRecebimento { get; set; }
        public bool IsDelivered { get; set; }

        public Despacho() { }
        
        public void Configure(EntityTypeBuilder<Despacho> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).IsRequired();
        }
    }
}