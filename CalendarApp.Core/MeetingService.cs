using CalendarApp.Contracts;
using CalendarApp.Data;

namespace CalendarApp.Core
{
	public class MeetingService
	{
		private CalendarRepository calendarRepository = new CalendarRepository();
		private TimeSpan meetingSpan = new TimeSpan(0, 45, 0);

		public IEnumerable<Meeting> GetMeetings()
		{
			return calendarRepository.GetMeetings();
		}
		public void AddMeeting(string title)
        {
			Meeting meeting = new();
			meeting.Title = title;			
			DateTime.TryParse(Console.ReadLine(), out DateTime meetTime);
			meeting.Start = meetTime;
			meeting.End = meetTime + meetingSpan;
        }
	}
}
