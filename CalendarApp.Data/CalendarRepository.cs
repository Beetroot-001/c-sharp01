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
        public ICollection<Room> ViewRooms()
        {
             return calendarContext.Calendar.Rooms;            
        }
        public void BookMeeting(Meeting meet, Room room)
        {            
            room.Meetings.Add(meet);
            calendarContext.SaveChanges();
        }
    }
}
