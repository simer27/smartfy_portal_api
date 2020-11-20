using System;

namespace smartfy.portal_api.application.ViewModels
{
    public class ProfissionalViewModel
    {
        public Guid Id { get; set; }

        public string ProfId { get; set; }

        public string Cpf { get; set; }

        public string Nome { get; set; }
        public string CNS { get; set; }
        public string TipoCbo { get; set; }
        public DateTime DtAtualizacao { get; set; }
        public string Usuario { get; set; }
        public string Checksum { get; set; }

        public Guid CboId { get; set; }

        public Guid CnesId { get; set; }
        public string CboCodigo { get; set; }
        public string CnesCodigo { get; set; }

        public string CnesRazaoSocial { get; set; }
    }
}
