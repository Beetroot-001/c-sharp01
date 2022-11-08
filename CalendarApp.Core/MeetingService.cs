using CalendarApp.Contracts;
using CalendarApp.Data;

namespace CalendarApp.Core
{
	public class MeetingService
	{
		private CalendarRepository calendarRepository = new CalendarRepository();		
		RoomService roomService = new RoomService();

		public IEnumerable<Meeting> GetMeetings()
		{
			return calendarRepository.GetMeetings();
		}
		public Meeting AddMeeting(string title, string room, DateTime meetingStart, TimeSpan duration)
        {
			Meeting meeting = new();
			meeting.Title = title;			
			meeting.Start = meetingStart;
			meeting.End = meetingStart + duration;
			calendarRepository.BookMeeting(meeting, calendarRepository.BookRoom(room, meetingStart));
			

			return meeting;
        }		
	}
}
