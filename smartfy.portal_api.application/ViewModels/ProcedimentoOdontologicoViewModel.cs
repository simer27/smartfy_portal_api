using System;

namespace smartfy.portal_api.application.ViewModels
{
    public class ProcedimentoOdontologicoViewModel
    {
        public Guid Id { get; set; }

        public DateTime CreationDate { get; set; }
        public bool Excluded { get; set; }

        public Guid ProcedimentoOdontologicoId { get; set; }

        public string NomeProcedimento { get; set; }
        public string QuantidadeRealizada { get; set; }

    }
}
