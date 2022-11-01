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
			return $"Title: {Title}{Environment.NewLine}" +
                $"Description: {Description}{Environment.NewLine}" +
                $"Start of the meeting: {Start}{Environment.NewLine}" +
                $"End of the meeting: {End}{Environment.NewLine}";
		}
	}
}
