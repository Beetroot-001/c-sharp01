using System.Reflection;
using CalendarApp.Contracts;
using CalendarApp.Core;
using CommandLine;

namespace ConsoleApp1
{
    internal class Program
    {
        // NuGet: https://github.com/commandlineparser/commandline
        // (de)serialization https://stackoverflow.com/questions/6115721/how-to-save-restore-serializable-object-to-from-file
        private static void Main(string[] args)
        {
            var verbs = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => t.GetCustomAttribute<VerbAttribute>() != null).ToArray();

            var result = Parser.Default.ParseArguments(args, verbs)
                .WithParsed(Run);
        }

        private static void Run(object obj)
        {
            MeetingService meetingService = new MeetingService();
            RoomService roomService = new RoomService();

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
                case AddMeetingVerb addMeetingVerb:
                    if (addMeetingVerb.Mode == Mode.ReadAndWrite)
                    {
                        var createdMeeting = meetingService.AddMeeting(addRoomVerb.Title);
                        Console.WriteLine("Meeting added!");
                    }
                    else Console.WriteLine("ReadOnly mode, change to RW to add!");
                    break;
                case AddRoomVerb addRoomVerb:
                    if (addRoomVerb.Mode == Mode.ReadAndWrite)
                    {
                        var createdRoom = roomService.CreateNewRoom(addRoomVerb.Title);
                        Console.WriteLine("Room has been created");
                        Console.WriteLine(createdRoom);
                    }
                    else Console.WriteLine("ReadOnly mode, change to RW to add!");
                    break;

                case ShowRoomsVerb:
                    var rooms = roomService.ShowRooms();
                    foreach (var room in rooms)
                    {
                        Console.WriteLine(room.Id + " " + room.Title + " " + room.Meetings);
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
        [Verb("add-meeting", HelpText = "Add meeting to the calendar.")]
        public class AddMeetingVerb : ModeOption
        {
        }

        [Verb("add-room", HelpText = "Create room in the calendar.")]
        public class AddRoomVerb : ModeOption
        {
            [Option("title", Required = true)]
            public string Title { get; set; }
        }

        [Verb("view-rooms", HelpText = "View rooms in the calendar.")]
        public class ShowRoomsVerb : ModeOption
        {
        }

        public enum Mode
        {
            Read = 1,
            ReadAndWrite = 2
        }
    }
}