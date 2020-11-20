using System.Collections.Generic;
using Newtonsoft.Json;

namespace smartfy.portal_api.presentation.UI.Web.DataTables
{
    /// <summary>  
    /// Resutado  
    /// </summary>  
    /// <typeparam name="T">Quer de quê?.</typeparam>  
    public class GridDataResult<T>
    {
        /// <summary>  
        /// Desenho
        /// </summary>  
        /// <value>  
        /// Desenho  
        /// </value>  
        [JsonProperty(PropertyName = "draw")]
        public int Draw { get; set; }
        /// <summary>  
        /// Total
        /// </summary>  
        /// <value>  
        /// Total
        /// </value>  
        [JsonProperty(PropertyName = "recordsTotal")]
        public int RecordsTotal { get; set; }
        /// <summary>  
        /// Filtrados
        /// </summary>  
        /// <value>  
        /// Filtrados
        /// </value>  
        [JsonProperty(PropertyName = "recordsFiltered")]
        public int RecordsFiltered { get; set; }
        /// <summary>  
        /// Data
        /// </summary>  
        /// <value>  
        /// Data
        /// </value>  
        [JsonProperty(PropertyName = "data")]
        public IEnumerable<T> Data { get; set; }
    }
}
