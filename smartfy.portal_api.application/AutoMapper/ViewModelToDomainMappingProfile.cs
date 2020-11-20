using AutoMapper;
using smartfy.portal_api.application.ViewModels;
using smartfy.portal_api.application.ViewModels.ApiViewModels;
using smartfy.portal_api.domain.Entities;
using smartfy.portal_api.domain.Entities.eSUS;
using System;

namespace smartfy.portal_api.application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<VisitaDomiciliarViewModel, VisitaDomiciliar>()
                .ForMember(x => x.Id, option => option.Condition(x => x.Id != Guid.Empty))
                .ForMember(x => x.CreationDate, option => option.Condition(x => x.Id != Guid.Empty))
                .ForMember(x => x.Excluded, option => option.Condition(x => x.Id != Guid.Empty));

            CreateMap<AtendimentoIndividualViewModel, AtendimentoIndividual>()
                .ForMember(x => x.Id, option => option.Condition(x => x.Id != Guid.Empty))
                .ForMember(x => x.CreationDate, option => option.Condition(x => x.Id != Guid.Empty))
                .ForMember(x => x.Excluded, option => option.Condition(x => x.Id != Guid.Empty))
                .ConstructUsing(vm => new AtendimentoIndividual()
                {
                    NumeroProntuario = vm.NumeroProntuario,
                    Documento = vm.Documento,
                    Turno = vm.Turno,
                    DataNascimento = vm.DataNascimento,
                    Sexo = vm.Sexo,
                    TipoAtendimento = vm.TipoAtendimento,
                    Vacinacao = vm.Vacinacao,
                    LocalAtendimento = vm.LocalAtendimento,
                    AtencaoDomiciliar = vm.AtencaoDomiciliar,
                    RacionalidadeSaude = vm.RacionalidadeSaude,
                    PerimetroCefalico = vm.PerimetroCefalico,
                    Peso = vm.Peso,
                    Altura = vm.Altura,
                    CriancaAleitamentoMaterno = vm.CriancaAleitamentoMaterno,
                    GestanteDUM = vm.GestanteDUM,
                    GravidezPlanejada = vm.GravidezPlanejada,
                    IdadeGestacional = vm.IdadeGestacional,
                    Gestas = vm.Gestas,
                    Asma = vm.Asma,
                    Desnutricao = vm.Desnutricao,
                    Diabetes = vm.Diabetes,
                    DPOC = vm.DPOC,
                    Hipertensao = vm.Hipertensao,
                    Obesidade = vm.Obesidade,
                    PreNatural = vm.PreNatural,
                    Puericultura = vm.Puericultura,
                    Puerperio = vm.Puerperio,
                    SaudeSexual = vm.SaudeSexual,
                    Tabagismo = vm.Tabagismo,
                    UsuarioAlcool = vm.UsuarioAlcool,
                    SaudeMental = vm.SaudeMental,
                    UsuarioOutrasDrogas = vm.UsuarioOutrasDrogas,
                    Reabilitacao = vm.Reabilitacao,
                    Tuberculose = vm.Tuberculose,
                    Hanseniase = vm.Hanseniase,
                    Dengue = vm.Dengue,
                    DST = vm.DST,
                    CancerColoDoUtero = vm.CancerColoDoUtero,
                    CancerMama = vm.CancerMama,
                    RiscoCardio = vm.RiscoCardio,
                    Outros = vm.Outros,
                    Colesterol = vm.Colesterol,
                    Creatina = vm.Creatina,
                    EAS = vm.EAS,
                    EletroCardio = vm.EletroCardio,
                    ExameEscarro = vm.ExameEscarro,
                    Glicemia = vm.Glicemia,
                    HDL = vm.HDL,
                    Hemoglobina = vm.Hemoglobina,
                    Hemograma = vm.Hemograma,
                    LDL = vm.LDL,
                    Retinografia = vm.Retinografia,
                    Sorologia = vm.Sorologia,
                    SorologiaHIV = vm.SorologiaHIV,
                    TesteGravidez = vm.TesteGravidez,
                    Ultrassonagrafia = vm.Ultrassonagrafia,
                    Urocultura = vm.Urocultura,
                    Antiglobulina = vm.Antiglobulina,
                    TesteOrelinha = vm.TesteOrelinha,
                    TesteOlinho = vm.TesteOlinho,
                    TestePesinho = vm.TestePesinho,
                    Observacao = vm.Observacao,
                    Avaliacao = vm.Avaliacao,
                    ProcedimentosClinicos = vm.ProcedimentosClinicos,
                    Prescricao = vm.Prescricao,
                    Interno = vm.Interno,
                    ServicoEspecializado = vm.ServicoEspecializado,
                    Caps = vm.Caps,
                    InternacaoHospitalar = vm.InternacaoHospitalar,
                    Urgencia = vm.Urgencia,
                    Intersetorial = vm.Intersetorial,
                    ServicoAtencao = vm.ServicoAtencao,
                    RetornoConsulta = vm.RetornoConsulta,
                    RetornoCuidado = vm.RetornoCuidado,
                    AgendamentoGrupos = vm.AgendamentoGrupos,
                    AgendamentoNASF = vm.AgendamentoNASF,
                    Alta = vm.Alta
                });

            CreateMap<CartaoSUSViewModel, CartaoSUS>()
             .ForMember(x => x.Id, option => option.Condition(x => x.Id != Guid.Empty))
             .ForMember(x => x.CreationDate, option => option.Condition(x => x.Id != Guid.Empty))
             .ForMember(x => x.Excluded, option => option.Condition(x => x.Id != Guid.Empty))
             .ConstructUsing(vm => new CartaoSUS()
             {
                 CPF = vm.CPF,
                 NumeroCNS = vm.NumeroCNS,
                 Nome = vm.Nome,
                 NomeSocial = vm.NomeSocial,
                 Sexo = vm.Sexo,
                 DataNascimento = vm.DataNascimento,
                 NomeMae = vm.NomeMae,
                 NomePai = vm.NomePai,
                 Raca = vm.Raca,
                 Etnia = vm.Etnia,
                 TipoSangue = vm.TipoSangue,
                 Nacionalidade = vm.Nacionalidade,
                 Municipio = vm.Municipio,
                 DataNaturazalização = vm.DataNaturazalização,
                 Portaria = vm.Portaria,
                 DataEntradaNaturalizado = vm.DataEntradaNaturalizado,
                 Pais = vm.Pais,
                 DataEntradaEstrangeiro = vm.DataEntradaEstrangeiro,
                 MunicipioResidencia = vm.MunicipioResidencia,
                 UFLogradouro = vm.UFLogradouro,
                 Logradouro = vm.Logradouro,
                 NumeroLogradouro = vm.NumeroLogradouro,
                 ComplementoLogradouro = vm.ComplementoLogradouro,
                 BairroLogradouro = vm.BairroLogradouro,
                 CEP = vm.CEP,
                 DDD = vm.DDD,
                 Telefone = vm.Telefone,
                 Email = vm.Email,
                 NumeroInscricao = vm.NumeroInscricao,
                 RG = vm.RG,
                 OrgaoEmissor = vm.OrgaoEmissor,
                 UFDocumento = vm.UFDocumento,
                 //UFNascimento = vm.UFNascimento,
                 DataEmissao = vm.DataEmissao,
                 ModeloCertidaoNasccimento = vm.ModeloCertidaoNasccimento,
                 NumeroCertidaoNascimento = vm.NumeroCertidaoNascimento,
                 DataEmissaoDoc = vm.DataEmissaoDoc,
                 NomeCartorio = vm.NomeCartorio,
                 LivroCertidao = vm.LivroCertidao,
                 FolhaCertidao = vm.FolhaCertidao,
                 TermoCertidao = vm.TermoCertidao,
                 MatriculaCertidao = vm.MatriculaCertidao,
                 DataEmissaoCertidao = vm.DataEmissaoCertidao,
                 OutrasInformacoes = vm.OutrasInformacoes,
             });

            CreateMap<CadastroIndividualViewModel, CadastroIndividual>()
          .ForMember(x => x.Id, option => option.Condition(x => x.Id != Guid.Empty))
          .ForMember(x => x.CreationDate, option => option.Condition(x => x.Id != Guid.Empty))
          .ForMember(x => x.Excluded, option => option.Condition(x => x.Id != Guid.Empty))
          .ConstructUsing(vm =>
              new CadastroIndividual()
              {
                  CPF = vm.CPF,
                  CidadaoResponsavel = vm.CidadaoResponsavel,
                  DocumentoResponsavel = vm.DocumentoResponsavel,
                  MicroArea = vm.MicroArea,
                  Nome = vm.Nome,
                  DataNascimento = vm.DataNascimento,
                  NumeroNIS = vm.NumeroNIS,
                  Telefone = vm.Telefone,
                  Email = vm.Email,
                  RelacaoParentesco = vm.RelacaoParentesco,
                  Ocupacao = vm.Ocupacao,
                  FrequentaEscola = vm.FrequentaEscola,
                  FrequentaCurso = vm.FrequentaCurso,
                  SituacaoTrabalho = vm.SituacaoTrabalho,
                  ResponsavelCrianca = vm.ResponsavelCrianca,
                  FrequentaCuidador = vm.FrequentaCuidador,
                  GrupoComunitario = vm.GrupoComunitario,
                  PlanoSaude = vm.PlanoSaude,
                  MembroComunidade = vm.MembroComunidade,
                  TipoComunidade = vm.TipoComunidade,
                  OrientacaoSexual = vm.OrientacaoSexual,
                  TiposOrientacaoSexual = vm.TiposOrientacaoSexual,
                  IdentidadeGenero = vm.IdentidadeGenero,
                  TiposIdentidadeGenero = vm.TiposIdentidadeGenero,
                  Deficiencia = vm.Deficiencia,
                  MudancaTerritorio = vm.MudancaTerritorio,
                  Obito = vm.Obito,
                  DataObito = vm.DataObito,
                  NumeroDO = vm.NumeroDO,
                  Gestante = vm.Gestante,
                  MaternidadeReferencia = vm.MaternidadeReferencia,
                  PesoDefinicao = vm.PesoDefinicao,
                  DoencaRespiratoria = vm.DoencaRespiratoria,
                  TipoDoencaRespiratoria = vm.TipoDoencaRespiratoria,
                  Fumante = vm.Fumante,
                  Alcool = vm.Alcool,
                  OutrasDrogas = vm.OutrasDrogas,
                  Hipertensao = vm.Hipertensao,
                  Diabetes = vm.Diabetes,
                  AVC = vm.AVC,
                  Infarto = vm.Infarto,
                  DoencaCardiaca = vm.DoencaCardiaca,
                  TipoDoencaCardiaca = vm.TipoDoencaCardiaca,
                  ProblemaRins = vm.ProblemaRins,
                  TipoProblemaRins = vm.TipoProblemaRins,
                  Haseniase = vm.Haseniase,
                  Tuberculose = vm.Tuberculose,
                  Cancer = vm.Cancer,
                  Internacao = vm.Internacao,
                  TipoInternacao = vm.TipoInternacao,
                  SaudeMental = vm.SaudeMental,
                  Acamado = vm.Acamado,
                  Domiciliado = vm.Domiciliado,
                  PlantasMedicinais = vm.PlantasMedicinais,
                  TipoPlantasMedicinais = vm.TipoPlantasMedicinais,
                  OutrasPraticas = vm.OutrasPraticas,
                  OutrasCondicoesSaude = vm.OutrasCondicoesSaude,
                  SituacaoDeRua = vm.SituacaoDeRua,
                  TempoSituacaoDeRua = vm.TempoSituacaoDeRua,
                  Beneficio = vm.Beneficio,
                  ReferenciaFamiliar = vm.ReferenciaFamiliar,
                  Alimentacao = vm.Alimentacao,
                  OrigemAlimentacao = vm.OrigemAlimentacao,
                  OutraInstituicao = vm.OutraInstituicao,
                  VisitacaoFamiliar = vm.VisitacaoFamiliar,
                  GrauParentesco = vm.GrauParentesco,
                  HigienePessoal = vm.HigienePessoal,
                  TipoHigienePessoal = vm.TipoHigienePessoal

              });

            CreateMap<DomicilioViewModel, Domicilio>()
                .ForMember(x => x.Id, option => option.Condition(x => x.Id != Guid.Empty))
                .ForMember(x => x.CreationDate, option => option.Condition(x => x.Id != Guid.Empty))
                .ForMember(x => x.Excluded, option => option.Condition(x => x.Id != Guid.Empty))
                .ForMember(x => x.Familias, option => option.Ignore())
                .ConstructUsing(vm => new Domicilio()
                {
                    TiposDeAnimais = vm.TiposDeAnimais == null ? "" : string.Join(';', vm.TiposDeAnimais)
                });

            CreateMap<DomicilioApiViewModel, Domicilio>()
                .ForMember(x => x.Id, option => option.Condition(x => x.Id != Guid.Empty))
                .ForMember(x => x.CreationDate, option => option.Condition(x => x.Id != Guid.Empty))
                .ForMember(x => x.Excluded, option => option.Condition(x => x.Id != Guid.Empty))
                .ForMember(x => x.Familias, option => option.Ignore());

            CreateMap<FamiliaDomicilioApiViewModel, FamiliaDomicilio>();

            CreateMap<VacinaViewModel, Vacina>()
                .ForMember(x => x.ImunoBiologicos, option => option.Ignore())
                .ForMember(x => x.Id, option => option.Condition(x => x.Id != Guid.Empty))
                .ForMember(x => x.CreationDate, option => option.Condition(x => x.Id != Guid.Empty))
                .ForMember(x => x.Excluded, option => option.Condition(x => x.Id != Guid.Empty));

            CreateMap<VacinaImunoBiologicoViewModel, VacinaImunoBiologico>()
                .ForMember(x => x.Id, option => option.Condition(x => x.Id != Guid.Empty))
                .ForMember(x => x.CreationDate, option => option.Condition(x => x.Id != Guid.Empty))
                .ForMember(x => x.Excluded, option => option.Condition(x => x.Id != Guid.Empty));

            CreateMap<ProcedimentoViewModel, Procedimento>()
                .ForMember(x => x.Id, option => option.Condition(x => x.Id != Guid.Empty))
                .ForMember(x => x.CreationDate, option => option.Condition(x => x.Id != Guid.Empty))
                .ForMember(x => x.Excluded, option => option.Condition(x => x.Id != Guid.Empty))
                .ForMember(x => x.ProcedimentosRealizados, option => option.Ignore());

            CreateMap<OdontologicoViewModel, Odontologico>()
                 .ForMember(x => x.Id, option => option.Condition(x => x.Id != Guid.Empty))
                 .ForMember(x => x.CreationDate, option => option.Condition(x => x.Id != Guid.Empty))
                 .ForMember(x => x.Excluded, option => option.Condition(x => x.Id != Guid.Empty))
                 .ForMember(x => x.VigilanciaSaudes, option => option.Ignore())
                 .ForMember(x => x.ProcedimentoOdontologicos, option => option.Ignore());

            //        .ConstructUsing(vm =>
            //              new Odontologico()
            //{
            //    Documento = vm.Documento,
            //    Cpf = vm.Cpf,
            //    Cns = vm.Cns,
            //    Prontuario = vm.Prontuario,
            //    Turno = vm.Turno,
            //    LocalAtendimento = vm.LocalAtendimento,
            //    PacienteEspecial = vm.PacienteEspecial,
            //    Gestante = vm.Gestante,
            //    TipoAtendimento = vm.TipoAtendimento,
            //    DemandaEspontanea = vm.DemandaEspontanea,
            //    TipoConsulta = vm.TipoConsulta,
            //    PolpaDentaria = vm.PolpaDentaria,
            //    Protese = vm.Protese,
            //    Cariostatico = vm.Cariostatico,
            //    Selante = vm.Selante,
            //    Fluor = vm.Fluor,
            //    Capeamento = vm.Capeamento,
            //    Cimentacao = vm.Cimentacao,
            //    Curativo = vm.Curativo,
            //    Drenagem = vm.Drenagem,
            //    PlacaBacteriana = vm.PlacaBacteriana,
            //    DenteDeciduo = vm.DenteDeciduo,
            //    DentePermanente = vm.DentePermanente,
            //    AdaptacaoProteseDentaria = vm.AdaptacaoProteseDentaria,
            //    ModelagemDetogengival = vm.ModelagemDetogengival,
            //    OrientacaoHigiene = vm.OrientacaoHigiene,
            //    Profilaxia = vm.Profilaxia,
            //    Pulpotomia = vm.Pulpotomia,
            //    Radiografia = vm.Radiografia,
            //    RaspagemAlisamento = vm.RaspagemAlisamento,
            //    RaspagemAlisamentoSub = vm.RaspagemAlisamentoSub,
            //    RestauracaoDeciduo = vm.RestauracaoDeciduo,
            //    RestauracaoPermanenteAnterior = vm.RestauracaoPermanenteAnterior,
            //    RestauracaoPermanentePosterior = vm.RestauracaoPermanentePosterior,
            //    RetiradaPontos = vm.RetiradaPontos,
            //    Selamento = vm.Selamento,
            //    TratamentoAlveolite = vm.TratamentoAlveolite,
            //    Ulotomia = vm.Ulotomia,
            //    CodigoSIGTAP = vm.CodigoSIGTAP,
            //    EscovaDental = vm.EscovaDental,
            //    CremeDental = vm.CremeDental,
            //    FioDental = vm.FioDental,
            //    RetornoConsulta = vm.RetornoConsulta,
            //    AgendamentoOutrosProfissionais = vm.AgendamentoOutrosProfissionais,
            //    AgendamentoNASF = vm.AgendamentoNASF,
            //    AgendamentoGrupos = vm.AgendamentoGrupos,
            //    AltaEpisodio = vm.AltaEpisodio,
            //    TratamentoConcluido = vm.TratamentoConcluido,
            //    AtendimentoNecessidades = vm.AtendimentoNecessidades,
            //    CirurgiaBMF = vm.CirurgiaBMF,
            //    Endodontia = vm.Endodontia,
            //    Estamologia = vm.Estamologia,
            //    Implantodontia = vm.Implantodontia,
            //    Odontopediatria = vm.Odontopediatria,
            //    OrtodontiaOrtopedia = vm.OrtodontiaOrtopedia,
            //    Periodontia = vm.Periodontia,
            //    ProteseDentaria = vm.ProteseDentaria,
            //    Radiologia = vm.Radiologia,
            //    Outros = vm.Outros


            //});
        }
    }
}
