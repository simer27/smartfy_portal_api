namespace smartfy.portal_api.application.ViewModels.ApiViewModels
{
    public class FamiliaDomicilioApiViewModel
    {
        public string Documento { get; set; }
        public string Prontuario { get; set; }

        public string CpfResponsavel { get; set; }

        public string RendaFamiliar { get; set; }
        public int QuantidadeDeMembros { get; set; }
        public int ResideDesdeMes { get; set; }
        public int ResideDesdeAno { get; set; }
        public bool Mudouse { get; set; }
    }
}
