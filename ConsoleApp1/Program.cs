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


            DateTime startDate = DateTime.Today;
            DateTime endDate = new DateTime(2022, 9, 21);





            int result = CountMondays(startDate, endDate, "tuesday");

            Console.WriteLine(result);


        }
    }
}