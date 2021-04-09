using smartfy.portal_api.domain.Entities;
using smartfy.portal_api.domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartfy.portal_api.presentation.UI.Web.Models
{
    public class FuncionarioViewModel
    {
        //Listagem pra GRID/TABLE
        public List<FuncionarioViewModel> Funcionarios { get; set; }


        //Filtros
        public int FilterId_Func { get; set; }
        public string FilterNome { get; set; }
        public EStatus FilterStatus { get; set; }
        public string FilterFuncao { get; set; }
        public DateTime FilterDtAdmissao { get; set; }
        public DateTime FilterDtDemissao { get; set; }      
        public ETurno FilterTurno { get; set; }
        public double FilterSalario { get; set; }
        public string FilterBeneficio { get; set; }

    }
}
