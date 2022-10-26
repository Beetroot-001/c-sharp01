using CalendarApp.Contracts;

namespace CalendarApp.Data
{
	public class CalendarRepository
	{
		private readonly CalendarContext calendarContext;

		public CalendarRepository()
		{
			this.calendarContext = new CalendarContext("data.bin");
		}

		public IEnumerable<Meeting> GetMeetings()
		{
			return calendarContext.Calendar.Rooms.SelectMany(x => x.Meetings);
		}

		public Room GetLastRoom()
		{
			return calendarContext.Calendar.Rooms.MaxBy(x => x.Id);
		}

		public void AddRoom(Room room)
		{
			calendarContext.Calendar.Rooms.Add(room);

			calendarContext.SaveChanges();
		}
	}
}
