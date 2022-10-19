using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	public static class CustomExtensions
	{
		public static IEnumerable<IEnumerable<T>> ChunkBy<T>(this IEnumerable<T> collection, int size)
		{
			if (size < 0)
			{
				throw new ArgumentOutOfRangeException(nameof(size));
			}

			if (size == 0)
			{
				yield return Enumerable.Empty<T>();
				yield break;
			}

			T[] values = new T[size];
			int index = 0;

			foreach (var item in collection)
			{
				if (index >= size)
				{
					yield return values;

					values = new T[size];
					index = 0;
				}

				values[index++] = item;
			}

			if (index > 0)
			{
				Array.Resize(ref values, index);

				yield return values;
			}
		}

		// TRUE: "1", "true", "y", "yes"
		// FALSE: "0", "false", "n", "no"


		private static Dictionary<string, bool> boolMappings = new Dictionary<string, bool>
		{
			{ "1", true},
			{ "yes", true},
			{ "y", true},
			{ "true", true},

			{ "0", false},
			{ "false", false},
			{ "n", false},
			{ "no", false},
		};

		public static bool ToBool(this string str)
		{
			// case 1
			//return str switch
			//{
			//	"1" => true,
			//	"true" => true,
			//	"y" => true,
			//	"yes" => true,

			//	"0" => true,
			//	"false" => true,
			//	"n" => true,
			//	"no" => true,
			//	_ => throw new ArgumentException(),
			//};

			// case 2

			if (boolMappings.ContainsKey(str))
			{
				return boolMappings[str];
			}

			throw new ArgumentException();
		}

		public static int GetAge(this DateTime birthday)
		{
			var diff = DateTime.Now - birthday;

			return new DateTime().Add(diff).Year - 1;
		}


		public static bool IsWeekend(this DateTime dateTime)
		{
			return dateTime.DayOfWeek == DayOfWeek.Sunday
				|| dateTime.DayOfWeek == DayOfWeek.Saturday;
		}

		public static bool IsWorkDay(this DateTime dateTime)
		{
			return !dateTime.IsWeekend();
		}

		public static DateTime GetNextWorkDay(this DateTime dateTime)
		{
			//var nextDay = dateTime.AddDays(1);
			//do
			//{
			//	nextDay = dateTime.AddDays(1);

			//} while (!nextDay.IsWorkDay());

			//return nextDay;

			while ((dateTime = dateTime.AddDays(1)).IsWeekend())
			{
			}

			return dateTime;
		}

		public static IEnumerable<KeyValuePair<TKey, ICollection<TItem>>> MyGroupBy<TItem, TKey>(
			this IEnumerable<TItem> enumberable, Func<TItem, TKey> selector)
		{
			Dictionary<TKey, ICollection<TItem>> dictionary = new Dictionary<TKey, ICollection<TItem>>();

			foreach (var item in enumberable)
			{
				var elementValue = selector(item);

				if (!dictionary.ContainsKey(elementValue))
				{
					dictionary[elementValue] = new List<TItem>();

				}

				dictionary[elementValue].Add(item);
			}

			return dictionary;
		}
	}
}
