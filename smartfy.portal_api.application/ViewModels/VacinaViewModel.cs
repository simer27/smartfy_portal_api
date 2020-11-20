using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace smartfy.portal_api.application.ViewModels
{
    public class VacinaViewModel
    {
        public Guid Id { get; set; }

        public DateTime CreationDate { get; set; }

        public bool Excluded { get; set; }

        public string Prontuario { get; set; }

        [Required(ErrorMessage = "O Turno é Obrigatório")]
        public string Turno { get; set; }

        [Required(ErrorMessage = "O CPF é Obrigatório")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "O Turno é Obrigatório")]
        public string LocalAtendimento { get; set; }

        public string Sexo { get; set; }

        public DateTime DataNascimento { get; set; }

        public bool Gestante { get; set; }

        public bool Puerpera { get; set; }

        public bool Viajante { get; set; }

        public ICollection<VacinaImunoBiologicoViewModel> ImunoBiologicos { get; set; }
    }
}
