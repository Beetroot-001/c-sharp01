﻿namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
		}
	}

	public class CalcService
	{
		public int Add(string numbers)
		{
			int sum = 0;
			if (string.IsNullOrEmpty(numbers)) return sum;

			string delimiter = ",";
			List<string> delimiters = new List<string>() { "," };

			if (numbers.StartsWith("//"))
			{
				delimiters = new List<string> { numbers.Substring(2, 1)[0].ToString() };
				numbers = numbers.Substring(2);

				var t = numbers.Split('\n').First();
				if (t.StartsWith("[") && t.EndsWith("]"))
				{
					delimiters = new List<string> { t.Substring(1, t.Length - 2) };
					numbers = numbers.Substring(t.Length);
					if (t.Substring(1, t.Length - 2).Contains("]["))
					{
						delimiters = t.Substring(1, t.Length - 2).Split("][").ToList();
					}
				}

			}
			delimiters.Add("\n");
			string[]? elements = numbers.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

			var negative = elements.Where(x => x.Contains('-')).ToList();
			if (negative.Any())
			{
				throw new ArgumentException(string.Format("negatives not allowed: {0}", string.Join(delimiter, negative)));
			}

			for (int i = 0; i < elements.Length; i++)
			{
				sum += int.Parse(elements[i]) > 1000 ? 0 : int.Parse(elements[i]);
			}

			return sum;
		}
	}
}