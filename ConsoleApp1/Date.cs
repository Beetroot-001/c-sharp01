using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //Зробив свій клас тому що не було потреби зберігати час.
    internal class Date
    {
        private int _day;
        private int _month;
        private int _year;

        public Date()
        {
            _day = 1;
            _month = 1;
            _year = 1;
        }

        public Date(int day, int month, int year)
        {
            _day = day;
            _month = month;
            _year = year;
        }

        public int Day
        {
            get => _day;
            set 
            {
                if ((value > 0) && (value < 32))
                {
                    _day = value;
                } 
            }
        }

        public int Month
        {
            get => _month;
            set 
            {
                if ((value > 0) && (value < 13))
                {
                    _month = value;
                }
            }
        }
        public int Year
        {
            get => _year;
            set => _year = value;
        }
    }
}
