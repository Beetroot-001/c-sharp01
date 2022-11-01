using CalendarApp.Contracts;

namespace CalendarApp.Data
{

    public interface ICalendarRepository
    {
		void AddRoom(Room room);
		void AddMeeting(Meeting meeting, string roomName);
		Room GetLastRoom();
		IEnumerable<Room> GetRooms();
		IEnumerable<Meeting> GetMeetingList();
		IEnumerable<Meeting> GetMeetingRoom(string roomTitle);
    }


    public class CalendarRepository : ICalendarRepository
	{
		private readonly CalendarContext calendarContext;

		public CalendarRepository()
		{
			this.calendarContext = new CalendarContext("data.txt");
		}

		public IEnumerable<Meeting> GetMeetingList()
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

		public IEnumerable<Meeting> GetMeetingRoom(string roomTitle)
		{
			return calendarContext.Calendar.Rooms.Single(x => x.Title == roomTitle).Meetings;
        }

		public void AddRoom(Room room)
		{
			calendarContext.Calendar.Rooms.Add(room);

			calendarContext.SaveChanges();
		}

		public void AddMeeting(Meeting meeting, string roomName)
		{
			calendarContext.Calendar.Rooms.Single(x => x.Title == roomName).Meetings.Add(meeting);

			calendarContext.SaveChanges();
		}
	}
}
