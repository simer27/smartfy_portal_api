using System;

namespace smartfy.portal_api.application.ViewModels
{
    public class ProcedimentoRealizadoViewModel
    {
        public Guid Id { get; set; }

        public DateTime CreationDate { get; set; }
        public bool Excluded { get; set; }

        public Guid ProcedimentoId { get; set; }

        public string NomeProcedimento { get; set; }

    }
}
