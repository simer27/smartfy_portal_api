using smartfy.portal_api.domain.Entities.eSUS;
using System;
using System.ComponentModel.DataAnnotations;

namespace smartfy.portal_api.application.ViewModels
{
    public class FamiliaDomicilioViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Excluded { get; set; }
        public Guid DomicilioId { get; set; }

        public string Prontuario { get; set; }

        [Required(ErrorMessage = "O Cpf do Responsavel é Obrigatório")]
        public string CpfResponsavel { get; set; }

        [Required(ErrorMessage = "A data de nascimento do responsável é Obrigatória")]
        public DateTime DataNascimentoResponsavel { get; set; }
        public string RendaFamiliar { get; set; }
        public int QuantidadeDeMembros { get; set; }
        public int ResideDesdeMes { get; set; }
        public int ResideDesdeAno { get; set; }
        public bool Mudouse { get; set; }
        public virtual Domicilio Domicilio { get; set; }

    }
}
