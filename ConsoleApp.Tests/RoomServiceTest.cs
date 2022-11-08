using CalendarApp.Core;
using CalendarApp.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Tests
{
    [TestClass]
    public class RoomServiceTest
    {
        [TestMethod]
        public void CreateRoom_NotNull()
        {
            var calendarRep = new CalendarRepository();

            var roomService = new RoomService(calendarRep);

            var room = roomService.CreateNewRoom("test7");

            Assert.IsNotNull(room);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Room with this title was already created!")]
        public void CreateRoom_Exists()
        {
            var calendarRep = new CalendarRepository();

            var roomService = new RoomService(calendarRep);

            roomService.CreateNewRoom("test");
            roomService.CreateNewRoom("test");
        }
    }
}
