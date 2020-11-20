using AutoMapper;
using smartfy.portal_api.application.ViewModels;
using smartfy.portal_api.application.ViewModels.ApiViewModels;
using smartfy.portal_api.domain.Entities;
using smartfy.portal_api.domain.Entities.eSUS;
using smartfy.portal_api.domain.Extensions;
using System.Linq;

namespace smartfy.portal_api.application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {


        public DomainToViewModelMappingProfile()
        {
            CreateMap<VisitaDomiciliar, VisitaDomiciliarViewModel>();
            CreateMap<AtendimentoIndividual, AtendimentoIndividualViewModel>();
            CreateMap<CartaoSUS, CartaoSUSViewModel>();
            CreateMap<FamiliaDomicilio, FamiliaDomicilioViewModel>();
            CreateMap<FamiliaDomicilio, FamiliaDomicilioApiViewModel>()
                .ConstructUsing(et => new FamiliaDomicilioApiViewModel()
                {
                    Documento = et.CpfResponsavel
                });
            CreateMap<CadastroIndividual, CadastroIndividualViewModel>();
            CreateMap<Odontologico, OdontologicoViewModel>();
            CreateMap<Domicilio, DomicilioViewModel>()
               .ConstructUsing(entity =>
                   new DomicilioViewModel()
                   {
                       Familias = entity.Familias.Select(x => new FamiliaDomicilioViewModel()
                       {
                           Id = x.Id,
                           CreationDate = x.CreationDate,
                           Excluded = x.Excluded,
                           DomicilioId = x.DomicilioId,
                           Prontuario = x.Prontuario,
                           CpfResponsavel = x.CpfResponsavel,
                           DataNascimentoResponsavel = x.DataNascimentoResponsavel,
                           RendaFamiliar = x.RendaFamiliar,
                           QuantidadeDeMembros = x.QuantidadeDeMembros,
                           ResideDesdeMes = x.ResideDesdeMes,
                           ResideDesdeAno = x.ResideDesdeAno,
                           Mudouse = x.Mudouse
                       }).ToList()
                   });

            CreateMap<Domicilio, DomicilioApiViewModel>()
               .ConstructUsing(entity =>
                   new DomicilioApiViewModel()
                   {
                       Familias = entity.Familias.Select(x => new FamiliaDomicilioApiViewModel()
                       {
                           Prontuario = x.Prontuario,
                           CpfResponsavel = x.CpfResponsavel,
                           RendaFamiliar = x.RendaFamiliar,
                           QuantidadeDeMembros = x.QuantidadeDeMembros,
                           ResideDesdeMes = x.ResideDesdeMes,
                           ResideDesdeAno = x.ResideDesdeAno,
                           Mudouse = x.Mudouse,
                           Documento = x.CpfResponsavel
                       }).ToList()
                   });

            CreateMap<Vacina, VacinaViewModel>()
                .ConstructUsing(v => new VacinaViewModel()
                {
                    ImunoBiologicos = v.ImunoBiologicos.Select(x => new VacinaImunoBiologicoViewModel()
                    {
                        Id = x.Id,
                        CreationDate = x.CreationDate,
                        Excluded = x.Excluded,
                        VacinaId = x.VacinaId,
                        ImunoBiologico = x.ImunoBiologico,
                        OutroImunoBiologico = x.OutroImunoBiologico,
                        Estrategia = x.Estrategia,
                        Dose = x.Dose,
                        Lote = x.Lote,
                        Fabricante = x.Fabricante
                    }).ToList()
                });


            CreateMap<Procedimento, ProcedimentoViewModel>()
               .ConstructUsing(p => new ProcedimentoViewModel()
               {
                   ProcedimentosRealizados = p.ProcedimentosRealizados.Select(x => new ProcedimentoRealizadoViewModel()
                   {
                       NomeProcedimento = x.NomeProcedimento
                   }).ToList()
               });


        }
    }
}
