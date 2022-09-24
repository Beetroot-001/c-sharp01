namespace ConsoleApp1
{
	class PhoneBookRecord
	{
		public Person Person { get; set; }

		public string Phone { get; set; }

		public PhoneBookRecord(Person person, string phone)
		{
			Person = person;
			Phone = phone;
		}

		public PhoneBookRecord(string phone, Person person)
		{
			Person = person;
			Phone = phone;
		}

		public string Display()
		{
			return $"{Person.FullName} {Phone}";
		}
	}
}
