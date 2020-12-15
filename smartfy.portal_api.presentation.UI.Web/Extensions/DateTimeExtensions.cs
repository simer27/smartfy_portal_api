using smartfy.portal_api.domain.Entities;
using System;

namespace smartfy.portal_api.presentation.UI.Web.Extensions
{
    //Toda extension tem que ser PUBLIC STATIC
    public static class DateTimeExtensions
    {
        //RESUMINDO: EXTENSION...............EH................VIDA
        //RESUMINDO: EXTENSION...............EH................uma funcao que eu criei, nao o dono da classe

        //Toda funcao de extension tem que ser PUBLIC STATIC
        //Todo o primeiro PARAMETRO das extensions eh a classe/objeto a ser estendido/to be extended (this)
        public static bool IsValid(this DateTime dt)
        {
            return dt.Year > 1900;
        }

        public static DateTime ToFirstDayOfMonth(this DateTime dt) // 15/01/2020
        {
            return new DateTime(dt.Year, dt.Month, 1);
        }

        //dt    = 10/01
        //begin = 05/01
        //end   = 30/01
        public static bool IsBetween(this DateTime dt, DateTime begin, DateTime end) => dt >= begin && dt <= end;
        //{
            //return 10/01 >= 05/01  && 10/01 <= 30/01;
        //}

        //[TestCase("26/10/2020")] = 31 
        //[TestCase("26/11/2020")] = 30 
        //[TestCase("26/02/2020")] = 28 ou 29
        public static DateTime ToLastDayOfMonthDummy(this DateTime dt) //Dummy means Forced ou Fake
        {
            var lastDay = 30;
            switch ((Mes)dt.Month)
            {
                case Mes.Fev:
                    lastDay = 28;
                    break;
                case Mes.Jan:
                case Mes.Mar:
                case Mes.Mai:
                case Mes.Jul:
                case Mes.Ago:
                case Mes.Out:
                case Mes.Dez:
                    lastDay = 31;
                    break;
            }

            return new DateTime(dt.Year, dt.Month, lastDay);
        }

        //[TestCase("26/10/2020")] = 31 
        //[TestCase("26/11/2020")] = 30 
        //[TestCase("26/02/2020")] = 28 ou 29
        public static DateTime ToLastDayOfMonthSmartest(this DateTime dt) //Dummy means Forced ou Fake
        {
            var dtNextMonth = dt.AddMonths(1);                          //26/03/2020
            var dtFirstDayNextMonth = dtNextMonth.ToFirstDayOfMonth();  //01/03/2020
            var dtLastDay = dtFirstDayNextMonth.AddDays(-1);            //29/02/2020
            return dtLastDay;
        }
    }

    public enum Mes
    {
        Jan = 1,
        Fev,
        Mar,
        Abr,
        Mai,
        Jun,
        Jul,
        Ago,
        Set,
        Out,
        Nov,
        Dez
    }

    public static class ProdutoExtensions
    {
        public static bool IsVencido(this Produto produto)
        {
            return produto.DtVencimento < DateTime.Now;
        }
    }
}
