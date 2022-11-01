namespace CalendarApp.Contracts
{
	[Serializable]
	public class Room
	{
		public int Id { get; set; }
		public string Title { get; set; }
		public ICollection<Meeting> Meetings { get; set; }

		public Room()
		{
			Meetings = new List<Meeting>();
		}

		public override string ToString()
		{
			return $"ID: {Id}{Environment.NewLine}" +
                $"Title: {Title}{Environment.NewLine}" +
                $"Meeting count: {Meetings.Count}";
		}

		//public string Number { get; set; }
		//public string Floor { get; set; }
		//public string Capacity { get; set; }
	}
}
