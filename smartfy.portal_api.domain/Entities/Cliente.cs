using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace smartfy.portal_api.domain.Entities
{
    public class Cliente : Entity, IEntityTypeConfiguration<Cliente>
    {
        public string Name { get; set; }
        public string CPF { get; set; }
        public string Address { get; set; }

        public Cliente() { }

        
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).IsRequired();
        }
    }
}