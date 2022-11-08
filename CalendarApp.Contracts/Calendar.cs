namespace CalendarApp.Contracts
{
	[Serializable]
	public class Calendar 
	{ 
		public string Title { get; set; }
		public ICollection<Room> Rooms { get; set; }

		public Calendar()
		{
			Rooms = new List<Room>();
		}
	}
}
