using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Linq.Expressions;
using Newtonsoft.Json;
using System.Text.Json;
using smartfy.portal_api.presentation.UI.Web.DataTables;

namespace smartfy.portal_api.presentation.UI.Web.Datatables
{
    public class DataTablePager<T>
    {
        private const string INDIVIDUAL_SEARCH_KEY_PREFIX = "search";
        private const string INDIVIDUAL_SORT_KEY_PREFIX = "order";
        private const string INDIVIDUAL_SORT_DIRECTION_KEY_PREFIX = "sSortDir_";
        private const string DISPLAY_START = "iDisplayStart";
        private const string DISPLAY_LENGTH = "iDisplayLength";
        private const string ECHO = "sEcho";
        private const string ASCENDING_SORT = "asc";
        private const string GENERIC_SEARCH = "sSearch";

        private IQueryable<T> queryable;
        private readonly Type type;
        private readonly PropertyInfo[] properties;
        private List<NameValuePair<string, string>> aoDataList;
        private List<string> sortKeyPrefix;

        private int displayStart;
        private int displayLength;
        private int echo;
        private string genericSearch;

        private T DataSet { get; set; }

        public DataTablePager(string jsonAOData, IQueryable<T> queryable)
        {
            this.queryable = queryable;
            this.type = typeof(T);
            this.properties = this.type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            this.aoDataList = new List<NameValuePair<string, string>>();
            this.sortKeyPrefix = new List<string>();
            PrepAOData(jsonAOData);
        }
        #region Methods

        /// <summary>
        /// Apply the search terms to all the columns in the data set
        /// </summary>
        /// <returns>Data set as FormattedList</returns>
        public FormattedList Filter(bool sort = true)
        {
            var formattedList = new FormattedList();

            //  What are the columns in the data set
            formattedList.Import(this.properties.Select(x => x.Name + ",")
                                                 .ToArray());

            //  Return same sEcho that was posted.  Prevents XSS attacks.
            formattedList.sEcho = this.echo;

            //  Return count of all records
            formattedList.iTotalRecords = this.queryable.Count();

            //  Filtered Data
            var records = this.queryable.Where(GenericSearchFilter());
            if (sort)
            {
                records = ApplySort(records);
            }


            //  What is filtered data set count now.  This is NOT the 
            //  count of what is returned to client
            formattedList.iTotalDisplayRecords = (records.FirstOrDefault() == null) ? 0 : records.Count();

            //  Take a page
            var pagedRecords = records.Skip(this.displayStart)
                     .Take(this.displayLength);

            //  Convert to List of List<string>
            var aaData = new List<List<string>>();
            var thisRec = new List<string>();

            pagedRecords.ToList()
                    .ForEach(rec => aaData.Add(rec.PropertiesToList()));
            formattedList.aaData = aaData;

            return formattedList;
        }

        /// <summary>
        /// Parse the aoDataObject structure and retrieve the following items:
        /// 
        /// </summary>
        /// <param name="aoDataObject"></param>
        private void PrepAOData(string aoData)
        {
            Enforce.That(string.IsNullOrEmpty(aoData) == false,
                            "DataTablePager.PrepAOData - aoData é nulo ou vazio, não pode");

            //this.aoDataList = System.Web.Helpers.Json.Decode<List<NameValuePair<string, string>>>(aoData);
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };
            this.aoDataList = System.Text.Json.JsonSerializer.Deserialize<List<NameValuePair<string, string>>>(aoData, options);
            Enforce.That(int.TryParse(aoDataList.GetNVValue(ECHO), out this.echo),
                                   "DataTableFilters.PrepAOData - não pode converter sEcho");

            Enforce.That(int.TryParse(aoDataList.GetNVValue(DISPLAY_START), out this.displayStart),
                                    "DataTableFilters.PrepAOData - não pode converter iDisplayStart");

            Enforce.That(int.TryParse(aoDataList.GetNVValue(DISPLAY_LENGTH), out this.displayLength),
                                    "DataTableFilters.PrepAOData - não pode converter iDisplayLength");

            this.genericSearch = aoDataList.GetNVValue(GENERIC_SEARCH);

            //  Sort columns
            this.sortKeyPrefix = aoDataList.Where(x => x.Name.StartsWith(INDIVIDUAL_SORT_KEY_PREFIX))
                                            .Select(x => x.Value)
                                            .ToList();
        }

        /// <summary>
        /// Create a Lambda Expression that is chain of Or Expressions
        /// for each column.  Each column will be tested if it contains the
        /// generic search string.  
        /// 
        /// Query logic = (or ... or ...) And (or ... or ...)
        /// </summary>        
        /// <returns>Expression of T, bool</returns>
        private Expression<Func<T, bool>> GenericSearchFilter()
        {
            //  When no properties or search terms, return a true expression
            if (string.IsNullOrEmpty(this.genericSearch) || this.properties.Length == 0)
            {
                return x => true;
            }

            var paramExpression = Expression.Parameter(this.type, "val");
            Expression compoundOrExpression = Expression.Call(Expression.Property(paramExpression, this.properties[0]), "ToString", null);
            Expression compoundAndExpression = Expression.Call(Expression.Property(paramExpression, this.properties[0]), "ToString", null);
            MethodInfo convertToString = typeof(Convert).GetMethod("ToString", Type.EmptyTypes);

            //  Split search expression to handle multiple words
            var searchTerms = this.genericSearch.Split(' ');

            for (int i = 0; i < searchTerms.Length; i++)
            {
                var searchExpression = Expression.Constant(searchTerms[i].ToLower());

                //  For each property, create a contains expression
                //  column => column.ToLower().Contains(searchTerm)                
                var propertyQuery = (from property in this.properties
                                     let toStringMethod = Expression.Call(
                                                         Expression.Call(Expression.Property(paramExpression, property), convertToString, null),
                                                             typeof(string).GetMethod("ToLower", new Type[0]))
                                     select Expression.Call(toStringMethod, typeof(string).GetMethod("Contains"), searchExpression)).ToArray();

                for (int j = 0; j < propertyQuery.Length; j++)
                {
                    //  Nothing to "or" to yet
                    if (j == 0)
                    {
                        compoundOrExpression = propertyQuery[0];
                    }

                    compoundOrExpression = Expression.Or(compoundOrExpression, propertyQuery[j]);
                }

                //  First time around there is no And, only first set of or's
                if (i == 0)
                {
                    compoundAndExpression = compoundOrExpression;
                }
                else
                {
                    compoundAndExpression = Expression.And(compoundAndExpression, compoundOrExpression);
                }
            }

            //  Create Lambda
            return Expression.Lambda<Func<T, bool>>(compoundAndExpression, paramExpression);
        }

        /// <summary>
        /// Sort the queryable items according to column selected
        /// </summary>
        private IQueryable<T> ApplySort(IQueryable<T> records)
        {
            string firstSortColumn = this.sortKeyPrefix.First();
            int firstColumn = int.Parse(firstSortColumn);

            string sortDirection = "asc";
            sortDirection = this.aoDataList.Where(x => x.Name == INDIVIDUAL_SORT_DIRECTION_KEY_PREFIX +
                                                                      "0")
                                                .Single()
                                                .Value
                                                .ToLower();

            if (string.IsNullOrEmpty(sortDirection))
            {
                sortDirection = "asc";
            }

            return records.OrderBy(this.properties[firstColumn].Name, sortDirection, true);
        }

        #endregion
    }
}