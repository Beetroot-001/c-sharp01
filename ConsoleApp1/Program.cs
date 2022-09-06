using System.ComponentModel;
using System;

namespace Hometask2_DataTypes
{
    internal class Program
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="startDate">The start date</param>
        /// <param name="endDate">The end day</param>
        /// <param name="searchDay">The searched day</param>
        /// <returns>Return the number of days of the week within the mentiond period. Return 0 if the searched day doesn't exist. </returns>

        public static int CountMondays(DateTime startDate, DateTime endDate, string searchDay)
        {
            for (int j = 0; j < 7; j++)
            {
                if (searchDay.ToLower() == Convert.ToString(DateTime.Today.AddDays(j).DayOfWeek).ToLower())
                {
                    TimeSpan daysNumber = endDate - startDate;

                    int daysCount = daysNumber.Days / 7;
                    int leftDays = daysNumber.Days % 7;

                    for (int i = 1; i <= leftDays; i++)
                    {
                        endDate = endDate.AddDays(-1);
                        if (Convert.ToString(endDate.DayOfWeek).ToLower() == searchDay.ToLower())
                        {
                            daysCount++;
                            break;
                        }
                    }
                    return daysCount;
                }
            }
            return 0;
        }



        static void Main(string[] args)
        {
            //DateTime newYear = new DateTime(2022, 12, 31);
            //DateTime today = DateTime.Today;

            //Console.WriteLine(today);

            //Console.WriteLine($"Осталось дней до НГ: {(newYear - today).Days}"); 
            //Console.WriteLine($"Прошло дней после НГ: {(today - new DateTime(2022,1,1)).Days}");

            //TimeSpan daysLeft = newYear - today;
            //Console.WriteLine(daysLeft);




            //////////////Homework 1/////////////
            Console.WriteLine("/////////////Homework 1/////////////");
            int x = 5;
            int y = 12;

            int result1 = -6 * x ^ 3 + 5 * x ^ 2 - 10 * x + 15;
            Console.WriteLine("-6 * x ^ 3 + 5 * x ^ 2 - 10 * x + 15");
            Console.WriteLine($"Result1: {result1}\n");

            Console.WriteLine("abs(x) * sin(x)");
            double result2 = Math.Abs(x) * Math.Sin(x);
            Console.WriteLine($"Result2: {result2}\n");

            Console.WriteLine("2 * pi * x");
            double result3 = 2 * Math.PI * x;
            Console.WriteLine($"Result3: {result3}\n");

            Console.WriteLine("max(x, y)");
            int result4 = Math.Max(x, y);
            Console.WriteLine($"Result4: {result4}\n");









            ///////////SUPER EXTRA HOMEWORK//////////////
            Console.WriteLine("///////////SUPER EXTRA HOMEWORK//////////////");

            Console.WriteLine("Find out the number of days of week witihn the required period of time");
            
            Console.WriteLine("\nEnter the start date");
            DateTime startDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine("\nEnter the end date");
            DateTime endDate = Convert.ToDateTime(Console.ReadLine());

            Console.WriteLine($"\nEnter the day of the week you want to count from {startDate.ToShortDateString()} till {endDate.ToShortDateString()}");
            string searchDay = Console.ReadLine();

            int result = CountMondays(startDate, endDate, searchDay);

            Console.WriteLine($"\nThe number of {searchDay}s from {startDate.ToShortDateString()} till {endDate.ToShortDateString()} equals {result}");
            

        }
    }
}