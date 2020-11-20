using smartfy.portal_api.domain.Entities.CartaoSUS;
using smartfy.portal_api.domain.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace smartfy.portal_api.application.ViewModels
{
    public class CartaoSUSViewModel
    {
        public Guid Id { get; set; }

        public DateTime CreationDate { get; set; }

        public bool Excluded { get; set; }

        #region Unidade Cadastradora
        [Display(Name = "Usuário")]
        public string UsuarioId { get; set; }
        #endregion

        #region Dados Pessoais 
        [Required(ErrorMessage = "Campo CPF é obrigatório")]
        [Display(Name = "CPF:")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "Campo CNS é obrigatório")]
        [Display(Name = "Número do CNS:")]
        public string NumeroCNS { get; set; }

        [Required(ErrorMessage = "Campo Nome é obrigatório")]
        [Display(Name = "Nome:")]
        public string Nome { get; set; }

        [Display(Name = "Nome Social/Apelido:")]
        public string NomeSocial { get; set; }

        [Display(Name = "Sexo:")]
        public ESexo Sexo { get; set; }

        [Display(Name = "Nome da mãe:")]
        public string NomeMae { get; set; } 

        [Display(Name = "Nome do pai:")]

        public string NomePai { get; set; }

        [Display(Name = "Raça:")]
        public string Raca { get; set; }

        [Display(Name = "Etnia indígena:")]
        public string Etnia { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Data de Nascimento: *")]
        [Required(ErrorMessage = "A Data de nascimento é obrigatória")] 
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Tipo  Sanguíneo:")]
        public string TipoSangue { get; set; }

        [Display(Name = "Nacionalidade:")]
        public string Nacionalidade { get; set; }

        [Display(Name = "Municipio De Nascimento:")]
        public string Municipio { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Data De Naturalização:")]
        public DateTime? DataNaturazalização { get; set; }

        [Display(Name = "Portaria:")]
        public string Portaria { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Data de Entrada no Brasil:")]
        public DateTime? DataEntradaNaturalizado { get; set; }

        [Display(Name = "Pais de Nascimento:")]
        public string Pais { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Data de Entrada no Brasil:")]
        public DateTime? DataEntradaEstrangeiro { get; set; }
        #endregion

        #region Contatos
        [Display(Name = "Município de Residência:")]
        public string MunicipioResidencia { get; set; }

        [Display(Name = "UF:")]
        public string UFLogradouro { get; set; }

        [Display(Name = "Tipo Logradouro(Rua,Avenida,Viela etc):")]
        public string TipoLogradouro { get; set; }

        [Display(Name = "Logradouro:")]
        public string Logradouro { get; set; }

        [Display(Name = "Número:")]
        public string NumeroLogradouro { get; set; }

        [Display(Name = "Complemento:")]
        public string ComplementoLogradouro { get; set; }

        [Display(Name = "Bairro:")]
        public string BairroLogradouro { get; set; }

        [Display(Name = "CEP:")]
        public string CEP { get; set; }

        [Display(Name = "DDD:")]
        public string DDD { get; set; }

        [Display(Name = "Telefone:")]
        public string Telefone { get; set; }

        [Display(Name = "E-mail principal:")]
        public string Email { get; set; }
        #endregion


        #region Doc Basicos

        [Required(ErrorMessage = "O campo número de inscrição é obrigatório")]
        [Display(Name = "Número de inscrição (NIS/PIS/PASEP):")]
        public string NumeroInscricao { get; set; }

        [Required(ErrorMessage = "Campo RG é obrigatório")]

        [Display(Name = "RG:")]
        public string RG { get; set; }

        [Required(ErrorMessage = "Campo Orgão Emissor é obrigatório")]

        [Display(Name = "Orgão emissor:")]
        public string OrgaoEmissor { get; set; }


        [Display(Name = "UF:")]
        public string UFDocumento { get; set; }

        [Required(ErrorMessage = "Campo Data de Emissão é obrigatório")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Data de emissão:")]
        public DateTime DataEmissao { get; set; }

        [Required(ErrorMessage = "Campo Modelo da Certidão de Nascimento é obrigatório")]

        [Display(Name = "Modelo da Certidão de Nascimento")]
        public EModeloCertidaoNascimento ModeloCertidaoNasccimento { get; set; }


        [Display(Name = "Numero da Certidão")]
        public string NumeroCertidaoNascimento { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Data de emissão:")]
        public DateTime? DataEmissaoDoc { get; set; }


        [Display(Name = "Nome do cartório:")]
        public string NomeCartorio { get; set; }


        [Display(Name = "Livro:")]
        public string LivroCertidao { get; set; }

        [Display(Name = "Folha:")]
        public string FolhaCertidao { get; set; }

        [Display(Name = "Termo:")]
        public string TermoCertidao { get; set; }

        [Display(Name = "Matrícula:")]
        public string MatriculaCertidao { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Data de emissão:")]
        public DateTime? DataEmissaoCertidao { get; set; }


        [Display(Name = "Outras informações:")]
        public string OutrasInformacoes { get; set; }
        #endregion
    }
}
