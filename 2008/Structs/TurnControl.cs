using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2008.Classes
{
    class TurnControl
    {
        public bool MonthDayYearFormat;
        public int Day, Month, Year, Turn;
        public string Date;

        public TurnControl()
        {
            MonthDayYearFormat = true;
            Day = 1;
            Month = 6;
            Year = 2008;
            Date = MonthDayYearFormat.ToString();
        }

        public void AdvanceTurn()
        {
            if (Day + 1 == 32 && (Month == 1 || Month == 3 || Month == 3 || Month == 5 || Month == 7 || Month == 8 || Month == 10 || Month == 12) || (Day + 1 == 29 && Month == 2) || Day + 1 == 31 && (Month == 4 || Month == 6 || Month == 9 || Month == 11))
            {
                Month = Month == 12 ? 1 : Month;
                Day = 1;
                Month++;
            }
            else if (Day == 31 && Month == 12)
            {
                Year++;
                Month = 1;
                Day = 1;
            }
            else
            {
                Day++;
            }
            
            Turn++;
            SetDate();
        }

        private void SetDate()
        {
            if (MonthDayYearFormat)
            {
                Date = Month.ToString() + "/" + Day.ToString() + "/" + Year.ToString();
            }
            else
            {
                Date = Day.ToString() + "/" + Month.ToString() + "/" + Year.ToString();
            }
        }
    }
}