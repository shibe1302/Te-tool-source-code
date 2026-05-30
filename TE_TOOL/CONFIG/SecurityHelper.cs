using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QANotebook
{
    public class SecurityHelper
    {
        public static string GenerateDailyPassword()
        {
            DateTime now = DateTime.Now;
            int day = now.Day;
            int month = now.Month;
            int processedDay;
            return $"SW{now:mmMMdd}";
        }

    }
}
