using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string first = "abcde";
            string second = "abcde ";
            string third = "What a \n gr8 park 4 sk8 ;-+=*";
            string fourth = "HelloDDaa";
            string fifth = "Hello and hi and i and hh44";

            Console.WriteLine(Compare(first, second));
            Analyze(third);
            Console.WriteLine(Sort(fourth));
            Console.WriteLine(String.Join(", ", Duplicate(fifth)));  
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
            char[] array = a.ToLowerInvariant().ToCharArray(0, a.Length);
            Array.Sort(array);
            return String.Join("", array);
        }
        static char[] Duplicate(string a)
        {
            string str = RemoveWhiteSpace(a).ToLowerInvariant();
            string outStr = "";

            for (int i = 0; i < str.Length; i++)
            {
                char checkIndexSymbol = str[i];

                if (str.IndexOf(checkIndexSymbol) != str.LastIndexOf(checkIndexSymbol))
                {
                    if (outStr.Contains(checkIndexSymbol))
                    {
                        continue;
                    }
                    else
                    {
                        outStr += checkIndexSymbol;
                    }
                }
            }
            return outStr.ToCharArray();
        }
        static string RemoveWhiteSpace(string str)
        {
            return string.Join("", str.Split(default(string[]), StringSplitOptions.RemoveEmptyEntries));
        }
    }
}