namespace ConsoleApp1.Test
{
	public static class StringExtensions
	{
		public static int WordCount(this string s)
		{
			return s.Split(new[] { ' ', ',', '.' }, StringSplitOptions.RemoveEmptyEntries).Length;
		}

		public static int WordCount(this string s, string specificWord)
		{
			return s.Split(specificWord, StringSplitOptions.RemoveEmptyEntries).Length - 1;
		}

		public static int WordCount<T>(this T s, string specificWord)
		{
			return 0;
		}
	}
}
