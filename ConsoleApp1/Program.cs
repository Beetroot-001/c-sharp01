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
			string str5 = "123355789090";
			string str6 = "qwertyuizopasdfghjklzxsecvbm";
			string str7 = "1asw34#@8765^";
			int ints = 0;
			int ints2 = 0;
			Console.WriteLine(Compare(str3,str4));
			Analyze(str7);
			Console.WriteLine(Sort(str6));
			Console.WriteLine(Duplicate(str6)); 

		}
		static bool Compare(string str, string str2)
		{
			if(str == null|| str2 == null)
			{
				return false;
			}else if(str.Length != str2.Length)
			{
				return false;
			}else if(str.Length == str2.Length)
			{
				for(int i = 0; i < str2.Length; i++)
				{
					if (str[i] != str2[i])
					{
						return false;
					}
				}
			}

			return true;
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
		static string Duplicate (string str)
		{
			char[] chars = str.ToLower().ToCharArray();
			int count = 0;
			for(int i = 0; i < chars.Length; i++)
			{
				for(int j = 0; j < chars.Length;j++)
				{
					if (chars[i] == chars[j] && i != j)
					{
						count++;
					}
				}
			}
			char[] chars2 = new char[count];
            int count2 = 0;
            for (int i = 0; i < chars.Length; i++)
            {
                for (int j = 0; j < chars.Length; j++)
                {
                    if (chars[i] == chars[j] && i != j)
                    {
						
                        chars2 [count2] = chars[i];
						count2++;	
                    }
                }
            }
            string str2 = new string(chars2);
			str2 = Sort (str2);
            string str3 = "";
			for (int i = 0; i < chars2.Length ; i += 2)
			{
				
				str3 += str2 [i];
			}
			
			
            return  str3;
		}
    }
}