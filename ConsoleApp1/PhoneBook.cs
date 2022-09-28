namespace ConsoleApp1
{
	class PhoneBook
	{
		private static PhoneBook instance;

		public readonly PhoneBookRecord[] Records;

		public DateTime LastModifiedDate { get; set; }

		private PhoneBook(PhoneBookRecord[] records,)
		{
			Records = records;
		}

		static PhoneBook GetOrCreatePhoneBook(PhoneBookRecord[] records)
		{
			if (instance != null)
			{
				return instance;
			}

			instance = new PhoneBook(records);

			return;
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
