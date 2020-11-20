using System.Collections.Generic;

namespace smartfy.portal_api.presentation.UI.Web.DataTables
{
    /// <summary>  
    /// Request
    /// </summary>  
    public sealed class GridDataRequest
    {
        /// <summary>  
        /// Desenho
        /// </summary>  
        /// <value>  
        /// desenho  
        /// </value>  
        public int Draw { get; set; }
        /// <summary>  
        /// ini
        /// </summary>  
        /// <value>  
        /// ini
        /// </value>  
        public int Start { get; set; }
        /// <summary>  
        /// tamanho
        /// </summary>  
        /// <value>  
        /// tamanho
        /// </value>  
        public int Length { get; set; }
        /// <summary>  
        /// busca
        /// </summary>  
        /// <value>  
        /// busca
        /// </value>  
        public DataTableSearch Search { get; set; }
        /// <summary>  
        /// ordem
        /// </summary>  
        /// <value>  
        /// ordem
        /// </value>  
        public IEnumerable<DataTableOrder> Order { get; set; }
        /// <summary>  
        /// colunas
        /// </summary>  
        /// <value>  
        /// colunas
        /// </value>  
        public IEnumerable<DataTableColumn> Columns { get; set; }
    }
}
