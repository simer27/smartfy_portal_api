using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace smartfy.portal_api.domain.Entities
{
    public class Produto : Entity, IEntityTypeConfiguration<Produto>
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }     

        public Produto() { }

        
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).IsRequired();
        }
    }
}