using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IBSC.Common
{
    public static class ConvertCommon
    {
        public static string ConvertDateTime(DateTime date)
        {
            string year = date.Year > 2500 ? (date.Year - 543).ToString() : date.Year.ToString();
            string month = date.Month.ToString();
            string day = date.Day.ToString();
            return year + "-" + month + "-" + day;
        }
    }
}
