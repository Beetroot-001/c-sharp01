using System.Timers;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			var game = new Game();

			game.StartGame();

			Thread.Sleep(Timeout.Infinite);
		}

		public static void M()
		{
			Program program = new Program();

			CounterChangeHandler changeHandler = program.InstanceMethod;

			changeHandler += program.InstanceMethod;
			changeHandler += program.InstanceMethod;
			changeHandler += program.InstanceMethod;
			changeHandler -= program.InstanceMethod;

			Counter counter = new Counter();
			counter.OnCounterChanged += program.InstanceMethod;

			counter.Increment();
			counter.Decrement();


			var ints = new[] { 1, 3, 4, 5, 6, };
			// 1, 4, 9,16, 25,36

			var result = Where(ints, CustomFilter).ToArray();
			var result2 = Select(ints, (element) => new Program()).ToArray();

			var result3 = Any(ints, (elemnt) => elemnt % 2 == 0);

			var result4 = First(ints, (elemnt) => elemnt % 2 == 0);

			var timer = new System.Timers.Timer(1000);
			timer.Elapsed += PrintEveryTime;
			timer.Elapsed += PrintEveryTime;

			timer.Start();

			Thread.Sleep(10000);
		}

		public static void PrintEveryTime(object? state, ElapsedEventArgs elapsedEventArgs)
		{
			Console.WriteLine("HELLO FROM Timer");
		}

		public static bool CustomFilter(int element)
		{
			return element > 3;
		}

		public void InstanceMethod(Counter counter, int oldValue, int newValue)
		{
			Console.WriteLine($"Instance: {{OldValue: {oldValue}, NewValue: {newValue}}}");

		}

		public static void HandleChange(Counter counter, int oldValue, int newValue)
		{
			Console.WriteLine($"{{OldValue: {oldValue}, NewValue: {newValue}}}");
		}

		public static void AnotherHandleChange(Counter counter, int oldValue, int newValue)
		{

			Console.WriteLine($"///// {{OldValue: {oldValue}, NewValue: {newValue}}}");
		}

		public static IEnumerable<T> Where<T>(IEnumerable<T> collection, Predicate<T> filter)
		{
			foreach (var item in collection)
			{
				if (filter(item))
				{
					yield return item;
				}
			}
		}

		public static IEnumerable<U> Select<T, U>(IEnumerable<T> collection, Func<T, U> selector)
		{
			foreach (var item in collection)
			{
				var result = selector(item);

				yield return result;
			}
		}

		public static bool Any<T>(IEnumerable<T> collection, Predicate<T> predicate)
		{
			foreach (var item in collection)
			{
				if (predicate(item))
				{
					return true;
				}
			}

			return false;
		}

		public static bool Any(int[] collection)
		{
			foreach (var item in collection)
			{
				var result = item % 2 == 0;

				if (result)
				{
					return true;
				}
			}

			return false;
		}

		public static T First<T>(IEnumerable<T> collection, Func<T, bool> func)
		{
			foreach (var item in collection)
			{
				if (func(item))
				{
					return item;
				}
			}

			throw new ArgumentException();
		}

		public static T FirstOrDefault<T>(IEnumerable<T> collection, Func<T, bool> func)
		{
			foreach (var item in collection)
			{
				if (func(item))
				{
					return item;
				}
			}

			return default(T);
		}
	}

	public delegate U Selector<T, U>(T element);

	public delegate void CounterChangeHandler(Counter counter, int oldValue, int newValue);

	public class Counter
	{
		private CounterChangeHandler _handler;
		public event CounterChangeHandler OnCounterChanged;

		public int Count { get; private set; }

		public void Increment()
		{
			var oldValue = Count++;
			OnCounterChange(oldValue, Count);
		}

		public void Decrement()
		{
			var oldValue = Count--;
			OnCounterChange(oldValue, Count);
		}

		private void OnCounterChange(int oldValue, int newValue)
		{
			OnCounterChanged.Invoke(this, oldValue, newValue);
		}
	}
}