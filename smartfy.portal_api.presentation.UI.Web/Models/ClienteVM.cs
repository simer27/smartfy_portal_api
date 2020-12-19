using smartfy.portal_api.domain.Entities;
using smartfy.portal_api.domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace smartfy.portal_api.presentation.UI.Web.Models
{
    public class ClienteVM
    {
        public List<Cliente> Clientes { get; set; }

        //Filtros
        public string FilterName { get; set; }
        public string FilterCPF { get; set; }
        public string FilterAddress { get; set; }

    }
}
