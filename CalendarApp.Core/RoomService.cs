﻿using CalendarApp.Contracts;
using CalendarApp.Data;

namespace CalendarApp.Core
{
	public class RoomService
	{
		private CalendarRepository calendarRepository = new CalendarRepository();

		public Room CreateNewRoom(string title)
		{
			var nextRoomId = (calendarRepository.GetLastRoom()?.Id ?? 0) + 1;

			var newRoom = new Room
			{
				Id = nextRoomId,
				Title = title,
			};

			calendarRepository.AddRoom(newRoom);

			return newRoom;
		}

		public Room GetRoomById(int id)
		{
			return calendarRepository.GetRoom(id);
        }

		public IEnumerable<Room> GetRooms()
		{
			return calendarRepository.GetRooms();
		}
	}
}
