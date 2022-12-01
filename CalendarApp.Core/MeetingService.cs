using CalendarApp.Contracts;
using CalendarApp.Data;

namespace CalendarApp.Core
{
	public class MeetingService
	{
		private CalendarRepository calendarRepository = new CalendarRepository();

        public Meeting CreateNewMeeting(int roomId, string title, DateTime start, TimeSpan duration)
        {
            var newMeeting = new Meeting()
            {
                Title = title,
                Start = start,
                End = start + duration,
            };

            calendarRepository.AddMeeting(roomId, newMeeting);

            return newMeeting;
        }

        public IEnumerable<Meeting> GetMeetings()
		{
			return calendarRepository.GetMeetings();
		}
	}
}
