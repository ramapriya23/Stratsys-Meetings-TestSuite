using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StratsysMeetingsTestSuite
{
    public class CheckDate
    {
        static string[] months = {"Jan","Feb","Mar","Apr","May","Jun","July","Aug","Sep","Oct","Nov","Dec"};
        
        public static int isSelectedYear(string year, string monthDisplay)
        {
            

            if (!monthDisplay.Contains(year))
            {

                int toYear = Convert.ToInt32(year);
                int currentYear = Convert.ToInt32(monthDisplay.Substring(5, monthDisplay.Length));

                int diff = toYear - currentYear;

                if (diff < 0)
                {
                    return -1;
                }
                else
                {
                    if(!monthDisplay.Contains(year))
                    {
                        return 0;
                    }

                }
            }
            return 1;

        }
        public static int  isSelectedMonth(string month, string monthDisplay)
        {
            
           
            if (!monthDisplay.Contains(month))
            {
                int indexofMonthDisplay = Array.IndexOf(months, monthDisplay.Substring(0, 3));
                int indexOfMonth = Array.IndexOf(months, month);

                if (indexOfMonth < indexofMonthDisplay)
                {
                    return -1;
                }
                else
                {
                    return 0;
                }
            }
            return 1;
        }
    }
}
