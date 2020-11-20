using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace smartfy.portal_api.presentation.UI.Web.DataTables
{
    /// <summary>  
    /// <see cref="Gems.Model.Dto.Grid.GridDataRequest"/> provedor model binder.  
    /// </summary>  
    /// <seealso cref="Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinderProvider" />  
    public sealed class GridDataBinderProvider
      : IModelBinderProvider
    {
        /// <summary>  
        /// Cria uma <see cref="T:Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder" /> baseada em <see cref="T:Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderProviderContext" />.  
        /// </summary>  
        /// <param name="context">O <see cref="T:Microsoft.AspNetCore.Mvc.ModelBinding.ModelBinderProviderContext" />.</param>  
        /// <returns>  
        /// Um <see cref="T:Microsoft.AspNetCore.Mvc.ModelBinding.IModelBinder" />.  
        /// </returns>  
        /// <exception cref="ArgumentNullException">context</exception>  
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            if (context.Metadata.ModelType == typeof(GridDataRequest))
            {
                return new BinderTypeModelBinder(typeof(GridDataRequestBinder));
            }
            return null;
        }
    }
}
