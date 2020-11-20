namespace smartfy.portal_api.presentation.UI.Web.DataTables
{
    /// <summary>  
    /// Cria expressões de enums
    /// </summary>  
    public enum ExpressionOperators
    {
        Equals,
        GreaterThan,
        LessThan,
        GreaterThanOrEqual,
        LessThanOrEqual,
        Contains,
        StartsWith,
        EndsWith
    }
    /// <summary>  
    /// Model.  
    /// </summary>  
    public class ExpressionModel
    {
        /// <summary>  
        /// Propriedade
        /// </summary>  
        /// <value>  
        /// O nome da propriedade  
        /// </value>  
        public string PropertyName { get; set; }
        /// <summary>  
        /// O operador
        /// </summary>  
        /// <value>  
        /// A expressão do operador
        /// </value>  
        public ExpressionOperators Operator { get; set; }
        /// <summary>  
        /// O valor do parâmetro
        /// </summary>  
        /// <value>  
        /// O valor do parâmetro para expressão
        /// </value>  
        public object Value { get; set; }
    }
}
