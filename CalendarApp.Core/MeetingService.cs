using CalendarApp.Contracts;
using CalendarApp.Data;

namespace CalendarApp.Core
{
	public class MeetingService
	{
		private CalendarRepository calendarRepository = new CalendarRepository();

		public IEnumerable<Meeting> GetMeetings()
		{
			return calendarRepository.GetMeetings();
		}
	}
}
