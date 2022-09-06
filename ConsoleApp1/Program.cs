using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Sec2nd_Lesson
{

    internal class Program
    {
        


        static void Main(string[] args)
        {
            Random random = new Random();
            byte[] bytes = new byte[4];
            random.NextBytes(bytes);
            byte b = bytes[0];
            short s = (short)random.Next(32767);
            int i = random.Next();
            byte[] longByte = new byte[8];
            random.NextBytes(longByte);
            long l = BitConverter.ToInt64(longByte, 0);
            bool bo = random.NextDouble() > 0.5;
            char c = (char)random.Next('a', 'z');
            float f = (float)random.NextDouble();
            double d = random.NextDouble();
            decimal de = (decimal)random.NextDouble();
            string str = "The quick brown fox jumps over the lazy dog";            
            

            Console.WriteLine($" \r \n 1. byte b = {b} \n 2. short s = {s} \n 3. int i = {i} \n 4. long l = {l} \n 5. bool bo = {bo} \n 6. char c = {c} \n 7. float f = {f} \n 8. double d = {d} \n 9. decimal de = {de} \n 10. string str = {str} \n 11. Count My MONDAYS please");
            Console.WriteLine();
            int answer = int.Parse(Console.ReadLine());
            int result1; 
            double result2;
            double result3;
            switch (answer)
            {
                case 1:
                    result1 =- 6 * b ^ 3 + 5 * b ^ 2 - 10 * b + 15;
                    Console.WriteLine("byte b -6*x^3+5*x^2-10*x+15 = ");
                    Console.WriteLine(result1);
                    result2 = Math.Abs(b) * Math.Sin(b);
                    Console.WriteLine("abs(b)*cos(b) = ");
                    Console.WriteLine(result2);
                    Console.WriteLine("2*Pi*b = ");
                    result3 = 2 * Math.PI * b;
                    Console.WriteLine(result3);
                    Console.WriteLine("Max of b = " + Math.Max(b, b));

                    break;
                    case 2:
                    Console.WriteLine("short s =" + s);
                    result1 =- 6 * s ^ 3 + 5 * s ^ 2 - 10 * s + 15;
                    Console.WriteLine("short s -6*x^3+5*x^2-10*x+15 = ");
                    Console.WriteLine(result1);
                    result2 = Math.Abs(s) * Math.Sin(s);
                    Console.WriteLine("abs(b)*cos(b) = ");
                    Console.WriteLine(result2);
                    Console.WriteLine("2*Pi*b = ");
                    result3 = 2 * Math.PI * s;
                    Console.WriteLine(result3);
                    Console.WriteLine("Max of s = " + Math.Max(s, s));
                    break;
                    case 3:
                    Console.WriteLine("int i =" + i);
                    result1 =- 6 * i ^ 3 + 5 * i ^ 2 - 10 * i + 15;
                    Console.WriteLine("int i -6*x^3+5*x^2-10*x+15 = ");
                    Console.WriteLine(result1);
                    result2 = Math.Abs(l) * Math.Sin(l);
                    Console.WriteLine("abs(i)*cos(i) = ");
                    Console.WriteLine(result2);
                    Console.WriteLine("2*Pi*i = ");
                    result3 = 2 * Math.PI * l;
                    Console.WriteLine(result3);
                    Console.WriteLine("Max of i = " + Math.Max(l, l));
                    break;
                case 4:
                    Console.WriteLine("long l =" + l);
                    long res1 =- 6 * l ^ 3 + 5 * l ^ 2 - 10 * l + 15;
                    Console.WriteLine("byte b -6*x^3+5*x^2-10*x+15 = ");
                    Console.WriteLine(res1);
                    result2 = Math.Abs(l) * Math.Sin(l);
                    Console.WriteLine("abs(l)*cos(l) = ");
                    Console.WriteLine(result2);
                    Console.WriteLine("2*Pi*l = ");
                    result3 = 2 * Math.PI * l;
                    Console.WriteLine(result3);
                    Console.WriteLine("Max of l = " + Math.Max(l, l));
                    break;
                case 5:                    
                    
                    Console.WriteLine($"Bool is feeling {bo} today");
                    break;
                case 6:                                       
                    Console.WriteLine($"char c feels {c} at the moment");
                    break;
                case 7:
                    Console.WriteLine("float f=" + f);
                    
                    result1 = -6 * (int)f ^ 3 + 5 * (int)f ^ 2 - 10 * (int)f + 15;
                    Console.WriteLine("float f -6*x^3+5*x^2-10*x+15 = ");
                    Console.WriteLine(result1);
                    result2 = Math.Abs(f) * Math.Sin(f);
                    Console.WriteLine("abs(f)*cos(f) = ");
                    Console.WriteLine(result2);
                    Console.WriteLine("2*Pi*f = ");
                    result3 = 2 * Math.PI * f;
                    Console.WriteLine(result3);
                    Console.WriteLine("Max of f = " + Math.Max(f, f));
                    break;
                case 8:
                    Console.WriteLine("double d=" + d);
                    result1 = -6 * (int)d ^ 3 + 5 * (int)d ^ 2 - 10 * (int)d + 15;
                    Console.WriteLine("float f -6*x^3+5*x^2-10*x+15 = ");
                    Console.WriteLine(result1);
                    result2 = Math.Abs(d) * Math.Sin(d);
                    Console.WriteLine("abs(d)*cos(d) = ");
                    Console.WriteLine(result2);
                    Console.WriteLine("2*Pi*d = ");
                    result3 = 2 * Math.PI * d;
                    Console.WriteLine(result3);
                    Console.WriteLine("Max of d = " + Math.Max(d, d));

                    break;
                case 9:
                    Console.WriteLine("decimal de =");
                    result1 = -6 * (int)de ^ 3 + 5 * (int)de ^ 2 - 10 * (int)de + 15;
                    Console.WriteLine("float f -6*x^3+5*x^2-10*x+15 = ");
                    Console.WriteLine(result1);
                    result2 = Math.Abs((double)de) * Math.Sin((double)de);
                    Console.WriteLine("abs(de)*cos(de) = ");
                    Console.WriteLine(result2);
                    Console.WriteLine("2*Pi*de = ");
                    result3 = 2 * Math.PI * (double)de;
                    Console.WriteLine(result3);
                    Console.WriteLine("Max of de = " + Math.Max(de, de));
                    break;
                case 10:
                    Console.WriteLine("string str =");
                    Console.WriteLine(str);
                    break;
                case 11:
                    Console.WriteLine("Start year in mm/dd/yyyy = ");
                    DateTime startYear = DateTime.Parse (Console.ReadLine());

                    Console.WriteLine("End year in mm/dd/yyyy = ");

                    DateTime endYear = DateTime.Parse(Console.ReadLine());

                    var diffYears = endYear - startYear;
                    int mondayCount = diffYears.Days / 7;
                    

                    

                    Console.WriteLine($"In this period of time will be {mondayCount} Mondays. FeelsBadMan :(");



                    break;

            }
          
            DateTime date1 = DateTime.Now;
            DateTime date2 = new DateTime(2022, 1, 1);

            var toNY = date2.AddYears(1) - date1;
            Console.WriteLine($"\n {toNY.Days} days left to New Year");

            var fromNY = date1 - date2;
            Console.WriteLine($"\n {fromNY.Days} days passed from New Year");

            



            
        }
    }
}
