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

		public IEnumerable<Room> GetRooms()
		{
			return calendarContext.Calendar.Rooms;
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

		public Room GetRoom(int id)
		{
			return calendarContext.Calendar.Rooms.Single(x => x.Id == id);
        }

		public void AddMeeting(int roomId, Meeting meeting)
		{
			try
			{
				GetRoom(roomId).Meetings.Add(meeting);
			}
			catch (ArgumentNullException)
			{
				Console.WriteLine($"no room with id {roomId}");
			}

			calendarContext.SaveChanges();
		}
	}
}
