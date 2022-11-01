﻿using CalendarApp.Contracts;
using CalendarApp.Data;
using System;

namespace CalendarApp.Core
{
    public class MeetingService
    {
        private ICalendarRepository calendarRepository;

        public MeetingService(ICalendarRepository calendarRepository)
        {
            this.calendarRepository = calendarRepository;
        }

        public IEnumerable<Meeting> GetMeetings()
        {
            return calendarRepository.GetMeetingList();
        }

        public IEnumerable<Meeting> GetMeetingsRoom(string roomName)
        {
            return calendarRepository.GetMeetingRoom(roomName);
        }

        public Meeting BookMeeting(string room, string title, int startDay, int startHour, int duration, string desc = " ")
        {
            var roomID = calendarRepository.GetRooms()?
                                           .Where(x => x.Title == room)
                                           .Single();

            var maxDaysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, DateTime.Now.Month);


            if (startDay <= DateTime.Now.Day || startDay > maxDaysInMonth || duration <= 0 || duration > 10)
            {
                throw new ArgumentException("Start day or duration is invalid");
            }

            DateTime start = new DateTime(DateTime.Now.Year, DateTime.Now.Month, startDay, startHour, 0, 0);

            DateTime end = new DateTime(DateTime.Now.Year, DateTime.Now.Month, startDay, startHour + duration, 0, 0);

            var newMeet = new Meeting
            {
                Title = title,
                Start = start,
                End = end,
                Description = desc
            };

            calendarRepository.AddMeeting(newMeet, room);

            return newMeet;
        }
    }
}
