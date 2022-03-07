using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tutorial2
{
    internal class Program
    {
        /// <summary>
        /// Main
        /// checking leap year and calculating century
        /// </summary>
        /// <param name="args"></param>
        private static void Main(string[] args)
        {
            int year;
            Console.Write("Input year : ");
            year = Convert.ToInt32(Console.ReadLine());
            GetCenturyAndCheckLeapYear(year);
            Console.ReadLine();
        }

        /// <summary>
        /// Get Century And Check LeapYear
        /// </summary>
        /// <param name="year"></param>
        public static void GetCenturyAndCheckLeapYear(int year)
        {
            int century;
            if (year % 400 == 0 || year >= 1000 && year % 4 == 0 && year % 100 != 0)
            {
                century = (year / 100) + 1;
                Console.WriteLine(century + "," + 1);
            }
            else
            {
                century = (year / 100) + 1;
                Console.WriteLine(century + "," + (-1));
            }
        }
    }
}