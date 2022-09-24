namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			//Person person = new Person();
			//Person person2 = new Person("Anatolii", "Lechenko", 24);

			//person.FirstName = "Anatolii 2";

			////Console.WriteLine($"Person's FirstName {}");
			//person2.Display();

			//Console.WriteLine($"Person's 2 FirstName {person2.FirstName}");


			//person.FirstName = "Anatolii 2";

			//Console.WriteLine(Person.PersonInstancesCount);
			//Console.WriteLine(Person.DEFAULT_AGE);


			var person1 = new Person("Ivan", "Ivan", 23);
			var person2 = new Person("Artem", "Artem", 21);
			var person3 = new Person("Petro", "Petro", 47);

			var record1 = new PhoneBookRecord(person1, "38091212");
			var record2 = new PhoneBookRecord(person2, "38091214");
			var record3 = new PhoneBookRecord(person3, "38091216");


			var phoneBook = new PhoneBook(new PhoneBookRecord[] { record1, record2, record3 });

			phoneBook.DisplayRecords();


			Console.WriteLine(phoneBook[0].Display());
		}
	}
}