using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Beetroot_HOMEWORK
{
    internal class Program
    {
        static void PrintArray(char[] chars)
        {
            for (int i = 0; i < chars.Length; i++)
                Console.Write("'{0}'", chars[i]);
            Console.WriteLine();
        }
        static void Main(string[] args)
        {
            string str = "Hello World";
            string str1 = "Hello world";

            Console.WriteLine(Compare(str, str1));
            Analyze(str);
            Console.WriteLine(Sort("CBAcbadfga"));

            char[] chars = DuplicateWithMetod(str);
            char[] chars2 = DuplicateWithoutMetod(str);

            PrintArray(chars);
            PrintArray(chars2);
            LoremIpsum();

            Console.ReadLine();
        }
        //create next methods:
        //Compare that will return true if 2 strings are equal, otherwise false, but do not use build-in method
        static bool Compare(string str, string str1)
        {
            int caunt = 0;
            if (str.Length==str1.Length)
            {
                for (int i = 0; i < str.Length; i++)
                {
                    if (str[i] == str1[i])
                        caunt++;
                }
                if (caunt==str.Length)
                    return true;
                return false;
            }
            return false;
        }
        //Analyze that will return number of alphabetic chars in string, digits and another special characters
        static void Analyze(string str)
        {
            int numberOfAlphabetic = 0;
            int numberOfDigits = 0;
            int numberSpecialCharacters = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsLetter(str[i]))
                    numberOfAlphabetic++;
                else if (char.IsDigit(str[i]))
                    numberOfDigits++;
                else 
                    numberSpecialCharacters++;
            }
            Console.WriteLine(string.Format("number of alphabetic chars in string:{0}\ndigits:{1}\nanother special characters:{2} ",numberOfAlphabetic,numberOfDigits,numberSpecialCharacters));
        }
        //Sort that will return string that contains all characters
        //from input string sorted in alphabetical order(e.g. 'Hello' -> 'ehllo')
        static string Sort(string str)
        {
            StringBuilder stringBuilder = new StringBuilder();
            char[] chars = str.ToLower().ToCharArray();
            for (int i = 1; i < chars.Length; i++)
            {
                for (int j = 0; j < chars.Length-1; j++)
                {
                    if (chars[j] > chars[j+1])
                    {
                        char temp = chars[j];
                        chars[j] = chars[j + 1];
                        chars[j + 1] = temp;
                    }
                }
            }
            for (int i = 0; i < chars.Length; i++)
                stringBuilder.Append(chars[i]);

            string strNew = stringBuilder.ToString();
            return strNew;
        }
        //Duplicate that will return array of characters that are duplicated in input string (e.g. 'Hello and hi' -> ['h', 'l'])
        static char[] DuplicateWithMetod(string str)
        {
            char[] chars = str.ToCharArray();
            return chars;
        }
        static char[] DuplicateWithoutMetod(string str)
        {
            char[] chars = new char[str.Length];
            for (int i = 0; i < str.Length; i++)
            {
                chars[i] = str[i];
            }
            return chars;
        }
        //Extra homework task
        /*1)Generate Lorem Ipsum with 500 words, count how many times ‘lorem’ appears in the text(case insensitive),
        2)find second index of the ‘pulvinar’ word,
        3)insert the same text in the middle after the 250th word*/
        static void LoremIpsum()
        {
            int cauntOfLorem = 0;
            int cauntOfpulvinar = 0;
            int secondindex = 0;
            char[] separators = new char[3] {' ','\r','\n'};
            string loremIpsum = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Donec lorem sed urna justo. Mauris at varius lectus, a viverra urna. Pellentesque at elementum augue. Etiam in lectus tristique, mollis ante vitae, elementum ex. Duis nec congue nisl. Nullam dapibus erat id sapien vestibulum hendrerit. Cras quis libero blandit, facilisis sapien vel, luctus nunc. Duis vitae convallis lorem. Suspendisse vel laoreet magna, eget vulputate augue.\r\n\r\nNam sit amet ex est. Aenean et interdum augue. Vestibulum at purus tristique, aliquam metus in, rhoncus libero. Ut luctus molestie convallis. Nunc nec urna euismod, ullamcorper mi ac, ultrices nisi. Morbi commodo neque nec varius bibendum. Morbi urna ligula, dictum ac nisi eget, hendrerit bibendum quam. Donec et fermentum nibh. Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia curae; Nulla eget quam scelerisque, tempor tortor ac, maximus nulla. Morbi auctor ac eros nec volutpat. Ut vehicula quis ante non tristique.\r\n\r\nLorem ipsum dolor sit amet, consectetur adipiscing elit. Morbi eleifend eget magna et euismod. Ut elit tortor, pharetra sed quam quis, ultricies mattis ex. Ut et sollicitudin massa. Cras facilisis diam vel velit congue vulputate. Duis sit amet risus a est hendrerit convallis quis sit amet dolor. Donec finibus rhoncus leo, vel eleifend justo faucibus et. In mollis mollis mi, vel mattis felis auctor a. Praesent facilisis magna lacus. Vivamus sed malesuada arcu. Proin facilisis, tellus ut consequat sodales, est nibh lobortis nulla, gravida gravida erat dui non metus. Curabitur sed malesuada leo. Nam interdum libero et orci consequat, et placerat lacus aliquet. Ut leo nunc, bibendum sit amet velit ac, rhoncus tristique magna. Curabitur lacinia, odio pharetra pulvinar pharetra, nisi orci dignissim augue, in faucibus velit tellus sit amet quam.\r\n\r\nCurabitur massa nulla, fringilla nec finibus non, consequat id mi. Sed condimentum sapien tortor, id dignissim tellus maximus id. Proin dolor urna, pulvinar eu purus non, interdum blandit risus. Vestibulum at tempor tortor. Cras magna magna, ornare placerat tincidunt id, cursus vel odio. Maecenas egestas arcu eget congue cursus. Suspendisse vel magna aliquet, cursus mi eget, fermentum orci.\r\n\r\nQuisque ut felis sed est faucibus vestibulum eget id velit. Donec arcu risus, convallis at nulla vel, rutrum tincidunt erat. Nam vel felis dolor. Integer lorem nibh, faucibus eget orci sollicitudin, mattis interdum arcu. Sed accumsan pharetra maximus. Maecenas malesuada tempor tellus, ut ultricies risus mollis et. Vestibulum et risus ut est fermentum fringilla.\r\n\r\nIn tempor elit mi, eu porttitor odio finibus vitae. Vestibulum sem felis, posuere porta tincidunt id, sagittis non felis. Praesent lacus metus, accumsan sed nibh eget, semper vehicula nulla. Etiam tempor iaculis ex et bibendum. Etiam at lacus in eros ultricies sodales quis at urna. Nulla tincidunt congue justo sed gravida. Quisque egestas nibh id ultrices auctor. Etiam sed odio leo. Proin convallis mauris nec quam suscipit, at pellentesque velit rhoncus. Nullam hendrerit erat est. Nullam molestie ac dolor laoreet consectetur. Ut sollicitudin varius elit, ac ultrices magna efficitur a. Etiam ut odio id diam sodales congue sit amet sed risus. Cras faucibus tincidunt augue id lorem eleifend. Integer et.";
            string[] strings = loremIpsum.Split(separators);
            //1)
            for (int i = 0; i < strings.Length; i++)
            {
                if (string.Compare("lorem", strings[i],StringComparison.OrdinalIgnoreCase)==0)
                     cauntOfLorem++; 
            }
            //2
            for (int i = 0; i < strings.Length; i++)
            {
                if (string.Compare("pulvinar", strings[i], StringComparison.OrdinalIgnoreCase) == 0) 
                    cauntOfpulvinar++; 
                if (cauntOfpulvinar == 2)
                {
                    secondindex = i;
                }
            }
            //3
            string newStrLoren =loremIpsum.Insert((loremIpsum.Length/2)-1,"!!!!!!!!!!!!!!!!!!!!!"+loremIpsum);

            Console.WriteLine($"caunt loremIpsum:{cauntOfLorem} \nsecond index:{secondindex}\n{newStrLoren}");
        }


    }
}