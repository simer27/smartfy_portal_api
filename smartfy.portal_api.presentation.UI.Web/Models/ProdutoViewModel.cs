using smartfy.portal_api.domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartfy.portal_api.presentation.UI.Web.Models
{
    public class ProdutoViewModel
    {
        //Listagem pra GRID/TABLE
        public List<Produto> Produtos { get; set; }


        //Filtros
        public string FilterCodigo { get; set; }
        public string FilterDescricao { get; set; }
        public DateTime FilterDtCadastroDe { get; set; }
        public DateTime FilterDtCadastroAte { get; set; }
    }
}
