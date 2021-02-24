using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace smartfy.portal_api.domain.Entities
{
    public class Fabricante : Entity, IEntityTypeConfiguration<Fabricante>
    {
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }

        public Fabricante() { }

        public Fabricante(String codigo, string nome, string cnpj, string endereco, string telefone)
        {
            Codigo = codigo;
            Nome = nome;
            CNPJ = cnpj;
            Endereco = endereco;
            Telefone = telefone;
        }
        public void Configure(EntityTypeBuilder<Fabricante> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).IsRequired();
        }
    }
}
