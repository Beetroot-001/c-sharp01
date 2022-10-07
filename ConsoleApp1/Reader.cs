using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Reader : Person
    {
        string _ReaderInfo;
        Date _BornDate;

        public Reader()
        {
            _ReaderInfo = string.Empty;
            _BornDate = new Date();
        }

        public Reader(Person person, string readerInfo, Date bornDate) :
            base(person.FirstName, person.LastName, person.MiddleName)
        {
            _ReaderInfo = readerInfo;
            _BornDate = bornDate;
        }
         
        public Reader(string firstName, string lastName, string middleName, string readerInfo, Date bornDate) :
            base(firstName, lastName, middleName)
        {
            _ReaderInfo = readerInfo;
            _BornDate = bornDate;
        }

        public Reader(string firstName, string lastName, string middleName, string readerInfo, int bornDay, int bornMonth, int bornYear) :
            base(firstName, lastName, middleName)
        {
            _ReaderInfo = readerInfo;
            _BornDate = new Date(bornDay, bornMonth, bornYear);
        }

        public string ReaderInfo
        {
            get => _ReaderInfo;
            
            set => _ReaderInfo = value ?? throw new ArgumentException("Argument can`t be null");
        }

        public Date BornDate 
        { 
            get => _BornDate;

            set => _BornDate = value ?? throw new ArgumentException("Argument can`t be null");
        }
    }
}
