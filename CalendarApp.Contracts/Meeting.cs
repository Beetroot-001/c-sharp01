namespace CalendarApp.Contracts
{
	[Serializable]
	public class Meeting
	{
		public string Title { get; set; }
		public string Description { get; set; }
		public DateTime Start { get; set; }
		public DateTime End { get; set; }

		public override string ToString()
		{
			return $"{Title}\nDescription: {Description}\nTime: {Start} - {End}";
		}
	}
}
