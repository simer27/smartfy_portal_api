using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace smartfy.portal_api.presentation.UI.Web.DataTables
{
    /// <summary>  
    /// Helper para criar predicados LINQ
    /// </summary>  
    public static class DataSourceQueryExtension
    {
        /// <summary>  
        /// A fonte de dados.  
        /// </summary>  
        /// <typeparam name="T">O tipo.</typeparam>  
        /// <param name="querySource">A query.</param>  
        /// <param name="request">A request.</param>  
        /// <returns>O resultado filtrado de acordo com os parâmetros do datatable.</returns>  
        public static GridDataResult<T> ToDataSource<T>(
            this IQueryable<T> querySource,
            GridDataRequest request)
        {
            return new GridDataResult<T>
            {
                Draw = request.Draw,
                RecordsTotal = querySource.Count(),
                RecordsFiltered = querySource.GetFilteredQuery(request).Count(),
                Data = querySource.GetFilteredQuery(request)
                    .Skip(request.Start)
                    .Take(request.Length)
            };
        }
        
        public static async Task<GridDataResult<T>> ToDataSourceAsync<T>(
            this IQueryable<T> querySource,
            GridDataRequest request)
        {
            return new GridDataResult<T>
            {
                Draw = request.Draw,
                RecordsTotal = await querySource.CountAsync(),
                RecordsFiltered = await querySource.GetFilteredQuery(request).CountAsync(),
                Data = await querySource
                    .GetFilteredQuery(request)
                    .Skip(request.Start)
                    .Take(request.Length)
                    .ToListAsync()
            };
        }

        /// <summary>  
        /// To the data source.
        /// </summary>  
        /// <typeparam name="T">O tipo de modelo.</typeparam>  
        /// <typeparam name="TResult">O tipo do resultado.</typeparam>  
        /// <param name="querySource">A query.</param>  
        /// <param name="request">A request.</param>  
        /// <param name="expression">A expressão.</param>  
        /// <returns>O resultado filtrado de acordo com os parâmetros do datatable.</returns>  
        /// <exception cref="ArgumentNullException">expression</exception>  
        public static GridDataResult<TResult> ToDataSource<T, TResult>(
            this IQueryable<T> querySource,
            GridDataRequest request,
            Expression<Func<T, TResult>> expression)
        {
            if (expression == null)
            {
                throw new ArgumentNullException(nameof(expression));
            }

            return new GridDataResult<TResult>
            {
                Draw = request.Draw,
                RecordsTotal = querySource.Count(),
                RecordsFiltered = querySource.GetFilteredQuery(request).Count(),
                Data = querySource.GetFilteredQuery(request)
                    .Select(expression)
                    .Skip(request.Start)
                    .Take(request.Length)
            };
        }

        /// <summary>  
        /// Pega a query filtrada.  
        /// </summary>  
        /// <typeparam name="T">O tipo.</typeparam>  
        /// <param name="querySource">A fonte.</param>  
        /// <param name="request">A request.</param>  
        /// <returns>Query filtrada baseada na <paramref name="request"/>.</returns>  
        private static IQueryable<T> GetFilteredQuery<T>(
            this IQueryable<T> querySource,
            GridDataRequest request)
        {
            var obj = new List<ExpressionModel>();
            request.Columns.Where(col => !string.IsNullOrEmpty(col.Search.Value))
                .ToList().ForEach(col =>
                {
                    obj.Add(new ExpressionModel
                    {
                        Operator = ExpressionOperators.Contains,
                        PropertyName = col.Data,
                        Value = col.Search.Value
                    });
                });
            querySource = querySource.Where(ExpressionBuilder.MakePredicate<T>(obj));
            var column = request.Order.Select(v => v.Column).FirstOrDefault();
            
            // Case insensitive column names
            column = querySource.ElementType.GetProperties()
                .First(info => column != null && info.Name.ToLower() == column.ToLower()).Name;
            
            var direction = request.Order.Select(v => v.Dir).FirstOrDefault();
            querySource = querySource.OrderBy(column, direction != "desc");
            return querySource;
        }
    }
}