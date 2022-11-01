using CalendarApp.Contracts;
using CalendarApp.Data;

namespace CalendarApp.Core
{
	public class RoomService
	{
		private ICalendarRepository calendarRepository;

		public RoomService(ICalendarRepository calendarRepository)
		{
			this.calendarRepository = calendarRepository;
		}

		public Room CreateNewRoom(string title)
		{
			if (calendarRepository.GetRooms().Where(x => x.Title == title).Any())
				throw new ArgumentException("Room with this title was already created!");

			var nextRoomId = (calendarRepository.GetLastRoom()?.Id ?? 0) + 1;

			var newRoom = new Room
			{
				Id = nextRoomId,
				Title = title,
			};

			calendarRepository.AddRoom(newRoom);

			return newRoom;
		}

		public IEnumerable<Room> GetRooms()
		{
			return calendarRepository.GetRooms();
		}
	}
}
