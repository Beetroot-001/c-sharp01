using CalendarApp.Contracts;
using CalendarApp.Core;
using CommandLine;
using System.Reflection;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
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

			ModeOption? modeOption = obj as ModeOption;

			Console.WriteLine($"You start in {modeOption?.Mode ?? Mode.Read} mode");

			switch (obj)
			{
				case BookMeetingVerb bookMeetingVerb:
					Console.WriteLine("Booking new meeting...");
					if (bookMeetingVerb.Mode == Mode.Read)
					{
						Console.WriteLine("access denied\ntry start in ReadAndWrite mode");
						break;
					}
					var createdMeeting = meetingService.CreateNewMeeting(bookMeetingVerb.RoomId,
																		 bookMeetingVerb.Title,
																		 bookMeetingVerb.StartTime,
																		 bookMeetingVerb.TimeSpan);
					Console.WriteLine("Meeting has been booked");
					break;

				case ShowMeetingsVerb showMeetingsVerb:
					Console.WriteLine("Show all meetings");
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

				case ShowMeetingsInRoomVerb showMeetingsInRoomVerb:
					Room? room = null;
                    try
                    {
						room = roomService.GetRoomById(showMeetingsInRoomVerb.RoomId);
                    }
                    catch (ArgumentNullException)
                    {
                        Console.WriteLine($"no room with id {showMeetingsInRoomVerb.RoomId}");
						break;
                    }

					Console.WriteLine($"Room: {room.ToString()}");

					if (!room.Meetings.Any())
					{
						Console.WriteLine($"no meetings in room with id {showMeetingsInRoomVerb.RoomId}");
					}

					foreach(var meeting in room.Meetings)
					{
						Console.WriteLine('\t' + meeting.ToString());
					}
                    break;

				case AddRoomVerb addRoomVerb:
					Console.WriteLine("Adding new room...");
					if (addRoomVerb.Mode == Mode.Read)
					{
						Console.WriteLine("access denied\ntry start in ReadAndWrite mode");
						break;
					}
					var createdRoom = roomService.CreateNewRoom(addRoomVerb.Title ?? "");
					Console.WriteLine("Room has been created");
					break;

				case ShowRoomVerb showRoomVerb:
					Console.WriteLine("Show rooms:");
					IEnumerable<Room> rooms = roomService.GetRooms();
					foreach (var item in rooms)
					{
						Console.WriteLine(item.ToString());
						if (showRoomVerb.ShowMeetings)
						{
							if (!item.Meetings.Any())
							{
								Console.WriteLine("no meetings planned");
								continue;
							}
							foreach (var meeting in item.Meetings)
							{
								Console.WriteLine(meeting.ToString());
							}
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

		[Verb("book-meeting", HelpText = "Create new meeting in peecked room")]
		public class BookMeetingVerb : ModeOption
		{
			[Option("room-id", Required = true)]
			public int RoomId { get; set; }

			[Option("title", Required = true)]
			public string Title { get; set; }

			[Option("start-time", Required = true)]
			public DateTime StartTime { get; set; }

			[Option("duration", Required = true)]
			public TimeSpan TimeSpan { get; set; }
		}

		[Verb("show-meetings", HelpText = "Show all meetings in the calendar.")]
		public class ShowMeetingsVerb : ModeOption
		{
		}

		[Verb("show-meetings-in-room", HelpText = "Show booked meetings in selected room")]
		public class ShowMeetingsInRoomVerb : ModeOption
		{
			[Option("room-id", Required = true)]
			public int RoomId { get; set; }
		}

		[Verb("add-room", HelpText = "Create room in the calendar.")]
		public class AddRoomVerb : ModeOption
		{
			[Option("title", Required = true)]
			public string? Title { get; set; }
		}

		[Verb("show-rooms", HelpText = "Show all available rooms in the calendar")]
		public class ShowRoomVerb : ModeOption
		{
			[Option("show-meetings", Default = false, Required = false)]
			public bool ShowMeetings { get; set; }
		}

		public enum Mode
		{
			Read = 1,
			ReadAndWrite = 2
		}
	}
}