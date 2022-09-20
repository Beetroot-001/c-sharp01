
using System.Text.RegularExpressions;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string a = "hello";
			string b = "hello,*%";
			string forSorting = "DCBaz";

			//Compare(a, b);//#1

			int counterForChars, counterForDigits, counterForSpecialChars;
            Analyze("st1", out counterForChars,  out counterForDigits, out  counterForSpecialChars);//#2

			//Sort(forSorting);//#3
			//Duplicate("yroma roma rota ta wwy y");//#4 
        }

		//#1
        //Compare that will return true if 2 strings are equal,
		//otherwise false, but do not use build-in method

        public static bool Compare(string a, string b)
		{
			if (a.Length != b.Length)
			{
				Console.WriteLine($"False, a.length = {a.Length!}, b.Length = {b.Length!}");
				return false;
			}

			if( a != b)
			{
				Console.WriteLine($"{a} not equal to {b}");
				return false;
			}

			Console.WriteLine($"True, {a} equal to {b}");
			return true;
		}

		//#2
		//Analyze that will return number of alphabetic chars in string,
		//digits and another special characters

		//TODO
		public static void Analyze(string s, out int counterForChars, out int counterForDigits, out int counterForSpecialChars)
		{
			string forTest = s.ToLower();

            counterForChars = 0;
			counterForDigits = 0;
			counterForSpecialChars = 0;

			//TODO: prepare correct pattern
            string pattern = @"\d[a-z]";
			string pattern2 = @"\d";
			string pattern3 = @"\w";

            foreach (Match match in Regex.Matches(forTest, pattern))
				counterForChars += counterForChars;
                Console.WriteLine($"counterForChars {counterForChars}");

            foreach (Match match in Regex.Matches(forTest, pattern2))
                counterForDigits += counterForDigits;
            Console.WriteLine($"counterForDigits {counterForDigits}");


            foreach (Match match in Regex.Matches(forTest, pattern3))
                counterForSpecialChars += counterForSpecialChars;
            Console.WriteLine($"counterForSpecialChars {counterForSpecialChars}");
        }

		//#3
        //Sort that will return string that contains all
		//characters from input string sorted in alphabetical order (e.g. 'Hello' -> 'ehllo')


		public static string Sort(string a)
		{
			string forTest = a.ToLower();
            Console.WriteLine($"lower case = {forTest}");
            char[] testArray = new char[a.Length];
            forTest.CopyTo(0, testArray, 0, forTest.Length);

			for (int i = 0; i < forTest.Length; i++)
			{
                for (int j = 0; j < forTest.Length - i - 1; j++)
				{
					if (testArray[j] > testArray[j + 1])
						(testArray[j], testArray[j + 1]) = (testArray[j + 1], testArray[j]);
                }         
            }

		    forTest = string.Join("",testArray);
			Console.WriteLine($"Result of sorting '{forTest}'");
			return forTest;
		}

		//#4 - TODO
		//Duplicate that will return array of characters
		//that are duplicated in input string (e.g. 'Hello and hi' -> ['h', 'l'])

		public static char[] Duplicate(string inputString)
		{
			//make array from string
			char[] forWork = new char[inputString.Length];
			inputString.ToLower().CopyTo(0, forWork, 0 , inputString.Length);

			//prepare new string to same result
			string resultString = String.Empty;

			//find if there are any duplicates
			for(int i = 0; i < forWork.Length-1; i++)
			{
                for (int j = i + 1; j < forWork.Length - 1; j++)
				{
					if (forWork[i] == forWork[j])
						if (resultString.Contains(forWork[i]) == false)
							resultString += (forWork[i]);
				}
            }

			//convert string to array to send array as a result
			if(resultString != null)
			{
                char[] resultChar = new char[resultString.Length];
                resultString.CopyTo(0, resultChar, 0, resultString.Length);
                Console.WriteLine($"result string = {resultString}");
                return resultChar;
            }
			
			Console.WriteLine($"Input string {inputString} does not have duplicated letters");
			return null;		 
		}
    }
}
