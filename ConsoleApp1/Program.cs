using CalendarApp.Contracts;
using CalendarApp.Core;
using CalendarApp.Data;
using CommandLine;
using System.Reflection;

namespace ConsoleApp1
{
    internal class Program
    {
        // NuGet: https://github.com/commandlineparser/commandline
        // (de)serialization https://stackoverflow.com/questions/6115721/how-to-save-restore-serializable-object-to-from-file
        static void Main(string[] args)
        {

            var verbs = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetCustomAttribute<VerbAttribute>() != null).ToArray();

            var result = Parser.Default.ParseArguments(args, verbs)
                .WithParsed(Run);
        }

        private static void Run(object obj)
        {   
            // here is in question
            ICalendarRepository calendarRepository = new CalendarRepository();
            MeetingService meetingService = new MeetingService(calendarRepository);
            RoomService roomService = new RoomService(calendarRepository);

            switch (obj)
            {
                case ShowMeetingsVerb showMeetingsVerb:
                    Console.WriteLine($"Executing ShowAllMeetings in {showMeetingsVerb.Mode} mode");
                    IEnumerable<Meeting> meetings = meetingService.GetMeetings();

                    if (!meetings.Any())
                    {
                        Console.WriteLine("There are no meetings");
                        break;
                    }

                    foreach (Meeting meeting in meetings)
                    {
                        Console.WriteLine(meeting.ToString());
                    }
                    break;

                case AddRoomVerb addRoomVerb:
                    if (addRoomVerb.Mode != Mode.ReadAndWrite)
                    {
                        Console.WriteLine("ReadAndWrite mode required to modify!");
                        break;
                    }
                    var createdRoom = roomService.CreateNewRoom(addRoomVerb.Title);
                    Console.WriteLine("Room has been created");
                    Console.WriteLine(createdRoom);
                    break;

                case BookMeetingVerb bookMeeting:
                    if (bookMeeting.Mode != Mode.ReadAndWrite)
                    {
                        Console.WriteLine("ReadAndWrite mode required to modify!");
                        break;
                    }
                    var newMeet = meetingService.BookMeeting(bookMeeting.RoomName, bookMeeting.MeetingTitle, 
                        bookMeeting.StartDay, bookMeeting.StartHour, bookMeeting.Duration, bookMeeting.Desc);
                    Console.WriteLine("Meeting has been booked");
                    Console.WriteLine(newMeet);
                    break;

                case RoomBookedMeetingsVerb roomBookedMeetings:
                    if (roomBookedMeetings.Mode != Mode.ReadAndWrite)
                    {
                        Console.WriteLine("ReadAndWrite mode required to modify!");
                        break;
                    }
                    var meetingsInRoom = meetingService.GetMeetingsRoom(roomBookedMeetings.RoomName);

                    if (!meetingsInRoom.Any())
                    {
                        Console.WriteLine("There are no meetings in this room!");
                    }
                    else
                    {
                        foreach (var meeting in meetingsInRoom)
                        {
                            Console.WriteLine(meeting.ToString());
                        }
                    }
                    break;

                case ShowRoomListVerb showRoomList:
                    var rooms = roomService.GetRooms();
                    if (!rooms.Any())
                    {
                        Console.WriteLine("There are no rooms in the calendar!");
                    }
                    else
                    {
                        foreach (var room in rooms)
                        {
                            Console.WriteLine(room.ToString());
                        }
                    }
                    break;

                default:
                    throw new NotSupportedException();
            }
        }

        public class ModeOption
        {
            [Option("mode", Default = Mode.Read)]
            public Mode Mode { get; set; }
        }

        [Verb("show-meetings", HelpText = "Show all meetings in the calendar.")]
        public class ShowMeetingsVerb : ModeOption
        {

        }

        [Verb("add-room", HelpText = "Create room in the calendar.")]
        public class AddRoomVerb : ModeOption
        {
            [Option("title", Required = true)]
            public string Title { get; set; }
        }

        [Verb("booking", HelpText = "Book a meeting in a room")]
        public class BookMeetingVerb : ModeOption
        {
            [Option("room", Required = true)]
            public string RoomName { get; set; }

            [Option("title", Required = true)]
            public string MeetingTitle { get; set; }

            [Option("decs", Required = false)]
            public string Desc { get; set; }

            [Option("start-day", Required = true)]
            public int StartDay { get; set; }
            [Option("start-hour", Required = true)]
            public int StartHour { get; set; }

            [Option("duration", Required = true)]
            public int Duration { get; set; }

        }
        [Verb("show-meetings-room", HelpText = "Shows all meeting in selected room")]
        public class RoomBookedMeetingsVerb : ModeOption
        {
            [Option("roomname", Required = true)]
            public string RoomName { get; set; }
        }
        [Verb("show-rooms", HelpText = "Shows all rooms in calendar")]
        public class ShowRoomListVerb : ModeOption
        {

        }

        public enum Mode
        {
            Read = 1,
            ReadAndWrite = 2
        }
    }
}