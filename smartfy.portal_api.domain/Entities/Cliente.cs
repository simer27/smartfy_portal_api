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
        public Cliente(string name, string cpf, string address)
        {
            Name = name;
            CPF = cpf;
            Address = address;
        }


        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).IsRequired();
            builder.Property(c => c.CPF).HasMaxLength(11);//Não deu certo, VERIFICAR!!!
        }
    }
}