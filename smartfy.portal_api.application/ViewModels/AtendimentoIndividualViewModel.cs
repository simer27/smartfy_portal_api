using smartfy.portal_api.domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace smartfy.portal_api.application.ViewModels
{
    public class AtendimentoIndividualViewModel
    {
        public Guid Id { get; set; }

        public DateTime CreationDate { get; set; }

        public bool Excluded { get; set; }

        [Required(ErrorMessage = "O campo prontuário é obrigatório")]
        [Display(Name = "Numero do prontuário:")]
        public int NumeroProntuario { get; set; }

        [Required(ErrorMessage = "O campo documento é obrigatório")]
        [Display(Name = "CNS ou CPF do cidadão:")]
        public string Documento { get; set; }

        [Required(ErrorMessage = "O campo turno é obrigatório")]
        [Display(Name = "Turno: *")]
        public ETurno Turno { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Data de Nascimento: *")]
        [Required(ErrorMessage = "O campo data de nascimento é obrigatório")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "O campo sexo é obrigatório")]
        [Display(Name = "Sexo: *")]
        public ESexo Sexo { get; set; }

        [Required(ErrorMessage = "O campo tipo de atendimento é obrigatório")]
        [Display(Name = "Tipo de Atendimento: *")]
        public string TipoAtendimento { get; set; }

        [Display(Name = "Vacinação em dia:")]
        public string Vacinacao { get; set; }

        [Required(ErrorMessage = "O campo local de atendimento é obrigatório")]
        [Display(Name = "Local de Atendimento: *")]
        public string LocalAtendimento { get; set; }


        [Display(Name = "Atenção Domicíliar: ")]
        public string AtencaoDomiciliar { get; set; }

        [Display(Name = "Racionalidade em Saúde: ")]

        public string RacionalidadeSaude { get; set; }

        // Avaliacao Antopometrica
        [Display(Name = "Perimetro Cefalico (CM) ")]
        public Decimal? PerimetroCefalico { get; set; }

        [Display(Name = "Peso (KG) ")]
        public Decimal? Peso { get; set; }

        [Display(Name = "Altura (CM)")]
        public Decimal? Altura { get; set; }

        public string CriancaAleitamentoMaterno { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [Display(Name = "Gestante DUM: ")]
        public DateTime? GestanteDUM { get; set; }

        [Display(Name = "Gravidez Planejada: ")]
        public string GravidezPlanejada { get; set; }

        [Display(Name = "Idade Gestacional: ")]
        public int IdadeGestacional { get; set; }

        [Display(Name = "Gestas Prévias/Partos: ")]
        public int Gestas { get; set; }

        // Problema E Condição Avaliada

        [Required(ErrorMessage = "O campo asma é obrigatório")]
        [Display(Name = "Asma: *")]
        public string Asma { get; set; }

        [Required(ErrorMessage = "O campo desnutrição é obrigatório")]
        [Display(Name = "Desnutrição: *")]
        public string Desnutricao { get; set; }

        [Required(ErrorMessage = "O campo diabetes é obrigatório")]
        [Display(Name = "Diabetes: *")]
        public string Diabetes { get; set; }


        [Required(ErrorMessage = "O campo DPOC é obrigatório")]
        [Display(Name = "DPOC: *")]
        public string DPOC { get; set; }

        [Required(ErrorMessage = "O campo hipertensão é obrigatório")]
        [Display(Name = "Hipertensão: *")]
        public string Hipertensao { get; set; }


        [Required(ErrorMessage = "O campo obesidade é obrigatório")]
        [Display(Name = "Obesidade: *")]
        public string Obesidade { get; set; }

        [Required(ErrorMessage = "O campo pré-natural é obrigatório")]
        [Display(Name = "Pré Natural: *")]
        public string PreNatural { get; set; }

        [Required(ErrorMessage = "O campo puericultura é obrigatório")]
        [Display(Name = "Puericultura: *")]
        public string Puericultura { get; set; }

        [Required(ErrorMessage = "O campo puerperio é obrigatório")]
        [Display(Name = "Puerperio (Até 42 semanas): *")]
        public string Puerperio { get; set; }

        [Required(ErrorMessage = "O campo saude sexual e reprodutiva é obrigatório")]
        [Display(Name = "Saúde Sexual e reprodutiva: *")]
        public string SaudeSexual { get; set; }

        [Required(ErrorMessage = "O campo tabagismo é obrigatório")]
        [Display(Name = "Tabagismo: *")]
        public string Tabagismo { get; set; }

        [Required(ErrorMessage = "O campo usuário de alcool é obrigatório")]
        [Display(Name = "Usuário de Alcool: *")]
        public string UsuarioAlcool { get; set; }

        [Required(ErrorMessage = "O campo saúde mental é obrigatório")]
        [Display(Name = "Saúde Mental: *")]
        public string SaudeMental { get; set; }

        [Required(ErrorMessage = "O campo usuário de outras drogas é obrigatório")]
        [Display(Name = "Usuário de outras drogas: *")]
        public string UsuarioOutrasDrogas { get; set; }

        [Required(ErrorMessage = "O campo reabilitação é obrigatório")]
        [Display(Name = "Reabilitação: *")]
        public string Reabilitacao { get; set; }

        // Doencas Transmissoras

        [Required(ErrorMessage = "O campo tuberculose é obrigatório")]
        [Display(Name = "Tuberculose: *")]
        public string Tuberculose { get; set; }

        [Required(ErrorMessage = "O campo haseniase é obrigatório")]
        [Display(Name = "Haseniase: *")]
        public string Hanseniase { get; set; }

        [Required(ErrorMessage = "O campo dengue é obrigatório")]
        [Display(Name = "Dengue: *")]
        public string Dengue { get; set; }

        [Required(ErrorMessage = "O campo DST é obrigatório")]
        [Display(Name = "DST: *")]
        public string DST { get; set; }

        // Rastreamento

        [Required(ErrorMessage = "O campo câncer colo do utero é obrigatório")]
        [Display(Name = "Câncer colo do utero: *")]
        public string CancerColoDoUtero { get; set; }

        [Required(ErrorMessage = "O campo câncer de mama é obrigatório")]
        [Display(Name = "Câncer de mama: *")]
        public string CancerMama { get; set; }

        [Required(ErrorMessage = "O campo risco cardio é obrigatório")]
        [Display(Name = "Risco cardio: *")]
        public string RiscoCardio { get; set; }

        [Display(Name = "Outros: ")]
        public string Outros { get; set; }

        // Exames Solicitados

        [Display(Name = "Colesterol Total: ")]
        public string Colesterol { get; set; }

        [Display(Name = "Creatina: ")]
        public string Creatina { get; set; }

        [Display(Name = "EAS: ")]
        public string EAS { get; set; }

        [Display(Name = "Eletrocardiograma: ")]
        public string EletroCardio { get; set; }

        [Display(Name = "Exame escarro: ")]
        public string ExameEscarro { get; set; }

        [Display(Name = "Glicemia: ")]

        public string Glicemia { get; set; }

        [Display(Name = "HDL: ")]
        public string HDL { get; set; }

        [Display(Name = "Hemoglobina:")]
        public string Hemoglobina { get; set; }

        [Display(Name = "Hemograma: ")]
        public string Hemograma { get; set; }

        [Display(Name = "LDL:")]
        public string LDL { get; set; }

        [Display(Name = "Retinografia:")]
        public string Retinografia { get; set; }

        [Display(Name = "Sorologia:")]
        public string Sorologia { get; set; }

        [Display(Name = "Sorologia HIV:")]

        public string SorologiaHIV { get; set; }

        [Display(Name = "Sorologia de Sifílis:")]

        public string SorologiaSifilis { get; set; }

        [Display(Name = "Teste de Gravidez:")]

        public string TesteGravidez { get; set; }

        [Display(Name = "Ultrassonagrafia Obstétrica:")]

        public string Ultrassonagrafia { get; set; }

        [Display(Name = "Urocultura:")]

        public string Urocultura { get; set; }

        [Display(Name = "Teste indireito de Antiglobulina humana:")]

        public string Antiglobulina { get; set; }

        // Triagem neonatal

        [Display(Name = "Teste da orelinha:")]

        public string TesteOrelinha { get; set; }

        [Display(Name = "Teste do olinho:")]

        public string TesteOlinho { get; set; }

        [Display(Name = "Teste do pesinho:")]

        public string TestePesinho { get; set; }


        [Display(Name = "Outros exames (código do SIGAP):")]

        public string OutrosExames { get; set; }

        [Display(Name = "Ficou em Observação?")]

        public string Observacao { get; set; }

        // Nast Polo

        [Display(Name = "Avaliação:")]

        public string Avaliacao { get; set; }

        [Display(Name = "Procedimentos Clínicos:")]

        public string ProcedimentosClinicos { get; set; }

        [Display(Name = "Prescrição terapeutica:")]

        public string Prescricao { get; set; }

        // Encaminhamento

        [Required(ErrorMessage = "O campo encaminhamento interno no dia é obrigatório")]
        [Display(Name = "Encaminhamento interno no dia: *")]
        public string Interno { get; set; }

        [Required(ErrorMessage = "O campo encaminhamento p/ serviço especializado é obrigatório")]
        [Display(Name = "Encaminhamento p/ serviço especializado: *")]
        public string ServicoEspecializado { get; set; }

        [Required(ErrorMessage = "O campo encaminhamento p/ caps é obrigatório")]
        [Display(Name = "Encaminhamento p/ CAPS: *")]
        public string Caps { get; set; }

        [Required(ErrorMessage = "O campo encaminhamento p/ internação hospitalar é obrigatório")]
        [Display(Name = "Encaminhamento p/ internação hospitalar: *")]
        public string InternacaoHospitalar { get; set; }

        [Required(ErrorMessage = "O campo encaminhamento p/ urgência é obrigatório")]
        [Display(Name = "Encaminhamento p/ urgência: *")]
        public string Urgencia { get; set; }

        [Required(ErrorMessage = "O campo encaminhamento p/ serviço de atenção domiciliar campo é obrigatório")]
        [Display(Name = "Encaminhamento p/ serviço de atenção domiciliar: *")]
        public string ServicoAtencao { get; set; }

        [Required(ErrorMessage = "O campo encaminhamento intersetorial é obrigatório")]
        [Display(Name = "Encaminhamento intersetorial: *")]
        public string Intersetorial { get; set; }



        // Conduta

        [Required(ErrorMessage = "O campo retorno para consulta agendada é obrigatório")]
        [Display(Name = "Retorno para consulta agendada: *")]
        public string RetornoConsulta { get; set; }

        [Required(ErrorMessage = "O campo retorno p/ cuidado continuado/programado é obrigatório")]
        [Display(Name = "Retorno p/ cuidado continuado/programado: *")]
        public string RetornoCuidado { get; set; }

        [Required(ErrorMessage = "O campo agendamento p/grupos é obrigatório")]
        [Display(Name = "Agendamento p/ grupos: *")]
        public string AgendamentoGrupos { get; set; }

        [Required(ErrorMessage = "O campo agendamento p/ NASF é obrigatório")]
        [Display(Name = "Agendamento p/ NASF: *")]
        public string AgendamentoNASF { get; set; }

        [Required(ErrorMessage = "O campo alta do episodio é obrigatório")]
        [Display(Name = "Alta do episódio: *")]
        public string Alta { get; set; }

        [Required(ErrorMessage = "O campo profissional é obrigatório")]
        public List<Guid> ProfissionalIds { get; set; }
    }
}
