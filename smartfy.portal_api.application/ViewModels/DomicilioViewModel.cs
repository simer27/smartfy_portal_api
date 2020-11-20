using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace smartfy.portal_api.application.ViewModels
{
    public class DomicilioViewModel
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
        public bool Excluded { get; set; }

        #region Endereço/Local Permanencia
        [Required(ErrorMessage = "O Cep é Obrigatório")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O Municipio é Obrigatório")]
        public string Municipio { get; set; }

        [Required(ErrorMessage = "A Uf é Obrigatória")]
        public string Uf { get; set; }

        [Required(ErrorMessage = "O Bairro é Obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O Tipo de Logradouro é Obrigatório")]
        public string TipoLogradouro { get; set; }

        [Required(ErrorMessage = "O Logradouro é Obrigatório")]
        public string NomeLogradouro { get; set; }

        [Required(ErrorMessage = "O Numero é Obrigatório")]
        public string NumeroLogradouro { get; set; }
        public string ComplementoLogradouro { get; set; }
        public string PontoReferenciaLogradouro { get; set; }

        [Required(ErrorMessage = "O Tipo de Imovel é Obrigatório")]
        public int TipoImovel { get; set; }

        [Required(ErrorMessage = "A Micro Área é Obrigatória")]
        public int MicroArea { get; set; }
        public string TelResidencial { get; set; }
        public string TelContato { get; set; }
        #endregion

        [Required(ErrorMessage = "O Tipo de Posse é Obrigatório")]
        public string TipoPosse { get; set; }

        [Required(ErrorMessage = "O Tipo de Localização é Obrigatório")]
        public string TipoLocalizacao { get; set; }
        public string TipoDomicilio { get; set; }
        public int NumeroMoradores { get; set; }
        public int NumeroComodos { get; set; }
        public string TipoAcessoDomicilio { get; set; }
        public string TipoPosseAreaRural { get; set; }
        public bool TemEnergiaEletrica { get; set; }
        public string MaterialPredominanteConstrucao { get; set; }
        public string TipoAbastecimentoAgua { get; set; }
        public string TipoAguaConsulmo { get; set; }
        public string TipoEscoamentoBanheiro { get; set; }
        public string DestinoLixo { get; set; }
        public bool TemAnimais { get; set; }
        public string QuantidadeAnimais { get; set; }
        public List<string> TiposDeAnimais { get; set; }

        public virtual ICollection<FamiliaDomicilioViewModel> Familias { get; set; }
    }
}
