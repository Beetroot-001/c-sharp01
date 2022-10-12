namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			int a = 10;
			int b = 20;
			Display(a, b);
			Swap(ref a, ref b);
			Display(a, b);


			string s1 = "hello";
			string s2 = "world";
			Display(s1, s2);
			Swap(ref s1, ref s2);
			Display(s1, s2);

			Display<object>(a, s1);

			LinkedList<Person> linkedList = new LinkedList<Person>();

			Console.WriteLine($"List length: {linkedList.Length}");
			linkedList.Add(new Person() { Fullname = "Petro Gudzyk" });
			Console.WriteLine($"List length: {linkedList.Length}");
			linkedList.Add(new Person() { Fullname = "Kyryl Lisoviy" });
			Console.WriteLine($"List length: {linkedList.Length}");
			linkedList.Add(new Person() { Fullname = "Taras Shevchenko" });
			Console.WriteLine($"List length: {linkedList.Length}");


			// var removedElement1 = linkedList.Remove(1);
			// var removedElement2 = linkedList.Remove(1);
			// var removedElement3 = linkedList.Remove(0);
			Console.WriteLine($"List length: {linkedList.Length}");


			var intLinkedList = new LinkedList<int>();
			intLinkedList.Add(1);
			intLinkedList.Add(2);
			intLinkedList.Add(3);

			intLinkedList.Insert(0, 0);
			intLinkedList.Insert(2, 2);
			intLinkedList.Insert(intLinkedList.Length, intLinkedList.Length);

			Console.WriteLine(intLinkedList.GetByIndex(0));
			Console.WriteLine(intLinkedList.GetByIndex(intLinkedList.Length - 1));

			Console.WriteLine(intLinkedList[0]);
			Console.WriteLine(intLinkedList[intLinkedList.Length - 1]);

			intLinkedList[0] = 5;


			int[] ints = new int[intLinkedList.Length];
			intLinkedList.CopyTo(ints);

			int[] ints2 = new int[2];
			intLinkedList.CopyTo(ints2);

			int[] ints3 = new int[20];
			intLinkedList.CopyTo(ints3);

			int[] ints1 = intLinkedList.ToArray();
		}

		public static void CoAndContrVariance()
		{
			Base base1 = new Base();
			Base derived1 = new Derived();
			Derived derived2 = new Derived();
			// Error: Derived derived3 = new Base();

			base1.DoSomething();
			derived2.DoSomething();
			derived2.DoMore();

			IProducer<Base> producerBase = null;
			Base b1 = producerBase.Produce();
			// Error: Derived b2 = producerBase.Produce();

			IProducer<Derived> producerDerived = null;
			Derived d1 = producerDerived.Produce();
			Base d2 = producerDerived.Produce();

			IProducer<Base> prodOfBase = producerDerived;
			// Error: IProducer<Derived> prodOfDerived = producerBase;

			IConsumer<Base> consumerB = null;
			consumerB.Consume(new Base());
			consumerB.Consume(new Derived());

			IConsumer<Derived> consumerD = null;
			consumerD.Consume(new Derived());
			// Error: consumerD.Consume(new Base());

			IConsumer<Derived> consOfDerived = consumerB;
			// Error: IConsumer<Base> consOfBase = consumerD;
		}

		public static void Swap<T>(ref T a, ref T b)
		{
			T temp = a;
			a = b;
			b = temp;
		}

		public static void Display<T>(T a, T b)
		{
			Console.WriteLine($"A: {a.ToString()}, B: {b.ToString()}");
		}

		public class Base
		{
			public void DoSomething()
			{
				Console.WriteLine($"Do something {this.GetType()}");
			}
		}

		public class Derived : Base
		{
			public void DoMore()
			{
				Console.WriteLine("Do more");
			}
		}

		public interface IProducer<out T>
		{
			T Produce();
		}

		public interface IConsumer<in T>
		{
			void Consume(T obj);
		}
	}
}