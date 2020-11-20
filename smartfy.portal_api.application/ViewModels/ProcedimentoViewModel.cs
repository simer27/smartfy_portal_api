using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace smartfy.portal_api.application.ViewModels
{
    public class ProcedimentoViewModel
    {
        public Guid Id { get; set; }

        public DateTime CreationDate { get; set; }

        public bool Excluded { get; set; }

        [Required(ErrorMessage = "O campo documento é obrigatório")]
        public string Documento { get; set; }

        public string Cpf { get; set; }

        public string Cns { get; set; }

        [Required(ErrorMessage = "O campo prontuário é obrigatório")]
        public string Prontuario { get; set; }

        [Required(ErrorMessage = "O campo turno é obrigatório")]
        public string Turno { get; set; }

        [Required(ErrorMessage = "O campo local de atendimento é obrigatório")]
        public string LocalAtendimento { get; set; }

        public string AfericaoPa { get; set; }
        public string AfericaoTemperatura { get; set; }
        public string CurativoSimples { get; set; }
        public string ColetaMaterialExameLaboratorial { get; set; }
        public string GlicemiaCapilar { get; set; }
        public decimal Altura { get; set; }
        public decimal Peso { get; set; }

        public ICollection<ProcedimentoRealizadoViewModel> ProcedimentosRealizados { get; set; }
    }
}
