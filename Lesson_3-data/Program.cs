using System;

namespace Lesson3
{
    internal class Program
    {
        static void Main(string[] args)
        {

            // Lesson 3, HW_Part1
            Console.WriteLine("*************** Lesson 3, HW part_1 ***************");

            byte aByte = 1;
            short aShort = 10;
            int aInt = -11;
            long aLong = 1;
            bool aBoolean = false;
            char aChar = 'a';
            float aFloat = 1.55f;
            double aDouble = 2.55;
            decimal aDecimal = 774.55m;
            string aString = "lesson3";
            var summ = (aByte + aLong) * aShort;
            summ += aInt;

            Console.WriteLine(summ);
            Console.WriteLine($"{aChar} + {aString} + {aBoolean} + {(aFloat / aDouble)}");

            // Lesson 3, HW_Part2
            Console.WriteLine("*************** Lesson 3, HW part_2 ***************");
            Random rand = new Random();
            int roll = rand.Next(0, 10);
            int roll2 = rand.Next(0, 10);

            int x = roll;
            double y = roll2;
            
            var summ2 = -6 * Math.Pow(x, 3) + 5 * Math.Pow (x, 2) - 10 * x + 15; // -6*x^3+5*x^2-10*x+15
            Console.WriteLine(summ2);

            var summ3 = Math.Abs(x)*Math.Sin(x); // abs(x)*sin(x)
            Console.WriteLine(summ3);

            var summ4 = 2*Math.PI*x; // 2*pi*x
            Console.WriteLine(summ4);

            var summ5 = Math.Max(x, y); // max(x, y)
            Console.WriteLine(summ5);


            // Lesson 3, HW_Part3
            Console.WriteLine("*************** Lesson 3, HW Extr ***************");

          
            DateTime newYear = new DateTime(2022, 12, 31);
            DateTime dateNow = DateTime.Now;
            TimeSpan leftNewYear = newYear - dateNow;
            Console.WriteLine("dd/h/min... left2NY2023: " + leftNewYear);
            Console.WriteLine("Days left: " + leftNewYear.Days);


            Console.WriteLine("{0} - {1} = {2}", newYear, dateNow, leftNewYear); // "{0} - {1} = {2}" - не понял это выражение, или плохо искал.
                                                                                 // в уч.мат так же не нашел (https://docs.microsoft.com/ru-ru/dotnet/api/system.timespan?view=net-6.0#code-try-5)
            

            


        }

    }
    }
