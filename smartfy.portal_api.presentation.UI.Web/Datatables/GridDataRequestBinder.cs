using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace smartfy.portal_api.presentation.UI.Web.DataTables
{
    /// <summary>  
    /// <see cref="GridDataRequest"/> model binder.  
    /// </summary>  
    /// <seealso cref="IModelBinder" />  
    public sealed class GridDataRequestBinder
      : IModelBinder
    {
        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            if (bindingContext == null)
            {
                throw new ArgumentNullException(nameof(bindingContext));
            }
            var request = bindingContext.HttpContext.Request;
            var search = new DataTableSearch
            {
                Value = request.Form["search[value]"],
                Regex = Convert.ToBoolean(request.Form["search[regex]"])
            };
            var ordByColCounter = 0;
            var order = new List<DataTableOrder>();
            while (!string.IsNullOrEmpty(request.Form["order[" + ordByColCounter + "][column]"]))
            {
                var column = request.Form["order[" + ordByColCounter + "][column]"];
                order.Add(new DataTableOrder
                {
                    Column = request.Form["columns[" + column + "][data]"],
                    Dir = request.Form["order[" + ordByColCounter + "][dir]"]
                });
                ordByColCounter++;
            }
            var colCounter = 0;
            var columns = new List<DataTableColumn>();
            while (!string.IsNullOrEmpty(request.Form["columns[" + colCounter + "][name]"]))
            {
                columns.Add(new DataTableColumn
                {
                    Data = request.Form["columns[" + colCounter + "][data]"],
                    Name = request.Form["columns[" + colCounter + "][name]"].ToString().ToLower(),
                    Orderable = Convert.ToBoolean(request.Form["columns[" + colCounter + "][orderable]"]),
                    Searchable = Convert.ToBoolean(request.Form["columns[" + colCounter + "][searchable]"]),
                    Search = new DataTableSearch
                    {
                        //Value = request.Form["columns[" + colCounter + "][search][value]"],
                        Value = request.Form["search[value]"],
                        Regex = Convert.ToBoolean(request.Form["columns[" + colCounter + "][search][regex]"])
                    }
                });
                colCounter++;
            }
            var model = new GridDataRequest
            {
                Draw = Convert.ToInt32(request.Form["draw"]),
                Start = Convert.ToInt32(request.Form["start"]),
                Length = Convert.ToInt32(request.Form["length"]),
                Search = search,
                Order = order,
                Columns = columns
            };
            model.Length = model.Length == 0 ? 10 : model.Length;
            bindingContext.Result = ModelBindingResult.Success(model);
            return Task.CompletedTask;
        }
    }
}
