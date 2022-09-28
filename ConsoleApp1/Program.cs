using ClassLibrary1;

namespace ConsoleApp1
{
	internal class Program
	{
		//class Dog : Animal
		//{
		//	public Dog()
		//	{
		//		this.
		//	}
		//}

		static void Main(string[] args)
		{
			//var animal = new Animal();

			//Console.WriteLine(animal.NumOfPawns1);
			//Console.WriteLine(animal.NumOfPawns2);
			//Console.WriteLine(animal.NumOfPawns3);

			var personWithDefaultName = new Person("A", "B", "DefaultName");
			Console.WriteLine(personWithDefaultName.DefaultName);


			Person person = new Person()
			{
				FirstName = "Petro",
				LastName = "Petrovich"
			};

			Person person12 = new Person();
			person12.FirstName = "Petro";
			person12.LastName = "Petrovich";


			person.FullName = "Petro Petrovich";
			Console.WriteLine(person12.FirstName);
			Console.WriteLine(person12.LastName);


			//Person person2 = new Person("Anatolii", "Lechenko", 24);

			person.FirstName = "Anatolii 2";

			//Console.WriteLine($"Person's FirstName {}");
			//person2.Display();

			//Console.WriteLine($"Person's 2 FirstName {person2.FirstName}");


			person.FirstName = "Anatolii 2";

			Console.WriteLine(Person.PersonInstancesCount);
			Console.WriteLine(Person.DEFAULT_AGE);


			var person1 = new Person("Ivan", "Ivan", 23);
			var person2 = new Person("Artem", "Artem", 21);
			var person3 = new Person("Petro", "Petro", 47);

			var record1 = new PhoneBookRecord(person1, "38091212");
			var record2 = new PhoneBookRecord(person2, "38091214");
			var record3 = new PhoneBookRecord(person3, "38091216");


			var phoneBook = PhoneBook.GetOrCreatePhoneBook(new PhoneBookRecord[] { record1, record2, record3 });
			var phoneBook1 = PhoneBook.GetOrCreatePhoneBook(new PhoneBookRecord[] { record1, record2, record3 });

			Console.WriteLine(phoneBook == phoneBook1);

			phoneBook.DisplayRecords();

			Console.WriteLine(phoneBook[0].Display());
		}

		public static void Method(PhoneBook phone)
		{

		}
	}
}