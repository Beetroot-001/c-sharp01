using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    [Serializable()]
    internal class Room
    {
        private string name;
        private Dictionary<TimeSpan, bool> freeHours;

        public Room(string name)
        {
            this.name = name;
            freeHours = new Dictionary<TimeSpan, bool>
            {
                {new TimeSpan(8, 0, 0), true},
                {new TimeSpan(9, 0, 0), true},
                {new TimeSpan(10, 0, 0), true},
                {new TimeSpan(11, 0, 0), true},
                {new TimeSpan(12, 0, 0), true},
                {new TimeSpan(13, 0, 0), true},
                {new TimeSpan(14, 0, 0), true},
                {new TimeSpan(15, 0, 0), true},
                {new TimeSpan(16, 0, 0), true},
                {new TimeSpan(17, 0, 0), true},
                {new TimeSpan(18, 0, 0), true}
            };
        }

        public string Name => name;

        public Dictionary<TimeSpan, bool> FreeHours => freeHours;

        /// <summary>
        /// Display the shedule of all available and occupied hours
        /// </summary>
        public void ShowMeetings()
        {
            for (int i = 0; i < freeHours.Count-1; i++)
            {
                   string status = freeHours.ElementAt(i).Value == true ? "available" : "occupied";
                   var color = status == "available" ? Console.ForegroundColor = ConsoleColor.Green : Console.ForegroundColor = ConsoleColor.Red;

                   Console.ForegroundColor = color;               
                   Console.WriteLine($"From {freeHours.ElementAt(i).Key} to {freeHours.ElementAt(i + 1).Key} status: {status}");
                   Console.ResetColor();
            }
        }

        /// <summary>
        /// Book time if the mentioned time span is free for booking
        /// </summary>
        /// <param name="time"></param>
        /// <returns> Return true if time is booked, false if time is not available </returns>
        public bool BookTime (TimeSpan time)
        {
            freeHours.TryGetValue(time, out bool result);

            if (result)
            {
                freeHours[time] = false;
                return true;
            }
            return false;
        }

        /// <summary>
        /// Choose the time to book 
        /// </summary>
        /// <returns>Return true if time is available or false if not</returns>
        public bool BookingProcess()
        {
            Console.WriteLine("The available time for booking");
            ShowMeetings();

            Console.WriteLine("Enter the time in the following format 14. You cannot book the room after 18:00");

            var input = Console.ReadLine();
            int.TryParse(input, out int bookingTime);
          
            TimeSpan time = new TimeSpan(bookingTime, 0, 0);

            return BookTime(time);
        }
    }
}
