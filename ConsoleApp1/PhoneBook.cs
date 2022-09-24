namespace ConsoleApp1
{
	class PhoneBook
	{
		public PhoneBookRecord[] Records { get; set; }

		public DateTime LastModifiedDate { get; set; }

		public PhoneBook(PhoneBookRecord[] records)
		{
			Records = records;
		}

		public void DisplayRecords()
		{
			foreach (var record in Records)
			{
				Console.WriteLine(record.Display());
			}
		}

		public PhoneBookRecord this[int index]
		{
			get
			{
				return Records[index];
			}
			set
			{
				Records[index] = value;
			}
		}
	}
}
