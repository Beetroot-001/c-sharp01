
using CalendarApp.Core;
using CalendarApp.Data;
using Moq;

namespace ConsoleApp.Tests
{
    [TestClass]   
    public class MeetingServiceTest
    {
        [TestMethod]
        public void MeetingsIsNotNull_Test() 
        {
            // arrange
            var calendarRep = new CalendarRepository();

            var meetService = new MeetingService(calendarRep);

            // act

            var meetings = meetService.GetMeetings();

            // assert

            Assert.IsNotNull(meetings);

        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException),
            "Room with this name was not found!")]

        public void DateCheckMeeting_Room()
        {
            // arrange
            var calendarRep = new CalendarRepository();

            var meetService = new MeetingService(calendarRep);
            // act
            var meet = meetService.BookMeeting("temp", "hehe", 15, 16, 1);
            // assert
            
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "Start day or duration is invalid")]
        public void DateCheckMeeting_NoDate()
        {
            var calendarRep = new CalendarRepository();

            var roomService = new RoomService(calendarRep);

            var meetService = new MeetingService(calendarRep);

            roomService.CreateNewRoom("testroom");

            meetService.BookMeeting("testroom", "test1", 100, 12, 2);
        }
        [TestMethod]
        [ExpectedException(typeof(ArgumentException),
            "The hours are occupied in this room!")]
        public void DateCheckMeeting_Occupied()
        {
            var calendarRep = new CalendarRepository();

            var roomService = new RoomService(calendarRep);

            var meetService = new MeetingService(calendarRep);

            roomService.CreateNewRoom("testroom");
            meetService.BookMeeting("testroom", "test1", 10, 12, 2);
            meetService.BookMeeting("testroom", "test2", 11, 13, 2);
        }
    }
}
