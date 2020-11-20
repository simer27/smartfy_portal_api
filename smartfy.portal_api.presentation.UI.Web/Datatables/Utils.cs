using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace smartfy.portal_api.presentation.UI.Web.DataTables
{
    [Serializable]
    public class NameValuePair<TName, TValue>
    {
        public TName Name { get; set; }
        public TValue Value { get; set; }

        public NameValuePair(TName name, TValue value)
        {
            Name = name;
            Value = value;
        }

        public NameValuePair() { }
    }

    public class FormattedList
    {
        public FormattedList()
        {
        }

        public int sEcho { get; set; }
        public int iTotalRecords { get; set; }
        public int iTotalDisplayRecords { get; set; }
        public List<List<string>> aaData { get; set; }
        public string sColumns { get; set; }

        public string aoColumnDefs { get; set; }

        public void Import(string[] properties)
        {
            sColumns = string.Empty;
            for (int i = 0; i < properties.Length; i++)
            {
                sColumns += properties[i];
                if (i < properties.Length - 1)
                    sColumns += ",";
            }

            //aoColumnDefs = "{ \"targets\": -1, \"data\": null, \"defaultContent\": \"<div class='rating small'></div>\" },{ \"targets\": 0, \"mData\": 4 },{ \"targets\": 1, \"mData\": 6 },{ \"targets\": 2, \"data\": null, \"defaultContent\": \"<div class='icon-help'></div>\" }";

        }
    }

    public static class Extensions
    {
        public static List<string> PropertiesToList<T>(this T obj)
        {
            var propertyList = new List<string>();
            var properties = typeof(T).GetProperties();

            propertyList = properties.Select(prop => (prop.GetValue(obj, new object[0]) ?? string.Empty).ToString())
                                        .ToList();

            return propertyList;
        }

        /// <summary>
        /// Author:  Marc Gravell & others from StackOverflow
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source">List of T as Queryable</param>
        /// <param name="property">Name of propertu as string</param>
        /// <param name="sortDirection">ASC or DESC as string</param>
        /// <param name="initial">First Ordered operation indicator as bool</param>
        /// <returns>Order collection as IQueryable of T</returns>
        public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string property, string sortDirection, bool initial)
        {
            string[] props = property.Split('.');
            Type type = typeof(T);
            ParameterExpression arg = Expression.Parameter(type, "x");
            Expression expr = arg;
            foreach (string prop in props)
            {
                // use reflection (not ComponentModel) to mirror LINQ
                PropertyInfo pi = type.GetProperty(prop);
                expr = Expression.Property(expr, pi);
                type = pi.PropertyType;
            }
            Type delegateType = typeof(Func<,>).MakeGenericType(typeof(T), type);
            LambdaExpression lambda = Expression.Lambda(delegateType, expr, arg);

            string methodName = string.Empty;

            //  Asc or Desc
            if (sortDirection.ToLower() == "asc")
            {
                //  First clause?
                if (initial && source is IOrderedQueryable<T>)
                {
                    methodName = "OrderBy";
                }
                else
                {
                    methodName = "ThenBy";
                }
            }
            else
            {
                if (initial && source is IOrderedQueryable<T>)
                {
                    methodName = "OrderByDescending";
                }
                else
                {
                    methodName = "ThenByDescending";
                }
            }

            object result = typeof(Queryable).GetMethods().Single(
                    method => method.Name == methodName
                            && method.IsGenericMethodDefinition
                            && method.GetGenericArguments().Length == 2
                            && method.GetParameters().Length == 2)
                    .MakeGenericMethod(typeof(T), type)
                    .Invoke(null, new object[] { source, lambda });
            return (IOrderedQueryable<T>)result;
        }                
    }

    public static class Enforce
    {
        public static T ArgumentNotNull<T>(T argument, string description)
            where T : class
        {
            if (argument == null)
                throw new ArgumentNullException(description);

            return argument;
        }

        public static T ArgumentGreaterThanZero<T>(T argument, string description)
        {
            if (System.Convert.ToInt32(argument) < 1)
                throw new ArgumentOutOfRangeException(description);

            return argument;
        }

        public static DateTime ArgumentDateIsInitialized(DateTime argument, string description)
        {
            if (argument == DateTime.MinValue)
                throw new ArgumentException("Data não inicializada");

            return argument;
        }

        public static Dictionary<T, K> ContainsKey<T, K>(Dictionary<T, K> search,
                                                                T key,
                                                                string description)
        {
            if (search.ContainsKey(key) == false)
            {
                throw new KeyNotFoundException(description);
            }

            return search;
        }

        public static void That(bool condition, string message)
        {
            if (condition == false)
            {
                throw new Exception(message);
            }
        }
    }

    public static class PredicateBuilder
    {
        public static Expression<Func<T, bool>> True<T>() { return f => true; }
        public static Expression<Func<T, bool>> False<T>() { return f => false; }

        public static Expression<Func<T, bool>> Or<T>(this Expression<Func<T, bool>> expr1,
                                                            Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.OrElse(expr1.Body, invokedExpr), expr1.Parameters);
        }

        public static Expression<Func<T, bool>> And<T>(this Expression<Func<T, bool>> expr1,
                                                             Expression<Func<T, bool>> expr2)
        {
            var invokedExpr = Expression.Invoke(expr2, expr1.Parameters.Cast<Expression>());
            return Expression.Lambda<Func<T, bool>>
                  (Expression.AndAlso(expr1.Body, invokedExpr), expr1.Parameters);
        }
    }

    static class KVPredicate
    {
        public static Expression<Func<NameValuePair<string, string>, bool>> KeyPredicate(string name)
        {
            var predicate = PredicateBuilder.True<NameValuePair<string, string>>();
            predicate = predicate.And<NameValuePair<string, string>>(nv => nv.Name == name);

            return predicate;
        }

        public static Expression<Func<NameValuePair<string, string>, bool>> ValueIs(string name, string value)
        {
            var predicate = PredicateBuilder.True<NameValuePair<string, string>>();
            predicate = predicate.And<NameValuePair<string, string>>(nv => nv.Value == value);

            return predicate;
        }

        public static string GetNVValue(this List<NameValuePair<string, string>> nvPairs, string name)
        {
            return nvPairs.AsQueryable()
                            .Where(KeyPredicate(name))
                            .SingleOrDefault()
                            .Value;
        }
    }

    public class DiacriticsHelper
    {
        public bool ContainsNoDiacritics(ref string s,string value)
        {
            return s.Contains(value.RemoveDiacritics());
        }
    }
    
    public static class Diacritics
    {
        public static string RemoveDiacritics(this string text) 
        {
            var normalizedString = text.Normalize(NormalizationForm.FormD);
            var stringBuilder = new StringBuilder();
 
            foreach (var c in normalizedString)
            {
                var unicodeCategory = CharUnicodeInfo.GetUnicodeCategory(c);
                if (unicodeCategory != UnicodeCategory.NonSpacingMark)
                {
                    stringBuilder.Append(c);
                }
            }
 
            return stringBuilder.ToString().Normalize(NormalizationForm.FormC);
        }
        
    }
}