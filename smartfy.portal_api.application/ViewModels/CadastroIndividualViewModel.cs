using System;
using System.ComponentModel.DataAnnotations;

namespace smartfy.portal_api.application.ViewModels
{
    public class CadastroIndividualViewModel
    {
        public Guid Id { get; set; }

        public DateTime CreationDate { get; set; }

        public bool Excluded { get; set; }

        public string Documento { get; set; }

        #region Unidade Cadastradora
        [Display(Name = "Usuário")]
        public string UsuarioId { get; set; }
        #endregion

        #region Dados Pessoais

        [Display(Name = "CPF: *")]
        public string CPF { get; set; }

        public string Cns { get; set; }

        [Display(Name = "Cidadão é o responsável famíliar? ")]
        public string CidadaoResponsavel { get; set; }

        [Display(Name = "CPF/CNS do responsável famíliar?")]
        public string DocumentoResponsavel { get; set; }

        [Required(ErrorMessage = "Campo MicroÁrea é obrigatório")]
        [Display(Name = "MicroÁrea: *")]
        public string MicroArea { get; set; }

        public string Nome { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Data de Nascimento: ")]
        public DateTime? DataNascimento { get; set; }

        [Display(Name = "Nº NIS (PIS/PASEP):")]
        public string NumeroNIS { get; set; }

        [Display(Name = "Telefone Celular:")]
        public string Telefone { get; set; }

        [Display(Name = "Email:")]
        public string Email { get; set; }
        #endregion

        #region  Informações sociodemograficas

        [Display(Name = "Relação de parantesco com o respónsavel familiar:")]
        public string RelacaoParentesco { get; set; }

        [Display(Name = "Ocupação:")]
        public string Ocupacao { get; set; }

        [Required(ErrorMessage = "Campo Frequenta a escola é obrigatório")]
        [Display(Name = "Frequenta escola ou creche? *")]
        public string FrequentaEscola { get; set; }

        [Display(Name = "Qual é o curso mais elevado que frequenta ou frequentou?")]
        public string FrequentaCurso { get; set; }

        [Display(Name = "Situação no mercado de trabalho")]
        public string SituacaoTrabalho { get; set; }

        [Display(Name = "Criança de 0 a 9 anos com quem fica?")]
        public string ResponsavelCrianca { get; set; }

        [Display(Name = "Frequenta cuidador tradicional?")]
        public string FrequentaCuidador { get; set; }

        [Display(Name = "Participa de algum grupo comunitário?")]
        public string GrupoComunitario { get; set; }

        [Display(Name = "Possui plano de saúde privado?")]
        public string PlanoSaude { get; set; }

        [Display(Name = "É membro de povo ou comunidade tradicional?")]
        public string MembroComunidade { get; set; }

        [Display(Name = "Se sim, qual (is)?")]
        public string TipoComunidade { get; set; }

        [Display(Name = "Deseja informar orientação sexual?")]
        public string OrientacaoSexual { get; set; }

        [Display(Name = "Se sim, qual (is)?")]
        public string TiposOrientacaoSexual { get; set; }

        [Display(Name = "Deseja informar identidade de gênero?")]
        public string IdentidadeGenero { get; set; }

        [Display(Name = "Se sim, qual (is)?")]
        public string TiposIdentidadeGenero { get; set; }

        [Required(ErrorMessage = "Campo Tem alguma deficiência é obrigatório")]
        [Display(Name = "Tem alguma deficiência? *")]
        public string Deficiencia { get; set; }

        [Display(Name = "Se sim, qual (is)?")]
        public string TiposDeficiencia { get; set; }


        [Display(Name = "Mudança de território")]
        public string MudancaTerritorio { get; set; }

        [Display(Name = "Óbito:")]
        public string Obito { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Data de Óbito:")]
        public DateTime? DataObito { get; set; }

        [Display(Name = "Número da D.O")]
        public string NumeroDO { get; set; }

        #endregion

        #region Condições/Situações de saúde gerais

        [Display(Name = "Está gestante?")]
        public string Gestante { get; set; }

        [Display(Name = "Se sim, qual é a maternidade de referência?")]
        public string MaternidadeReferencia { get; set; }

        [Display(Name = "Sobre seu peso, você se considera?")]
        public string PesoDefinicao { get; set; }

        [Required(ErrorMessage = "Campo Tem doença respiratória no pulmão é obrigatório")]
        [Display(Name = "Tem doença respiratória no pulmão? *")]
        public string DoencaRespiratoria { get; set; }

        [Display(Name = "Se sim, indique qual (is) ?")]
        public string TipoDoencaRespiratoria { get; set; }

        [Display(Name = "Está fumante?")]
        public string Fumante { get; set; }

        [Display(Name = "Faz uso de álcool?")]
        public string Alcool { get; set; }

        [Display(Name = "Faz uso de outras drogas?")]
        public string OutrasDrogas { get; set; }

        [Display(Name = "Tem hipertensão arterial?")]
        public string Hipertensao { get; set; }

        [Display(Name = "Tem diabetes?")]
        public string Diabetes { get; set; }

        [Display(Name = "Teve AVC/Derrame?")]
        public string AVC { get; set; }

        [Display(Name = "Teve infarto?")]
        public string Infarto { get; set; }

        [Required(ErrorMessage = "Campo Tem doença cardíaca/do coração? é obrigatório")]
        [Display(Name = "Tem doença cardíaca/do coração? *")]
        public string DoencaCardiaca { get; set; }

        [Display(Name = "Se sim, indique qual (is) ?")]
        public string TipoDoencaCardiaca { get; set; }


        [Required(ErrorMessage = "Campo Tem ou teve problemas nos rins é obrigatório")]
        [Display(Name = "Tem ou teve problemas nos rins? *")]
        public string ProblemaRins { get; set; }

        [Display(Name = "Se sim, indique qual (is) ?")]
        public string TipoProblemaRins { get; set; }

        [Display(Name = "Está com hanseníase?")]
        public string Haseniase { get; set; }

        [Display(Name = "Está com tuberculose?")]
        public string Tuberculose { get; set; }

        [Display(Name = "Está com câncer?")]
        public string Cancer { get; set; }

        [Display(Name = "Teve alguma internação nos últimos 12 meses?")]
        public string Internacao { get; set; }

        [Display(Name = "Se sim, por qual causa?")]
        public string TipoInternacao { get; set; }

        [Display(Name = "Teve diagnóstico de algum problema de saúde mental por profissional de saúde?")]
        public string SaudeMental { get; set; }

        [Display(Name = "Está acamado?")]
        public string Acamado { get; set; }

        [Display(Name = "Está domiciliado?")]
        public string Domiciliado { get; set; }

        [Display(Name = "Usa plantas medicinais?")]
        public string PlantasMedicinais { get; set; }

        [Display(Name = "Se sim, indique qual (is)?")]
        public string TipoPlantasMedicinais { get; set; }

        [Display(Name = "Usa outras práticas integrativas e complementares?")]
        public string OutrasPraticas { get; set; }

        [Display(Name = "Outras condições de saúde?")]
        public string OutrasCondicoesSaude { get; set; }

        #endregion

        #region Cidadão em situação de rua

        [Required(ErrorMessage = "Campo Está em situação de  rua Situação de Rua é obrigatório")]
        [Display(Name = "Está em situação de  rua? *")]
        public string SituacaoDeRua { get; set; }

        [Display(Name = "Tempo em situação de rua")]
        public string TempoSituacaoDeRua { get; set; }

        [Display(Name = "Recebe algum benefício?")]
        public string Beneficio { get; set; }

        [Display(Name = "Possui referência familiar?")]
        public string ReferenciaFamiliar { get; set; }

        [Display(Name = "Quantas vezes você se alimenta no dia?")]
        public string Alimentacao { get; set; }

        [Display(Name = "Qual a origem da alimentação?")]
        public string OrigemAlimentacao { get; set; }

        [Display(Name = "É acompanhado por outra instituição?")]
        public string OutraInstituicao { get; set; }

        [Display(Name = "Visita algum familiar com frequência?")]
        public string VisitacaoFamiliar { get; set; }

        [Display(Name = "Se sim, qual o grâu de parentesco?")]
        public string GrauParentesco { get; set; }


        [Required(ErrorMessage = "Campo Tem acesso a higiene pessoal é obrigatório")]
        [Display(Name = "Tem acesso a higiene pessoal? *")]
        public string HigienePessoal { get; set; }

        [Display(Name = "Se sim, qual (is)?")]
        public string TipoHigienePessoal { get; set; }

        #endregion
    }
}
