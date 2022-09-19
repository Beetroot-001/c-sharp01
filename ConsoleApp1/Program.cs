using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Compare that will return true if 2 strings are equal, otherwise false, but do not use build-in method//
            string a = "123";
            string b = "1231";
            Console.WriteLine(string.Format("a = {0}. b = {1}. Compare = {2}", a, b, Compare(a, b)));
            a = "123";
            b = "132";
            Console.WriteLine(string.Format("a = {0}. b = {1}. Compare = {2}", a, b, Compare(a, b)));
            a = "123";
            b = "123";
            Console.WriteLine(string.Format("a = {0}. b = {1}. Compare = {2}", a, b, Compare(a, b)));

            //Analyze that will return number of alphabetic chars in string, digits and another special characters//
            a = @"aaaa11123...\\**/";
            Console.WriteLine(string.Format("\na = {0}.\nAlphabetic = {1}.\nDigits = {2}.\nAnother = {3}", a, Analyze(a).alphabetic, Analyze(a).digits, Analyze(a).another));

            //Sort that will return string that contains all characters from input string sorted in alphabetical order (e.g. 'Hello' -> 'ehllo')//
            a = "hello";
            Console.WriteLine(string.Format("a = {0}. Sort = {1}", a, Sort(a)));

            //Duplicate that will return array of characters that are duplicated in input string (e.g. 'Hello and hi' -> ['h', 'l'])//
            a = "Hello and hi";
            Console.WriteLine(string.Format("a = {0}. Duplicate = {1}", a, string.Concat(Duplicate(a))));

            //Extra//
            a = @"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Pellentesque erat ligula, euismod ac nisi eget, posuere tincidunt leo. Cras sem orci, lacinia sed iaculis non, rhoncus non arcu. Ut rutrum turpis vel aliquam congue. Nam consectetur at purus id finibus. Praesent malesuada iaculis massa. Curabitur condimentum magna in sapien venenatis, nec consectetur elit laoreet. Maecenas sed nisl vulputate eros volutpat dignissim. Aliquam at ultrices mi. Sed consequat accumsan leo non aliquet. Interdum et malesuada fames ac ante ipsum primis in faucibus. Curabitur ultrices mi ligula, eget efficitur lorem venenatis tempus. Sed ut nulla id lorem dignissim fermentum mattis a nisi. Suspendisse blandit fermentum lorem dictum auctor. Quisque semper, lacus et faucibus viverra, orci est blandit leo, in rhoncus lorem tortor ut sapien. In non iaculis dui. Nulla vel volutpat est.
                Nulla finibus quam in nibh viverra varius. Donec efficitur lacinia eros, sit amet vulputate augue pellentesque ac. Aliquam erat libero, consectetur et massa vitae, pharetra congue urna. Sed elit ligula, interdum congue malesuada non, dignissim eget ex. Nam sed nisi rhoncus, sagittis nisl et, gravida turpis. Duis mattis accumsan nisi vitae fringilla. Proin nec eleifend risus. Nam enim libero, vulputate sodales hendrerit gravida, convallis vitae augue.
                Nullam fringilla justo vitae ligula blandit pellentesque. Suspendisse vitae aliquam purus. Sed dapibus nisl a varius aliquet. Aenean mollis fermentum diam vitae commodo. Pellentesque laoreet, mi a elementum tempor, neque sapien blandit massa, vitae tempor purus felis et dui. In aliquam varius dictum. Pellentesque bibendum velit sit amet ipsum lacinia bibendum. Suspendisse id porta tortor. Nunc ultricies, orci id facilisis luctus, est orci lobortis arcu, vel consequat velit lectus ornare est. Nulla faucibus imperdiet libero, a volutpat magna feugiat eget. Maecenas luctus quis magna vel facilisis. Cras ut laoreet enim. Nulla est est, molestie ut mollis sit amet, cursus ac quam. Nunc ac condimentum dui. Proin finibus leo eget dui ultrices malesuada.
                Quisque pulvinar velit sed augue rutrum feugiat. Nulla facilisi. Fusce eget metus nec dui sagittis ultrices suscipit ut turpis. Nulla facilisi. Nunc ornare scelerisque justo sed interdum. Morbi efficitur pulvinar ex id auctor. Praesent vestibulum odio et malesuada sagittis. Etiam facilisis ex quis nibh volutpat tempor. Donec vulputate erat molestie quam laoreet, ac ornare ligula tempus. Cras ullamcorper viverra tellus sit amet laoreet. Donec sit amet convallis enim.
                Nulla pharetra aliquam nunc ac bibendum. Aliquam pellentesque molestie massa ac mollis. Vivamus vestibulum mollis nunc, sit amet imperdiet nulla eleifend vel. Etiam condimentum nulla non nulla hendrerit aliquet. Morbi aliquet purus quis lectus malesuada, vel placerat leo congue. Integer at sodales libero, nec varius ante. Pellentesque imperdiet mi in neque iaculis, ornare convallis augue sollicitudin. Fusce libero odio, viverra a pulvinar sit amet, tristique non nunc.
                Nulla ornare turpis in est consequat, non laoreet enim facilisis. Curabitur sit amet nisl et mauris dictum tempus ac sollicitudin dolor. Integer ornare, velit eget mollis hendrerit, velit nulla condimentum urna, eget pretium urna metus vulputate lectus. Sed rutrum pharetra massa eget molestie. Aenean cursus est eu lorem condimentum, nec pretium massa gravida. Sed consectetur erat non.";
            Console.WriteLine($"Inner text {a}");
            string wordToFindHowMany = "lorem";
            string wordToFindSecondIndex = "pulvinar";

            var extra = Extra(ref a, wordToFindHowMany, wordToFindSecondIndex);
            Console.WriteLine(string.Format("\n\nHow Many times you can see a word {0} - {1}\n Second index of the word {2} is {3}\n Outer text with new inserted string is - \n{4}", wordToFindHowMany, extra.howMany, wordToFindSecondIndex, extra.secondIndex, a));
        }
        static bool Compare(string a, string b)
        {
            if (a.Length != b.Length)
            {
                return false;
            }
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != b[i]) return false;
            }

            return true;
        }
        static (int alphabetic, int digits, int another) Analyze(string a)
        {
            (int alphabetic, int digits, int another) u = (0, 0, 0);
            for (int i = 0; i < a.Length; i++)
            {
                if (char.IsLetter(a[i])) u.alphabetic++;
                else if (char.IsDigit(a[i])) u.digits++;
                else u.another++;
            }

            return u;
        }
        static string Sort(string a)
        {
            char[] result = a.ToArray();
            Array.Sort(result);
            return new string(result);
        }
        static char[] Duplicate(string a)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < a.Length; i++)
            {
                int cc = 0;
                if (char.IsWhiteSpace(a[i])) continue;

                for (int j = 0; j < a.Length; j++)
                {
                    if (char.ToLower(a[i]).Equals(char.ToLower(a[j]))) cc++;
                }
                if (cc > 1 && !sb.ToString().Contains(a[i])) sb.Append(char.ToLower(a[i]));
            }
            return sb.ToString().ToCharArray();
        }

        static (int howMany, int secondIndex) Extra(ref string a, string wordToFindHowMany, string wordToFindSecondIndex)
        {
            (int howMany, int secondIndex) result = (0, 0);
            result.howMany = FindWord(a, wordToFindHowMany);
            result.secondIndex = FindSecondIndex(a, wordToFindSecondIndex);
            Insert(ref a, " //**insert the same text in the middle after the 250th word**// ");
            return result;
        }

        static int FindWord(string text, string word)
        {
            int result = 0;
            var t = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in t)
            {
                if (item.Equals(word)) result++;
            }
            return result;
        }

        static int FindSecondIndex(string text, string word)
        {
            int count = 0;
            int result = -1;
            var t = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (int i = 0; i < t.Length; i++)
            {
                if (t[i].Equals(word))
                {
                    count++;
                    result = i;
                }
                if(count == 2) return result;
            }
            return -1;
        }
        static void Insert(ref string text, string someTextToInsert)
        {
            var t = text.Split(' ');
            StringBuilder sb = new(string.Join(" ", t[0..(t.Length/2)]));
            sb.Append(someTextToInsert);
            sb.Append(string.Join(" ", t[(t.Length/2)..]));
            text = sb.ToString();
        }
    }
}