using System;

namespace smartfy.portal_api.application.ViewModels
{
    public class VisitaDomiciliarViewModel
    {
        public Guid Id { get; set; }

        public DateTime CreationDate { get; set; }

        public bool Excluded { get; set; }

        public string Documento { get; set; }

        public string Turno { get; set; }

        public string MicroArea { get; set; }

        public string TipoDeImovel { get; set; }

        public string NumeroProntuario { get; set; }

        public string Cpf { get; set; }

        public string Cns { get; set; }

        public bool VisitaCompartilhada { get; set; }

        public bool CadastramentoAtualizacao { get; set; }

        public bool VisitaPeriodica { get; set; }

        public bool Consulta { get; set; }

        public bool Exame { get; set; }

        public bool Vacina { get; set; }

        public bool CondicionalidadesBolsaFamiliaBuscaAtiva { get; set; }

        public bool Gestante { get; set; }

        public bool Puerpera { get; set; }

        public bool RecemNascido { get; set; }

        public bool Crianca { get; set; }

        public bool Desnutricao { get; set; }

        public bool ReabilitacaoOuDeficiencia { get; set; }

        public bool Hipertensao { get; set; }

        public bool Diabetes { get; set; }

        public bool Asma { get; set; }

        public bool DPOCEnfizema { get; set; }

        public bool Cancer { get; set; }

        public bool OutrasDoencasCronicas { get; set; }

        public bool Hanseniase { get; set; }

        public bool Tuberculose { get; set; }

        public bool SintomaticosRespiratorios { get; set; }

        public bool Tabagista { get; set; }

        public bool DomiciliadoAcamado { get; set; }

        public bool CondicoesDeVunerabilidadeSocial { get; set; }

        public bool CondicionalidadesBolsaFamilia { get; set; }

        public bool SaudeMental { get; set; }

        public bool UsuarioAlcool { get; set; }

        public bool UsuarioDrogas { get; set; }

        public bool AcaoEducativa { get; set; }

        public bool ImovelComFoco { get; set; }

        public bool AcaoMecanica { get; set; }

        public bool TratamentoFocal { get; set; }

        public bool EgressoDeInternacao { get; set; }

        public bool ConviteAtividadesColetivas { get; set; }

        public bool Orientacao { get; set; }

        public bool Outros { get; set; }

        public string Peso { get; set; }

        public string Altura { get; set; }

        public string Desfecho { get; set; }
    }
}
