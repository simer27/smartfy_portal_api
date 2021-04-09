using smartfy.portal_api.domain.Enums;
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Text;

namespace smartfy.portal_api.domain.Entities
{
    public class Funcionario : Entity, IEntityTypeConfiguration<Funcionario>
    {

        public int Id_Func { get; set; }
        public string Nome { get; set; }
        public EStatus Status { get; set; }
        public string Funcao { get; set; }
        public DateTime DtAdmissao { get; set; }
        public DateTime DtDemissao { get; set; }
        public ETurno  Turno { get; set; }
        public double Salario { get; set; }
        public string Beneficio { get; set; }

        public Funcionario() { }


        public Funcionario(int id_func, string nome, EStatus status,  string funcao, DateTime dtadmissao, DateTime dtdemissao, ETurno turno, double salario, string beneficio )
        {

                Id_Func = id_func;
                   Nome = nome;
                 Status = status;
                 Funcao = funcao;
             DtAdmissao = dtadmissao;
             DtDemissao = dtdemissao;
                  Turno = turno;
                Salario = salario;
              Beneficio = beneficio;
        }
        

        public void Configure(EntityTypeBuilder<Funcionario> builder)
        {
            builder.HasKey(c => c.Id);
            builder.Property(x => x.Id).IsRequired();
        }

    }
}
