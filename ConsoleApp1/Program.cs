using System.Text;

namespace ConsoleApp1
{
    internal class Program
    {
        enum AnalizeOut
        {
            ALPHABETIC,
            DIGITS,
            OTHER
        }

        static void Main(string[] args)
        {
            string str1 = "trtjhygcehabccsd";
            string str2 = "asdfghjasjhgkr!!@@##$AD123SD";

            Console.WriteLine("Compare:");
            Console.WriteLine(Compare(str1, str2));
            Console.WriteLine("Analize:");
            Console.WriteLine($"Alphabetic chars: {Analize(str2, AnalizeOut.ALPHABETIC)}");
            Console.WriteLine($"Digit chars: {Analize(str2, AnalizeOut.DIGITS)}");
            Console.WriteLine($"Other chars: {Analize(str2, AnalizeOut.OTHER)}");
            Console.WriteLine("Sort");
            Console.WriteLine($"Start string: {str1}\nSort string: {Sort(str1)}");
            Console.WriteLine("Duplicate");
            Console.WriteLine($"{new string(Duplicate(str2))}\nUsing Linq: {new string(DuplicateLinq(str2))}");
            Console.WriteLine("--==Extra==--");
            LoremIpsum();


        }

        static bool Compare(string str1, string str2)
        {
            bool flag = true;

            if (str1.Length == str2.Length)
            {
                for (int i = 0; i < str1.Length; i++)
                {
                    if (str1[i] != str2[i])
                    {
                        flag = false;
                        break;
                    }
                }
            }
            else flag = false;

            return flag;
        }

        static int Analize(string str, AnalizeOut outType = AnalizeOut.ALPHABETIC)
        {
            int result = 0;
            Func<char, bool> func = c => outType == AnalizeOut.ALPHABETIC ?
                char.IsLetter(c) : outType == AnalizeOut.DIGITS ?
                    char.IsDigit(c) : !char.IsLetterOrDigit(c);

            for (int i = 0; i < str.Length; i++)
            {
                if (func(str[i]))
                {
                    result++;
                }
            }

            return result;
        }

        static string Sort(string str)
        {
            char[] cStr = str.ToLower().ToCharArray();

            for (int i = 1; i < cStr.Length; i++)
            {
                int j = i;
                while (j > 0 && (int)cStr[j] < (int)cStr[j - 1])
                {
                    char temp = cStr[j - 1];
                    cStr[j - 1] = cStr[j];
                    cStr[j] = temp;
                    j--;
                }
            }

            string res = new string(cStr);

            return res;
        }

        static char[] DuplicateLinq(string str)
        {
            return str.ToLower().GroupBy(x => x).Where(x => x.Count() > 1).Select(x => x.Key).ToArray();
        }

        static char[] Duplicate(string str)
        {
            char[,] temp = new char[str.Length, 2];
            char[] cStr = str.ToLower().ToCharArray();
            int tempCount = 0;
            StringBuilder res = new StringBuilder();

            for (int i = 0; i < cStr.Length; i++)
            {
                bool flag = true;

                for (int j = 0; j < tempCount; j++)
                {
                    if (temp[j, 0] == cStr[i])
                    {
                        temp[j, 1]++;
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    temp[tempCount, 0] = str[i];
                    temp[tempCount, 1] = (char)1;
                    tempCount++;
                }
            }

            for (int i = 0; i < tempCount; i++)
            {
                if ((int)temp[i, 1] > 1)
                {
                    res.Append(temp[i, 0]);
                }
            }

            return res.ToString().ToCharArray();
        }

        static void LoremIpsum()
        {
            string loremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Nullam non ligula eget ligula imperdiet" +
                                " tincidunt aliquam in ex. Aenean malesuada sollicitudin lacus, vel consequat justo facilisis non" +
                                ". Etiam vel mauris egestas, tempus enim non, mollis ligula. Duis hendrerit ligula sed nunc feugi" +
                                "at, ut condimentum elit fermentum. Nam in porta urna. Quisque posuere tellus nunc, vel imperdiet" +
                                " ipsum ullamcorper eu. Phasellus quis purus ut justo malesuada interdum vitae eget est. Nulla fa" +
                                "cilisi. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. A" +
                                "liquam aliquet vestibulum ipsum. Nunc ornare, massa id pellentesque tristique, tortor enim bland" +
                                "it nisl, id volutpat nibh mi vitae quam. Pellentesque volutpat augue at odio mattis, quis sagitt" +
                                "is odio vehicula. Aenean tincidunt et urna vitae efficitur. Pellentesque tincidunt, nisl quis po" +
                                "suere scelerisque, orci erat finibus metus, vitae lobortis velit nisl id magna. Donec a elit sit" +
                                " amet dui sagittis feugiat. Nulla finibus, lorem nec ultrices dignissim, velit lectus dapibus sa" +
                                "pien, in eleifend leo quam nec urna. Donec id eros dictum, cursus massa id, molestie risus. Aene" +
                                "an sagittis in orci quis aliquam. Suspendisse potenti. Duis mattis tortor eget condimentum eleme" +
                                "ntum. Integer eget placerat magna, id euismod ipsum. Vestibulum faucibus ultrices erat. Aenean v" +
                                "itae velit in ex sodales sodales ut ac risus. Nullam malesuada sagittis libero a imperdiet. Maur" +
                                "is sit amet elit nunc. In in ante dapibus, lobortis justo imperdiet, ultrices libero. Cras venen" +
                                "atis eros id pulvinar venenatis. Mauris feugiat augue a sem dapibus vestibulum. Nam molestie nib" +
                                "h convallis tincidunt consequat. Phasellus at ligula risus. Sed id nibh condimentum, pulvinar es" +
                                "t vestibulum, semper magna. Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque pla" +
                                "cerat sem ut malesuada suscipit. Fusce massa tortor, tristique nec quam eget, volutpat sollicitu" +
                                "din odio. Maecenas id iaculis elit. Vestibulum a neque aliquam, pulvinar felis quis, venenatis q" +
                                "uam. In pretium sagittis auctor. Sed cursus sollicitudin neque, a mattis turpis lacinia mattis. " +
                                "Phasellus varius sit amet sem non dapibus. Nullam dapibus orci ex, sed cursus augue auctor vitae" +
                                ". Proin ac sagittis nulla. Morbi accumsan nisl augue, quis sodales arcu suscipit vitae. Sed quis" +
                                " efficitur odio, ac sagittis odio. Etiam at dolor at justo ultrices gravida a nec risus. Nam tri" +
                                "stique, risus ac condimentum suscipit, tellus lorem luctus enim, at aliquet metus magna sed urna" +
                                ". Fusce id fringilla sapien. Donec congue tellus diam. Praesent et fermentum metus. In sit amet " +
                                "lacus a ante consequat tincidunt. Sed pretium justo ut malesuada ultrices. Quisque sagittis port" +
                                "titor tempus. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia c" +
                                "urae; Donec a consectetur mauris. In tempor volutpat risus, et aliquam elit tristique ut.Duis so" +
                                "llicitudin lorem eget tincidunt tincidunt. Lorem ipsum dolor sit amet, consectetur adipiscing el" +
                                "it. Proin ante tellus, tincidunt eu nunc a, efficitur suscipit metus. Donec nec sapien at massa " +
                                "maximus lobortis a vitae diam. Cras maximus condimentum est ac mollis. Phasellus quis porttitor " +
                                "erat. Curabitur dignissim, orci quis pulvinar suscipit, purus nunc hendrerit lacus, sed ultrices" +
                                " leo eros ac est. Nulla at risus nisl. Pellentesque varius orci non erat aliquet, vitae facilisi" +
                                "s leo porta. Fusce id mauris.";

            char[] punctuations = { ' ', ',', '.', ';', ':' };
            string[] loremIpsumArr = loremIpsum.Split(punctuations, StringSplitOptions.RemoveEmptyEntries);

            int loremCnt = 0;
            int pulvinarIndex = -1;
            bool temp = true;

            for (int i = 0; i < loremIpsumArr.Length; i++)
            {
                if (string.Compare("lorem", loremIpsumArr[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    loremCnt++;
                }
            }

            for (int i = 0; i < loremIpsumArr.Length; i++)
            {
                if (string.Compare("pulvinar", loremIpsumArr[i], StringComparison.OrdinalIgnoreCase) == 0)
                {
                    temp = !temp;

                    if (temp)
                    {
                        pulvinarIndex = i;
                        break;
                    }
                }

            }

            Console.WriteLine(String.Format("lorem count: {0}\npulvinar second index: {1}", loremCnt, pulvinarIndex));

            Console.WriteLine();
            Console.WriteLine(loremIpsum.Insert(loremIpsum.Length / 2, "\n\n" + loremIpsum + "\n\n"));
        }
    }
}