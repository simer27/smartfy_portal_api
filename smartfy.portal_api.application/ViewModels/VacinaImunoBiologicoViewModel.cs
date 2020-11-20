using System;
using System.ComponentModel.DataAnnotations;

namespace smartfy.portal_api.application.ViewModels
{
    public class VacinaImunoBiologicoViewModel
    {
        public Guid Id { get; set; }

        public DateTime CreationDate { get; set; }

        public bool Excluded { get; set; }

        public Guid VacinaId { get; set; }

        [Required(ErrorMessage = "O ImunoBiologico é Obrigatório")]
        public string ImunoBiologico { get; set; }

        public string OutroImunoBiologico { get; set; }

        [Required(ErrorMessage = "A Estratégia é Obrigatória")]
        public string Estrategia { get; set; }

        [Required(ErrorMessage = "A Dosagem é Obrigatória")]
        public string Dose { get; set; }

        [Required(ErrorMessage = "O Lote é Obrigatório")]
        public string Lote { get; set; }

        [Required(ErrorMessage = "O Fabricante é Obrigatório")]
        public string Fabricante { get; set; }
    }
}
