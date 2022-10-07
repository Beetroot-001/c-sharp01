using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    //Зробив свій клас тому що не було потреби зберігати час.
    internal class Date
    {
        int _Day;
        int _Month;
        int _Year;

        public Date()
        {
            _Day = 1;
            _Month = 1;
            _Year = 1;
        }

        public Date(int day, int month, int year)
        {
            _Day = day;
            _Month = month;
            _Year = year;
        }

        public int Day
        {
            get => _Day;
            set 
            {
                if ((value > 0) && (value < 32))
                {
                    _Day = value;
                } 
            }
        }

        public int Month
        {
            get => _Month;
            set 
            {
                if ((value > 0) && (value < 13))
                {
                    _Month = value;
                }
            }
        }
        public int Year
        {
            get => _Year;

            set => _Year = value;
        }
    }
}
