using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace ConsoleApp1
{
	internal class Program
	{
        /// <summary>
        /// Compare two strings if they are equal
        /// </summary>
        /// <param name="str1">First string</param>
        /// <param name="str2">Second string</param>
        /// <returns>Return true if 2 strings are equal, otherwise false</returns>
        static bool Compare(string str1, string str2)
        {
            if (str1.Length != str2.Length)
            {
                return false;
            }

            for (int i = 0; i < str1.Length; i++)
            {
                if (str1[i] != str2[i])
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Return number of alphabetic chars in string, digits and another special characters
        /// </summary>
        /// <param name="str">string to analyze</param>
        static void Analyze(string str)
        {
            int digits = 0;
            int letters = 0;
            int characters = 0;

            for (int i = 0; i < str.Length; i++)
            {
                if (char.IsDigit(str[i]))
                {
                    digits++;
                }
                else if (char.IsLetter(str[i]))
                {
                    letters++;
                }
                else if (!char.IsSeparator(str[i]))
                {
                    characters++;
                }
            }
            Console.WriteLine($"Letters = {letters}, digits = {digits}, characters = {characters}");
        }

        /// <summary>
        /// sort string in alphabetical order
        /// </summary>
        /// <param name="str">string to sort</param>
        /// <returns>Return string that contains characters sorted in alphabetical order</returns>
       static string Sort(string str)
        {
            str = str.ToLower();

            char[] resultString = str.ToCharArray();

            for (int i = 1; i < resultString.Length; i++)
            {
                int key = i;
                while (key > 0 && resultString[key] < resultString[key - 1])
                {
                    char temp = resultString[key - 1];
                    resultString[key - 1] = resultString[key];
                    resultString[key] = temp;
                    key--;  
                }
            }

            return new string(resultString).TrimStart();
        }

        /// <summary>
        /// Search for duplicates in string
        /// </summary>
        /// <param name="str">string to analyze fpr duplicates</param>
        /// <returns>return array of characters that are duplicated in input string</returns>
        static char[] Duplicate(string str)
        {
            str = str.ToLower();

            string result = string.Empty;

            for (int i = 0; i < str.Length; i++)
            {
                for (int j = i + 1; j < str.Length; j++)
                {
                    if (str[i].Equals(str[j]) && char.IsWhiteSpace(str[i]) == false)
                    {
                        bool match = false;                     
                        
                        for (int k = 0; k < result.Length; k++)  /*check for duplicates in the sorted result string*/
                        {
                            if (str[i] == result[k])
                            {
                                match = true;
                                break;
                            }
                        }
                        if (!match) result += str[i];          /* if not found add a char to the result string*/
                    }
                }
            }
            return result.ToCharArray();
        }


        static char[] Duplicate2(string str)
        {
            str = str.ToLower();
            str.Replace(" ", "");

            string result = string.Empty;


            for (int i = 0; i < str.Length; i++)
            {

                for (int j = 0; j < str.Length; j++)
                {



                }

            }






            return result.ToCharArray();
        }









        static void Main(string[] args)
		{

			string str1 = "This is hello string";
			string str2 = "this is Hello string";


			Console.WriteLine( $"Compare method result: {Compare(str1, str2)}");
			Console.WriteLine( $"Analyze method result: ");
            Analyze(str1);
            Console.WriteLine($"Sort method result: {Sort(str1)}");
            Console.WriteLine($"Duplicate method result: ");
         
            foreach (var item in Duplicate(str1))
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();


            //Extra Task
            Console.WriteLine("/////////////Extra Task//////////////");

            string text = $"Lorem ipsum dolor sit amet, consectetur adipiscing elit. Sed dui leo, malesuada nec euismod vel, tempus ac ante. Vivamus quis condimentum metus, sed mollis magna. Aenean ligula turpis, molestie ac purus ac, fringilla blandit neque. Praesent at enim orci. Sed maximus eu ipsum ut mattis. Integer aliquam orci sed mi pharetra, et condimentum magna egestas. Aenean dignissim dictum est, vitae ullamcorper massa cursus et. Phasellus nisi felis, imperdiet sit amet imperdiet in, pulvinar ut justo. Mauris pretium efficitur orci a auctor. Nulla a tincidunt tortor. Nullam et porta lorem. Donec dignissim varius cursus. Nam tellus ex, hendrerit elementum tincidunt ut, tempus aliquet eros. Mauris efficitur, lorem non sodales sollicitudin, ex mauris consectetur lectus, quis auctor mauris purus non nisi. Vivamus orci felis, varius et velit interdum, rutrum maximus tellus. Aliquam non gravida tortor. Quisque pellentesque dui vel dapibus sollicitudin. Nunc at ultricies risus. Donec a dictum nulla, eu feugiat urna. Integer id scelerisque tellus. Donec ultrices ut mi ut semper. Nullam vitae dui ligula. Aliquam turpis mi, fermentum sit amet ipsum sed, facilisis dignissim diam. Curabitur id pretium nisl. Vivamus eget blandit arcu, ac cursus purus. Sed a molestie quam. Praesent lacinia suscipit lorem, vitae eleifend justo varius maximus. Duis id risus sapien. Cras quis dictum augue, nec varius enim. Nunc facilisis ut elit blandit luctus. Curabitur volutpat odio a mauris lobortis, non tempus tellus tempor. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos himenaeos. Aliquam posuere erat vitae magna dignissim, nec consequat eros tincidunt. Phasellus fermentum, leo non vulputate porttitor, justo nisl faucibus nisl, at vestibulum erat arcu hendrerit felis. Aenean ornare dapibus magna, et maximus tortor molestie vel. Duis consequat finibus elementum. Curabitur eget porta tellus. Donec in dolor eu dolor elementum pharetra. Praesent vitae vehicula ligula. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Donec commodo felis ut sollicitudin volutpat. Phasellus placerat quis leo ut imperdiet. Praesent eu elit dapibus, scelerisque dui vitae, faucibus tortor. Curabitur interdum ante id molestie tempor. Nullam dolor orci, fermentum molestie efficitur et, semper sit amet nisl. Phasellus et est elementum, laoreet sapien finibus, consectetur lacus. Donec sodales sagittis porttitor. Ut malesuada nec enim vel ultrices. Aliquam ut ullamcorper sem. Vivamus non metus non nunc tincidunt convallis. Proin ac justo at magna vulputate ultrices. Mauris maximus id tellus quis suscipit. Suspendisse dignissim eu orci quis dictum. Phasellus et ipsum gravida, pulvinar augue id, iaculis tortor. Vestibulum finibus risus eget ultricies tempor. Nullam posuere, felis eget fringilla cursus, augue odio fermentum dui, at condimentum libero purus eget metus. In ultricies mi ultrices erat vulputate congue. Nulla lobortis aliquet egestas. Quisque porta nisl ac felis porta, egestas tristique nibh tincidunt. Mauris tempus et ipsum eget tempus. Suspendisse nec gravida libero. Ut non arcu massa. Phasellus elit diam, aliquet sit amet lorem sit amet, sodales euismod lectus. Proin venenatis est vel mattis auctor. Suspendisse faucibus a felis et lobortis. Nullam in sapien a felis efficitur gravida ac id nisi. Nunc suscipit justo sit amet ex pharetra, eget.";

            string[] words = text.Split(' ');     ///Create words array to count the number of words in the string
           
            int loremCounter = 0;                 /// Count the number of "lorem" in the string

            foreach (var item in words)
            {
                if (item.StartsWith("lorem") || item.StartsWith("Lorem"))
                {
                    loremCounter++;
                }
            }

            Console.WriteLine($"The number of word <lorum> occurs {loremCounter} times in the string");

            foreach (var item in words)
            {
                if (item.Contains("pulvinar"))
                {
                    Console.WriteLine($"The second index of the <pulvinar> word is {item[2]}");
                    break;
                }
            }        

            string[] words2 = new string [250]; ///create an array to seperate the first 250 words

            Array.Copy(words, words2, 250);  ///copy the first 250 words into the array

            string resultString = string.Join(' ', words2); ///create the result string that contains the first 250 words

            int flag = resultString.Length; ///find the last character of the first 250 words

            resultString += " " + text + text.Substring(flag); ///concatenate the first 250 words + whitespace + main text + last 250 words

            //Console.WriteLine(result);










        }
    }
}