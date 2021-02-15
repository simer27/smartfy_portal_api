using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace smartfy.portal_api.domain.Entities
{
    public class Estoque : Entity, IEntityTypeConfiguration<Estoque>
    {
        public int Quantidade { get; set; }
        public int Reservado { get; set; }
        public double PrecoTotalEstoque { get; set; }
        public double PrecoTotalReservado { get; set; }
        public Guid ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }

        public Estoque()
        {

        }

        public Estoque(Guid produtoid, int quantidade, int reservado, double precototalestoque, double precototalreservado)
        {
           ProdutoId = produtoid;
           Quantidade = quantidade;
           Reservado = reservado;
           PrecoTotalEstoque = precototalestoque;
           PrecoTotalReservado = precototalreservado;
        }

        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).IsRequired();
        }
    }
}
