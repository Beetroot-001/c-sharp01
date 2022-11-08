using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using static ConsoleApp1.Room;

namespace ConsoleApp1
{
    internal class Calendar
    {
        List<Room> rooms = new List<Room>();
        private string path = @"calendar.json";

        /// <summary>
        /// Add a new room to the lsit of rooms
        /// </summary>
        /// <param name="newRoom"></param>
        private void AddRoom(Room newRoom)
        {
            rooms.Add(newRoom);
            WriteToJson();
        }

        /// <summary>
        /// Show the lsit of all created rooms
        /// </summary>
        public void ShowRoomList()
        {
            int counter = 0;
            foreach (var item in rooms)
            {
                Console.WriteLine($"#{++counter}. {item.Name}");
            }
        }

        /// <summary>
        /// Show the available/occupied time of the room from te list
        /// </summary>
        /// <param name="roomNumber"></param>
        public void ShowRoomStatus(int roomNumber)
        {
            rooms[roomNumber].ShowMeetings();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="roomNumber"></param>
        public void BookRoom(int roomNumber)
        {
            if (rooms[roomNumber].BookingProcess())
            {
                Console.WriteLine("The room is succesfully booked.");
                WriteToJson();
            }
            else
            {
                Console.WriteLine("This time is not available");
            }
        }

        /// <summary>
        /// Modify the access to calendar
        /// </summary>
        public enum Access
        {
            readOnly,
            fullAccess
        } 
    
        /// <summary>
        /// Display te menu with options
        /// </summary>
        /// <param name="access"></param>
        private void Menu (Access access)
        { 
            Console.WriteLine("0.Exit calendar");          
            Console.WriteLine("1.View rooms list"); 
            Console.WriteLine("2.See the booked shedule of the room");

            if (access == Access.fullAccess)
            {
                Console.WriteLine("3.Add a new room");
                Console.WriteLine("4.Book meeting");
            }            
        }

        /// <summary>
        /// Clear console and return to main menu
        /// </summary>
        /// <param name="access"></param>
        private void ReturnToMenu(Access access)
        {
            Console.WriteLine("Press any key to return to main menu");
            Console.ReadKey();
            Console.Clear();
            CalendarInterface(access);
        }

       /// <summary>
       /// Provide options to manipulate the calendar
       /// </summary>
       /// <param name="access"></param>
        private void CalendarInterface(Access access)
        {
            Menu(access);
            var input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.D0 :
                    
                    Console.WriteLine("Thank for using the app. See you never.");
                    return;

                case ConsoleKey.D1:

                    Console.WriteLine("The list of avialable rooms");
                    ShowRoomList();
                    ReturnToMenu(access);
                    break;

                case ConsoleKey.D2:
                    ShowRoomList();
                    Console.WriteLine("Choose the room to check its booking shedule.");
                    var room = Console.ReadLine();

                    if (int.TryParse(room, out int roomNum))
                    {
                        ShowRoomStatus(roomNum-1);
                    }
                    ReturnToMenu(access);
                    break;

                case ConsoleKey.D3:

                    if (access == Access.readOnly) goto default;

                    Console.WriteLine("Add the name of a new room");
                    string newRoom = Console.ReadLine();
                    AddRoom(new Room(newRoom));
                    Console.WriteLine($"The room {newRoom} is succesfully added.");
                    WriteToJson();
                    ReturnToMenu(access);
                    break;

                case ConsoleKey.D4:

                    if (access == Access.readOnly) goto default;

                    ShowRoomList();
                    Console.WriteLine("Choose the room to book the time");
                    var roomChoice = Console.ReadLine();
                    int.TryParse(roomChoice, out int roomNumber);

                    if (roomNumber == 0 || rooms.Count < roomNumber)
                    {
                        Console.WriteLine("This room doesn't exist");
                        ReturnToMenu(access);
                        break;
                    }

                    BookRoom(roomNumber - 1);
                    ReturnToMenu(access);
                    break;

                default:
                    Console.WriteLine("Pls, choose one of the avialable options.");
                    ReturnToMenu(access);
                    break;
            }
        }

        /// <summary>
        /// Write object to Json file
        /// </summary>
        public void WriteToJson()
        {
            var jsonRooms = JsonConvert.SerializeObject(rooms, Formatting.Indented);
            File.WriteAllText(path, jsonRooms);
        }

        /// <summary>
        /// Read object from json file and add it to the list of rooms
        /// </summary>
        public void ReadFromJsonFile()
        {
            var result = File.ReadAllText(path);

            if (result == String.Empty) return;
            var objects = JsonConvert.DeserializeObject<List<Room>>(result);

            rooms.Clear();

            foreach (var item in objects)
            {
                rooms.Add(item);
            }
        }

        /// <summary>
        /// Run calendar and choose the access mode
        /// </summary>
        public void RunCalendar()
        {
            if (!File.Exists(path))
            {
                var file = File.Create(path);
                file.Close();                
            }

            ReadFromJsonFile();

            Console.WriteLine("Choose the access mode");
            Console.WriteLine("0.Exit");
            Console.WriteLine("1.Read only mode");
            Console.WriteLine("2.Full access mode ");

            var result = Console.ReadLine();
            int.TryParse(result, out int accessChoice);

            switch (accessChoice)
            {
                case 1:
                    Console.Clear();
                    CalendarInterface(Access.readOnly);
                    break;

                case 2:
                    Console.Clear();
                    CalendarInterface(Access.fullAccess);
                    break;
                default:
                    break;
            }  
        }
    }
}
