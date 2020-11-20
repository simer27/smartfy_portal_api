namespace smartfy.portal_api.presentation.UI.Web.DataTables
{
    /// <summary>  
    /// A coluna a ser pesquisada
    /// </summary>  
    public sealed class DataTableSearch
    {
        /// <summary>  
        /// O valor
        /// </summary>  
        /// <value>  
        /// O valor  
        /// </value>  
        public string Value { get; set; }
        /// <summary>  
        /// É regex?
        /// </summary>  
        /// <value>  
        ///  <c>true</c> se regex; <c>false</c> caso contrário.  
        /// </value>  
        public bool Regex { get; set; }
    }
}
