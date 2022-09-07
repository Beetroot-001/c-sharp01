namespace homework_less3_EXTR
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*************** Lesson 3, SUPER EXTRA HOMEWORK ***************");


            DateTime date1 = new DateTime(2022, 09, 01);
            DateTime date2 = new DateTime(2022, 12, 15);

            int numberOfMondays = 0;

            for (DateTime date = date1; date < date2; date = date.AddDays(1)) // честно загугли только каким оператором сделать перебор, через "while !=" не смог.
            {
                if (date.DayOfWeek == DayOfWeek.Monday) numberOfMondays++;
            }
            Console.WriteLine("Count number of Mondays:  " + numberOfMondays);

        }
    }
}