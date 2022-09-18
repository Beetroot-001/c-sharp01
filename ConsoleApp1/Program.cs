namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Test compare");
            Console.WriteLine(Compare("hello ","hello")); 
            Console.WriteLine(Compare("hello","heflo")); 
            Console.WriteLine(Compare("hello","hello"));
            Console.WriteLine();
            Console.WriteLine("Test analyze");
            int l, d, s;
            string test = "hello  ,;190";
            Analyze(test, out l, out d, out s);
            Console.WriteLine(test + $" Letters: {l}, digits: {d}, special: {s}");
            Console.WriteLine();
            Console.WriteLine("Test sort");
            Console.WriteLine(test);
            Console.WriteLine(Sort(test));
            test = "11,,789llkk";
            char[] arr = Duplicate(test);
            Console.WriteLine();
            Console.WriteLine("Test duplicates");
            Console.WriteLine(test);
            Console.WriteLine("Duplicates: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }


        }

        public static bool Compare(string str1, string str2)
        {
            if (str1.Length != str2.Length)
                return false;
            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] != str2[i])
                    return false;
            }
            return true;

        }
        public static void Analyze(string str, out int alpha, out int digits, out int special)
        {
            alpha = 0;
            digits = 0;
            special = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsLetter(str[i]))
                    alpha++;
                else if (char.IsDigit(str[i]))
                    digits++;
                else
                    special++;
            }
        }

        public static string Sort(string str)
        {
            str.ToLower();
            char[] sortedC = new char[str.Length];
            for (int i = 0; i < str.Length; i++) 
            {
                sortedC[i] = str[i];
            }
            for (int i = 0; i < sortedC.Length; i++)
            {
                for (int j = 0; j < sortedC.Length - 1; j++)
                {
                    if (sortedC[j] > sortedC[j + 1])
                    {
                        char t = sortedC[j];
                        sortedC[j] = sortedC[j + 1];
                        sortedC[j + 1] = t;
                    }
                }
            }
            string sorted = new string(sortedC);
            return sorted;
        }
        public static char[] Duplicate(string str)
        {
            char[] array = new char[str.Length / 2 + 1];
            char character;
            int iter = 0;
            
            for (int i = 0; i < str.Length - 1; i++)
            {
                character = str[i];
                for (int j = i + 1; j < str.Length; j++)
                {
                    if (character == str[j])
                    {
                        array[iter] = character;
                        iter++;
                        break;
                    }
                }
            }
            Array.Resize(ref array, iter);
            return array;
        }
    }
}