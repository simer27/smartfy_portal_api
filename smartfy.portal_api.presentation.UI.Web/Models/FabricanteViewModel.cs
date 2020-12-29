using smartfy.portal_api.domain.Entities;
using smartfy.portal_api.domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartfy.portal_api.presentation.UI.Web.Models
{
    public class FabricanteViewModel
    {
        //Listagem pra GRID/TABLE
        public List<Fabricante> Fabricantes { get; set; }


        //Filtros
        public string FilterCodigo { get; set; }
        public string FilterNome { get; set; }
        public string FilterCnpj { get; set; }
        public string FilterEndereco { get; set; }
        public string FilterTelefone { get; set; }
    }
}
