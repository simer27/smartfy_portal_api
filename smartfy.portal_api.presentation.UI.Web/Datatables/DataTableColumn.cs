namespace smartfy.portal_api.presentation.UI.Web.DataTables
{
    /// <summary>  
    /// Coluna
    /// </summary>  
    public sealed class DataTableColumn
    {
        /// <summary>  
        /// Data
        /// </summary>  
        /// <value>  
        /// data.  
        /// </value>  
        public string Data { get; set; }
        /// <summary>  
        /// name.  
        /// </summary>  
        /// <value>  
        /// name.  
        /// </value>  
        public string Name { get; set; }
        /// <summary>  
        /// Se é ordenável
        /// </summary>  
        /// <value>  
        ///  <c>true</c> se ordenável; <c>false</c> caso contrário.  
        /// </value>  
        public bool Orderable { get; set; }
        /// <summary>  
        /// Se é pesquisável
        /// </summary>  
        /// <value>  
        ///  <c>true</c> se pesquisável; <c>false</c> caso contrário.  
        /// </value>  
        public bool Searchable { get; set; }
        /// <summary>  
        /// Configura a pesquisa
        /// </summary>  
        /// <value>  
        /// A pesquisa 
        /// </value>  
        public DataTableSearch Search { get; set; }
    }
}
