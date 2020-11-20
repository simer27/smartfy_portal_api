using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace smartfy.portal_api.domain.Entities
{
    public class Region : Entity, IEntityTypeConfiguration<Region>
    {
        public Region()
        {

        }
        public Region(string code)
        {
            Code = code;
        }

        public string Code { get; set; }

        public void Configure(EntityTypeBuilder<Region> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(x => x.Code).IsRequired();
        }
    }
}
