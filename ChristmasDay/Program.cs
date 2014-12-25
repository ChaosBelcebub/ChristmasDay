using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChristmasDay
{
    class Program
    {
        public List<string> days = new List<string>();
        public List<string> daysRevert = new List<string>();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Program()
        {
            days.Add("Monday");
            days.Add("Tuesday");
            days.Add("Wednesday");
            days.Add("Thursday");
            days.Add("Friday");
            days.Add("Saturday");
            days.Add("Sunday");

            daysRevert.Add("Sunday");
            daysRevert.Add("Saturday");
            daysRevert.Add("Friday");
            daysRevert.Add("Thursday");
            daysRevert.Add("Wednesday");
            daysRevert.Add("Tuesday");
            daysRevert.Add("Monday");
        }

        /// <summary>
        /// Calculate the day of Christmas
        /// </summary>
        /// <param name="year"></param>
        /// <returns></returns>
        public string calculate(int year)
        {
            // Christmasday in 2014 is on Wendnesday
            int defDay = 2;
            int defDayRevert = 4;
            int defYear = 2014;
            // If year is 2014 return the definition day
            if (year == defYear)
            {
                return "Christmas is on " + days[defDay] + "!";
            }
            // calculate the difference between year and 2014
            int diff = 2014 - year;
            int count = 0;
            while (year != defYear)
            {
                if (diff > 0)
                {
                    defYear -= 1;
                    if (leapYear(defYear + 1) == true && defYear + 1 != year)
                    {
                        count -= 2;
                    }
                    else
                    {
                        count -= 1;
                    }
                }
                else
                {
                    defYear += 1;
                    if (leapYear(defYear) == true)
                    {
                        count += 2;
                    }
                    else
                    {
                        count += 1;
                    }
                }
            }
            if (count > 0) { return "Christmas is on " + days[(count + defDay) % 7] + "!"; }
            else { return "Christmas is on " + daysRevert[((count) * -1 + defDayRevert) % 7] + "!"; }
        }

        /// <summary>
        /// Calculate if year is a leapyear
        /// </summary>
        /// <param name="year"></param>
        /// <returns>True or False</returns>
        public bool leapYear(int year)
        {
            if (year % 400 == 0)
            {
                return true;
            }
            else if (year % 100 == 0)
            {
                return false;
            }
            else if (year % 4 == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
