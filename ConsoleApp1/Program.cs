using System;
using System.Linq;

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
			//Analyze(b);//#2
			//Sort(forSorting);//#3
			Duplicate("Hellooo");//#4 - I have a question here

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

		public static int Analyze(string s)
		{
			Console.WriteLine($"String is '{s}', length is {s.Length}");
			return s.Length;
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
			//make array rom string
			char[] forWork = new char[inputString.Length];
			inputString.ToLower().CopyTo(0, forWork, 0 , inputString.Length);

			//prepare new string to same result
			string resultString = String.Empty;

			//find iw there are any duplicates
			for(int i = 0; i < forWork.Length; i++)
			{
                for (int j = 0; j < forWork.Length - i - 1; j++)
				{
					if (forWork[j] == forWork[j + 1])
						if (resultString.Contains(forWork[j]) == false)// I have a question here
							resultString = string.Join("", forWork[j]);        		
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
