using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace smartfy.portal_api.application.ViewModels
{
    public class OdontologicoViewModel
    {
        public Guid Id { get; set; }

        public DateTime CreationDate { get; set; }

        public bool Excluded { get; set; }

        #region DadosPessoais

        [Display(Name = "CPF/CNS do Cidadão:")]
        [Required(ErrorMessage = "O campo documento é obrigatório.")]
        public string Documento { get; set; }

        public string Cpf { get; set; }

        public string Cns { get; set; }

        [Display(Name = "Prontuário:")]
        public string Prontuario { get; set; }

        [Display(Name = "Turno:")]
        [Required(ErrorMessage = "O campo turno é obrigatório.")]
        public string Turno { get; set; }

        [Display(Name = "Local de atendimento:")]
        [Required(ErrorMessage = "O campo local de atendimento é obrigatório.")]
        public string LocalAtendimento { get; set; }

        [Display(Name = "Paciente Especial:")]
        public string PacienteEspecial { get; set; }

        [Display(Name = "Gestante:")]
        public string Gestante { get; set; }
        #endregion

        #region TipoAtendimento
        [Display(Name = "Tipo de Atendimento:")]
        [Required(ErrorMessage = "O campo tipo de atendimento é obrigatório.")]
        public string TipoAtendimento { get; set; }

        [Display(Name = "Demanda espôntanea:")]
        public string DemandaEspontanea { get; set; }
        #endregion

        #region Tipo de Consulta
        [Display(Name = "Tipo de Consulta:")]
        [Required(ErrorMessage = "O campo tipo de consulta é obrigatório.")]
        public string TipoConsulta { get; set; }
        #endregion

        #region Vigilancia
        public ICollection<VigilanciaSaudeViewModel> VigilanciaSaudes { get; set; }

        #endregion

        #region Procedimentos
        public ICollection<ProcedimentoOdontologicoViewModel> ProcedimentoOdontologicos { get; set; }


        #endregion

        #region Outros

        #endregion

        #region Fornecimento
        [Display(Name = "Escova Dental:")]
        public string EscovaDental { get; set; }
        [Display(Name = "Creme Dental:")]
        public string CremeDental { get; set; }
        [Display(Name = "Fio Dental:")]
        public string FioDental { get; set; }
        #endregion

        #region Conduta
        [Display(Name = "Retorno para consulta agendada:")]
        [Required(ErrorMessage = "O campo retorno para consulta agendada é obrigatório.")]

        public string RetornoConsulta { get; set; }
        [Display(Name = "Agendamento p/ outros profissionais AB:")]
        [Required(ErrorMessage = "O campo agendamento p/ outros profissionais AB é obrigatório.")]

        public string AgendamentoOutrosProfissionais { get; set; }
        [Display(Name = "Agendamento p/ NASF:")]
        [Required(ErrorMessage = "O campo agendamento p/ NASF é obrigatório.")]

        public string AgendamentoNASF { get; set; }
        [Display(Name = "Agendamento p/ grupos:")]
        [Required(ErrorMessage = "O campo agendamento p/ grupos é obrigatório.")]

        public string AgendamentoGrupos { get; set; }
        [Display(Name = "Alta do episódio:")]
        [Required(ErrorMessage = "O campo alta do episódio é obrigatório.")]

        public string AltaEpisodio { get; set; }
        [Display(Name = "Tratamento concluido:")]
        [Required(ErrorMessage = "O campo tratamento concluido é obrigatório.")]


        public string TratamentoConcluido { get; set; }
        #endregion

        #region Encaminhamento
        [Display(Name = "Atendimento a pacientes c/ necessidades especiais:")]
        public string AtendimentoNecessidades { get; set; }
        [Display(Name = "Cirurgia BMF:")]
        public string CirurgiaBMF { get; set; }
        [Display(Name = "Endodontia:")]
        public string Endodontia { get; set; }
        [Display(Name = "Estomatologia:")]
        public string Estamologia { get; set; }
        [Display(Name = "Implantodontia:")]
        public string Implantodontia { get; set; }
        [Display(Name = "Odontopediatria:")]
        public string Odontopediatria { get; set; }
        [Display(Name = "Ortodontia/Ortopedia:")]
        public string OrtodontiaOrtopedia { get; set; }
        [Display(Name = "Periodontia:")]
        public string Periodontia { get; set; }
        [Display(Name = "Prótese Dentária:")]
        public string ProteseDentaria { get; set; }
        [Display(Name = "Radiologia:")]
        public string Radiologia { get; set; }
        [Display(Name = "Outro:")]
        public string Outros { get; set; }
        #endregion

    }
}
