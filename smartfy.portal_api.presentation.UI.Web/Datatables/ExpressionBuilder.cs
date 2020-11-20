using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace smartfy.portal_api.presentation.UI.Web.DataTables
{
    /// <summary>  
    /// Criados de expressões
    /// </summary>  
    public static class ExpressionBuilder
    {
        private static MethodInfo containsMethod = typeof(string).GetMethod("Contains", new Type[] { typeof(string) });

        private static MethodInfo containsNoDiacritics = typeof(DiacriticsHelper).GetMethod("ContainsNoDiacritics");
        //private static MethodInfo containsMethod = typeof(string).GetMethod("Contains");
        private static MethodInfo endsWithMethod = typeof(string).GetMethod("EndsWith", new Type[] { typeof(string) });
        private static MethodInfo startsWithMethod = typeof(string).GetMethod("StartsWith", new Type[] { typeof(string) });

       
        /// <summary>  
        /// Cria o predicado de acordo com o model
        /// </summary>  
        /// <typeparam name="T">O tipo que esta expressão será criada.</typeparam>  
        /// <param name="filters">Os filtros que serão aplicados.</param>  
        /// <returns>A expressão.</returns>  
        public static Expression<Func<T, bool>> MakePredicate<T>(IEnumerable<ExpressionModel> filters)
        {
            if (filters == null)
            {
                return (model) => true;
            }
            filters = filters.Where(filter => filter != null);
            if (!filters.Any())
            {
                return (model) => true;
            }
            var item = Expression.Parameter(typeof(T), "item");
            foreach (var f in filters)
            {
                f.Value = f.Value.ToString();
            }

            try
            {
                var body = filters.Select(filter => MakePredicate(item, filter)).Aggregate(Expression.OrElse);
                var predicate = Expression.Lambda<Func<T, bool>>(body, item);
                return predicate;
            }
            catch (Exception)
            {
                return (model) => true;
            }            
        }
        /// <summary>  
        /// Aplica a ordenação baseada no model
        /// </summary>  
        /// <typeparam name="T">O tipo do model.</typeparam>  
        /// <param name="source">A fonte.</param>  
        /// <param name="ordering">A coluna de ordenação.</param>  
        /// <param name="ascending">se <c>true</c> asc.</param>  
        /// <returns>Query com o predicate de ordenação aplicado.</returns>  
        public static IQueryable<T> OrderBy<T>(
          this IQueryable<T> source,
          string ordering,
          bool ascending)
        {
            if (string.IsNullOrEmpty(ordering))
            {
                return source;
            }
            var type = typeof(T);
            var parameter = Expression.Parameter(type, "p");
            PropertyInfo property;
            Expression propertyAccess;
            if (ordering.Contains('.'))
            {
                // pode ser ordenador por colunas filhas...é foda!
                var childProperties = ordering.Split('.');
                property = type.GetProperty(childProperties[0]);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
                for (int i = 1; i < childProperties.Length; i++)
                {
                    property = property.PropertyType.GetProperty(childProperties[i]);
                    propertyAccess = Expression.MakeMemberAccess(propertyAccess, property);
                }
            }
            else
            {
                property = typeof(T).GetProperty(ordering);
                propertyAccess = Expression.MakeMemberAccess(parameter, property);
            }
            var orderByExp = Expression.Lambda(propertyAccess, parameter);
            var resultExp = Expression.Call(
              typeof(Queryable),
              ascending ? "OrderBy" : "OrderByDescending",
              new[] { type, property.PropertyType },
              source.Expression,
              Expression.Quote(orderByExp));
            return source.Provider.CreateQuery<T>(resultExp);
        }


        //static Expression<Func<T, bool>> GetExpression<T>(string propertyName, string propertyValue)
        //{
        //    var parameterExp = Expression.Parameter(typeof(T), "type");
        //    var propertyExp = Expression.Property(parameterExp, propertyName);

        //}

        /// <summary>  
        /// Cria o predicado.  
        /// </summary>  
        /// <param name="item">Item de expressão.</param>  
        /// <param name="filter">O modelo de filtro.</param>  
        /// <returns>Predicado do filtro.</returns>  
        private static Expression MakePredicate(ParameterExpression item, ExpressionModel filter)
        {
            try
            {
                var member = Expression.Property(item, filter.PropertyName);
                var constant = Expression.Constant(filter.Value);

                Expression left;
                Expression right = Expression.Call(constant, typeof(string).GetMethod("ToLower", Type.EmptyTypes));

                switch (member.Type.ToString())
                {
                    case "System.Decimal":
                        left = Expression.Call(member, typeof(decimal).GetMethod("ToString", Type.EmptyTypes));
                        break;
                    case "System.Nullable`1[System.DateTime]":
                        left = Expression.Call(member, typeof(Nullable<DateTime>).GetMethod("ToString", Type.EmptyTypes));
                        break;
                    case "System.Nullable`1[System.Int32]":
                        left = Expression.Call(member, typeof(Nullable<int>).GetMethod("ToString", Type.EmptyTypes));
                        break;
                    case "System.Int32":
                        //left= Expression.Call(Expression.Call(propertyAccess, propertyAccess.Type.GetMethod("ToString", System.Type.EmptyTypes)), typeof(string).GetMethod("ToLower", System.Type.EmptyTypes));
                        left = Expression.Call(member, typeof(int).GetMethod("ToString", Type.EmptyTypes));
                        break;
                    case "System.Boolean":
                        left = Expression.Call(member, typeof(bool).GetMethod("ToString", Type.EmptyTypes));
                        break;
                    case "System.DateTime":
                        left = Expression.Call(member, typeof(DateTime).GetMethod("ToString", Type.EmptyTypes));
                        break;
                    default:
                        left = Expression.Call(member,  typeof(string).GetMethod("ToLower", Type.EmptyTypes));
                        break;
                }

                switch (filter.Operator)
                {
                    case ExpressionOperators.Equals:
                        return Expression.Equal(member, constant);
                    case ExpressionOperators.GreaterThan:
                        return Expression.GreaterThan(member, constant);
                    case ExpressionOperators.LessThan:
                        return Expression.LessThan(member, constant);
                    case ExpressionOperators.GreaterThanOrEqual:
                        return Expression.GreaterThanOrEqual(member, constant);
                    case ExpressionOperators.LessThanOrEqual:
                        return Expression.LessThanOrEqual(member, constant);
                    case ExpressionOperators.Contains:
                        return Expression.Call(left, containsMethod, right);
                    case ExpressionOperators.StartsWith:
                        return Expression.Call(member, startsWithMethod, constant);
                    case ExpressionOperators.EndsWith:
                        return Expression.Call(member, endsWithMethod, constant);
                }
            }
            catch (Exception e)
            {
                var x = e.Message;
            }
            return null;
        }
    }
}
