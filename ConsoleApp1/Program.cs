namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string str = null;
			string str2 = "";
			string str3 = "12345A";
			string str4 = "12345A";
			string str5 = "123";
			string str6 = "qwertyuiopasdfghjklzxsecvbm";
			string str7 = "1asw34#@8765^";
			int ints = 0;
			int ints2 = 0;
			Console.WriteLine(Compare(str3,str4));
			Analyze(str7);
			Console.WriteLine(Sort(str6));
			//Duplicate(str4,str5);

		}
		static bool Compare(string str, string str2)
		{
			return str == str2?true:false;
		}
        static void Analyze(string str)
		{
			int countAlphabetic = 0;
			int countDigits = 0;
			int countSpecialCharacters = 0;
			str = str.ToLower();
			char[] chars = str.ToCharArray();
			for(int i = 0; i < chars.Length; i++)
			{
				if(chars[i] >= 'a')
				{
					countAlphabetic++;
				}else if(chars[i] <= '9'&& chars[i] >= '0')
				{
					countDigits++;
				}
			}
			countSpecialCharacters = str.Length - countAlphabetic - countDigits;
			Console.WriteLine($"countAlphabetic = {countAlphabetic}\ncountDigits = {countDigits}\ncountSpecialCharacters = {countSpecialCharacters}");

		}


        static string Sort (string str)
		{
			string str2 = str.ToLower();
			char[] chars = str2.ToCharArray();
            int n = chars.Length;
            for (int i = 0; i < n - 1; i++)
                for (int j = 0; j < n - i - 1; j++)
                    if (chars[j] > chars[j + 1])
                    {
                        char temp = chars[j];
                        chars[j] = chars[j + 1];
                        chars[j + 1] = temp;
                    }
            return new string (chars);
		}
		
    }
}