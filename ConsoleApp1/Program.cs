namespace ConsoleApp1
{
    internal class Program
    {


        static void Main(string[] args)
        {
            string str1 = "The quick brown fox jumps over the lazy dog";
            string str3 = "4.4.315.4.1045";
            string str4 = "#@₴?$0";
            string str5 = "AaBbCcDdEeFf";
            string str6 = "Mississippi";
            char[] temp = str1.ToCharArray();
            Array.Reverse(temp);
            string str2 = new string(temp);
            Console.WriteLine(str1 + " " + str2);

            Console.WriteLine(Compare(str1, str2));
            Console.WriteLine(Compare(str1, str1));

            Console.WriteLine("Letters, digits, symbols: ");

            Console.WriteLine(str1);
            Analyze(str1);
            Console.WriteLine(Sort(str1));
            Console.WriteLine(Duplicate(str1));
            Console.WriteLine();


            Console.WriteLine(str2);
            Analyze(str2);
            Console.WriteLine(Sort(str2));
            Console.WriteLine(Duplicate(str2));
            Console.WriteLine();

            Console.WriteLine(str3);
            Analyze(str3);
            Console.WriteLine(Sort(str3));
            Console.WriteLine(Duplicate(str3));
            Console.WriteLine();

            Console.WriteLine(str4);
            Analyze(str4);
            Console.WriteLine(Sort(str4));
            Console.WriteLine(Duplicate(str4));
            Console.WriteLine();

            Console.WriteLine(str5);
            Analyze(str5);
            Console.WriteLine(Sort(str5));
            Console.WriteLine(Duplicate(str5));
            Console.WriteLine();

            Console.WriteLine(str6);
            Analyze(str6);
            Console.WriteLine(Sort(str6));
            Console.WriteLine(Duplicate(str6));

            Console.WriteLine();


        }
        static bool Compare(string str1, string str2)
        {
            if (str1 == str2)
                return true;
            else return false;
        }
        static void Analyze(string str)
        {
            int letters = str.Count(char.IsLetter);
            int digits = str.Count(char.IsDigit);
            int symbols = str.Count(char.IsSymbol);
            int sep = str.Count(char.IsPunctuation);
            symbols += sep;
            Console.WriteLine(letters + "," + digits + "," + symbols);

        }
        static string Sort(string str)
        {
            str = str.Replace(" ", "");
            char[] chars = str.ToCharArray();
            Array.Sort(chars);
            string res = new string(chars);

            return res;
        }
        static char[] Duplicate(string str)
        {
            str = str.ToLower();
            char[] dupes = new char[str.Length];
            char[] chars = str.ToCharArray();
            int count = 0;

            for (int i = 0; i < chars.Length - 1; i++)
            {
                for (int j = 0; j < chars.Length - i - 1; j++)
                {
                    if (chars[j] > chars[j + 1])
                    {
                        char temp = chars[j];
                        chars[j] = chars[j + 1];
                        chars[j + 1] = temp;

                    }


                }

            }
            for (int i = 0; i < chars.Length - 1; i++)
            {
                if (chars[i] == chars[i + 1])
                {
                    dupes[count] = chars[i];
                    count++;
                }
            }
            for (int i = 0; i < dupes.Length - 1; i++)
            {
                if (dupes[i] == dupes[i + 1])
                {
                    dupes[i] = '\0';

                }

            }
            

            return dupes;
        }
    }
}
