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
            Console.WriteLine();
            string LoremTest = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. " +
                "Cras at nunc tortor. Pellentesque mollis libero non tincidunt consequat. " +
                "Vivamus condimentum tempor felis, vel dignissim nisi varius ut. Nulla elit purus, " +
                "hendrerit vitae diam at, ullamcorper finibus augue. Quisque congue blandit ligula, id " +
                "consequat arcu cursus at. Etiam mattis metus pharetra, porttitor metus mollis, vehicula orci. " +
                "Nulla facilisi. Nunc sed fermentum libero. Praesent vehicula, purus non elementum accumsan, quam odio " +
                "ultrices nulla, ac imperdiet ipsum nisi ac elit. Aliquam condimentum aliquam massa vel tincidunt. Quisque " +
                "sed vulputate ante. Ut malesuada euismod sapien ultricies bibendum. Proin vitae tincidunt mi, in volutpat " +
                "ligula. Suspendisse gravida rhoncus dui, quis scelerisque eros porttitor ut. Vestibulum euismod " +
                "leo vitae mi fermentum sodales. Nam eleifend luctus libero accumsan sodales. Proin ex eros, tincidunt " +
                "nec varius eget, cursus consectetur turpis. In ipsum felis, eleifend at nulla quis, porta pharetra turpis. " +
                "Fusce feugiat auctor orci, ut molestie sapien consectetur non. Integer dapibus rhoncus varius. " +
                "Sed sollicitudin sem et nunc ultricies fringilla ac tempor urna. Fusce vel pharetra justo, sit amet " +
                "laoreet velit. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. " +
                "Nullam in hendrerit eros. Aenean rhoncus erat fermentum hendrerit ornare. Donec vel diam nec massa luctus " +
                "volutpat id quis ligula. Nulla pretium velit nibh, nec blandit lectus varius non. Sed finibus velit quis odio " +
                "imperdiet feugiat. Morbi dui leo, consectetur et tempus non, dapibus mattis velit. Pellentesque et iaculis" +
                " lectus, a tempor tellus. Quisque et feugiat odio. Sed rhoncus massa sit amet pulvinar dapibus. Nunc eu sapien tellus." +
                " Nunc rutrum vitae enim et consectetur. Sed mi ligula, tempus sed bibendum non, tincidunt id mi. Etiam in eros ac mi" +
                " iaculis aliquam. Vivamus varius ex ac consequat lobortis. In metus nisi, sagittis sed dapibus vel, vulputate nec elit." +
                " Phasellus a cursus odio. Morbi vitae vehicula ligula, tincidunt gravida ipsum. Fusce sodales, lorem nec placerat vesti" +
                "bulum, mi massa pharetra arcu, sit amet auctor leo metus nec enim. Duis nec nulla placerat, hendrerit est a, ultricies" +
                " risus. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Class apte" +
                "nt taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Aenean mollis nibh et mi finibus i" +
                "nterdum. Nunc eu vestibulum nisi, at luctus est. Ut eget pretium sapien. Nullam egestas, ipsum at placerat euismod," +
                " turpis quam convallis mauris, et condimentum libero mi sit amet nulla. Pellentesque in purus sit amet neque ultric" +
                "ies mattis eget ut nisl. Phasellus eget ultrices risus. Suspendisse dapibus neque vitae scelerisque efficitur. Susp" +
                "endisse rhoncus, ligula ac ullamcorper sodales, diam arcu varius ipsum, vel congue nisi urna quis nibh. Aliquam eleif" +
                "end dui urna, ut euismod ligula aliquam eget. Vestibulum tincidunt quam dolor, eu convallis justo finibus eget. Curabi" +
                "tur eget tristique nisi, at pellentesque nunc. In bibendum consectetur condimentum. Ut tincidunt, lectus sed rut" +
                "rum lacinia, sapien diam accumsan sapien, sed mollis mauris sapien ut lectus. Pellentesque fringilla sem eget neque fe" +
                "rmentum efficitur. Fusce dignissim metus eu purus vulputate vestibulum. Cras at gravida sapien. Morbi non tincidun" +
                "t leo. Sed justo odio, bibendum ut elit.";
            // oh god
            LoremIpsumGenerator(LoremTest);
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

        // count how many times 'lorem' appears in the text (case insensitive)
        // find second index of the 'pulvinar' word
        // insert the same text in the middle after the 250th word
        public static void LoremIpsumGenerator(string loremIpsum) 
        {
            int loremCount;
            int spaceCount = 1;

            int secondIndex = SecondIndexOf(loremIpsum, "pulvinar").Item2;
            int length = loremIpsum.Length;
            for (int i = 0; i < loremIpsum.Length; i++)
            {
                if (loremIpsum[i] == ' ')
                    spaceCount++;
                if (spaceCount == 250)
                {
                    loremIpsum = loremIpsum.Insert(i, loremIpsum);
                    break;
                }
            }

            loremCount = LoremCount(loremIpsum);
            Console.WriteLine($"Overal info about string: {Environment.NewLine}" +
                $" Lorem count: {loremCount} {Environment.NewLine}" +
                $" Second index of 'pulvinar': {secondIndex} {Environment.NewLine}" +
                $" New lorem ipsum before and inserted: {length} {loremIpsum.Length}");
        }

        public static (int, int) SecondIndexOf(string lorem, string word)
        {
            int firstIndex = lorem.IndexOf(word);
            if (firstIndex == -1)
                return (-1, -1);
            string subFind = lorem.Substring(firstIndex + 1);
            int secondIndex = subFind.IndexOf(word);
            Console.WriteLine($"First index: {firstIndex}, second index: {secondIndex}");
            return (firstIndex, secondIndex);
        }

        public static int LoremCount(string lorem)
        {
            int count = 0;
            const string word = "lorem";
            lorem = lorem.Replace(",", "");
            lorem = lorem.Replace(".", "");
            string[] words = lorem.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for(int i = 0; i < words.Length; i++)
            {
                if (string.Equals(words[i], word, StringComparison.InvariantCultureIgnoreCase))
                {
                    count++;
                }
            }
            return count;
        }
    }
}