using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string first = "abcde";
            string second = "abcse";
            string third = "What a \n gr8 park 4 sk8 ;-+=*";
            string fourth = "HelloDDaa";
            string fifth = "Hello and hi";


            Console.WriteLine(Compare(first, second));
            Analyze(third);
            Console.WriteLine(Sort(fourth));
            StringBuilder stringBuilder = new StringBuilder();
            Console.WriteLine(stringBuilder.Append(Duplicate(fifth)));
        }

        static bool Compare(string a, string b)
        {
            if (a.Length != b.Length)
            {
                return false;

            }
            else
            {
                bool result = true;

                for (int i = 0; i < a.Length; i++)
                {
                    if (a[i] != b[i])
                    {
                        result = false;
                    }
                }

                return result;

            }
        }

        static void Analyze(string a)
        {
            int alphabetic = 0;
            int digit = 0;
            int special = 0;
            for (int i = 0; i < a.Length; i++)
            {
                char c = a[i];
                if (Char.IsLetter(c))
                {
                    alphabetic++;
                }
                else if (Char.IsDigit(c))
                {
                    digit++;
                }
                else
                {
                    special++;

                }
            }
            Console.WriteLine($"\"{a}\" consists of {alphabetic} alphabetic, {digit} digit and {special} special chars.");
        }

        static string Sort(string a)
        {
            StringBuilder stringBuilder = new StringBuilder();

            a = a.ToLowerInvariant();
            char[] array = a.ToCharArray(0, a.Length);
            Array.Sort(array);
            stringBuilder.Append(array);
            return stringBuilder.ToString();

        }

        static char[] Duplicate(string a)
        {


            //
            StringBuilder ab1 = new StringBuilder();

            string aLower = a.ToLowerInvariant();

            
            for (int i = 0; i < aLower.Length; i++)
            {
                for (int j = 0; j < aLower.Length; j++)
                {
                    var checkVariable = aLower[i];
                    aLower

                }
            }
            Char[] chArray = new Char[aLower.Length];
            return chArray;
        }
    }
}