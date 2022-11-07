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


        private void AddRoom(Room newRoom)
        {
            rooms.Add(newRoom);
            WriteToJson(newRoom);
        }

        public void ShowRoomList()
        {
            int counter = 0;
            foreach (var item in rooms)
            {
                Console.WriteLine($"#{++counter}. {item.Name}");
            }
        }

        public void ShowRoomStatus(int roomNumber)
        {
            rooms[roomNumber].ShowMeetings();
        }

        public void BookRoom(int roomNumber)
        {

            if (rooms[roomNumber].BookingProcess())
            {
                Console.WriteLine("The room is succesfully booked.");
            }
            else
            {
                Console.WriteLine("This time is not available");
            }

        }

    
        private void Menu()
        { 
            Console.WriteLine("0.Exit calendar");
            Console.WriteLine("1.Add a new room");
            Console.WriteLine("2.View rooms list");
            Console.WriteLine("3.Book meeting");
            Console.WriteLine("4.See the booked shedule of the room");
        }

        private void ReturnToMenu()
        {
            Console.WriteLine("Press any key to return to main menu");
            Console.ReadKey();
            Console.Clear();
            CalendarInterface();
        }


       
        public void CalendarInterface()
        {
            Menu();
            var input = Console.ReadKey(true);

            switch (input.Key)
            {
                case ConsoleKey.D0 :
                    
                    Console.WriteLine("Thank for using the app. See you never.");
                    return;

                case ConsoleKey.D1:
                    
                    Console.WriteLine("Add the name of a new room");
                    string newRoom = Console.ReadLine();
                    AddRoom(new Room(newRoom));
                    Console.WriteLine($"The room {newRoom} is succesfully added.");
                    ReturnToMenu();
                    break;

                case ConsoleKey.D2:

                    Console.WriteLine("The list of avialable rooms");
                    ShowRoomList();
                    ReturnToMenu();
                    break;

                case ConsoleKey.D3:
                    ShowRoomList();
                    Console.WriteLine("Choose the room to book the time");
                    var roomChoice = Console.ReadLine();
                    int.TryParse(roomChoice, out int roomNumber);
                    
                    if (roomNumber == 0 || rooms.Count < roomNumber)
                    {
                        Console.WriteLine("This room doesn't exist");
                        ReturnToMenu();
                        break;
                    }

                    BookRoom(roomNumber-1);
                    ReturnToMenu();
                    break;

                case ConsoleKey.D4:
                    ShowRoomList();
                    Console.WriteLine("Choose the room to check its booking shedule.");
                    var room = Console.ReadLine();

                    if (int.TryParse(room, out int roomNum))
                    {
                        ShowRoomStatus(roomNum-1);
                    }
                    ReturnToMenu();
                    break;
            }

        }



      public void WriteToJson(Room newRoom)
        {
            var jsonRoom = Newtonsoft.Json.JsonConvert.SerializeObject(newRoom, Newtonsoft.Json.Formatting.Indented);

            string path = @"calendar.json";

            using (var tw = new StreamWriter(path, true))
            {
                tw.WriteLine(jsonRoom.ToString());
                tw.Close();
            }
        }

        public void Modify()
        {
           

            string filepath = "calendar.json";

            var obj = JObject.Parse(filepath);
            
            //var objects = JsonConvert.DeserializeObject(obj);
            

        }



 


        public static void ReplaceJsonValue()
        {
            string filepath = @"calendar.json";
            string result = string.Empty;
           
            using (StreamReader r = new StreamReader(filepath))
            {
                var json = r.ReadToEnd();
                var jobj = JObject.Parse(json);


              


                foreach (var item in jobj.Properties())
                {
                    item.Value = item.Value.ToString().Replace("v1", "v2");
                }
               
                
                result = jobj.ToString();
                Console.WriteLine(result);
            }
            File.WriteAllText(filepath, result);
        }



    }
}
