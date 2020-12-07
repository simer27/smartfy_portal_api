using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using smartfy.portal_api.domain.Enums;

namespace smartfy.portal_api.domain.Entities
{
    public class Produto : Entity, IEntityTypeConfiguration<Produto>
    {
        public string Codigo { get; set; }
        public string Descricao { get; set; }
        public DateTime DtVencimento { get; set; }
        public bool IsPerecivel { get; set; } 

        public EStatus Status { get; set; }

        public Produto() { }

        public Produto(string codigo, string descricao, DateTime dtVencimento, bool isperecivel)
        {
            Codigo = codigo;
            Descricao = descricao;
            DtVencimento = dtVencimento;
            IsPerecivel = isperecivel;
        }


        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).IsRequired();
        }
    }
}