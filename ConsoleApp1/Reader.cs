using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Reader : Person
    {
        private string _readerInfo;
        private Date _bornDate;

        public Reader()
        {
            _readerInfo = string.Empty;
            _bornDate = new Date();
        }

        public Reader(Person person, string readerInfo, Date bornDate) :
            base(person.FirstName, person.LastName, person.MiddleName)
        {
            _readerInfo = readerInfo;
            _bornDate = bornDate;
        }
         
        public Reader(string firstName, string lastName, string middleName, string readerInfo, Date bornDate) :
            base(firstName, lastName, middleName)
        {
            _readerInfo = readerInfo;
            _bornDate = bornDate;
        }

        public Reader(string firstName, string lastName, string middleName, string readerInfo, int bornDay, int bornMonth, int bornYear) :
            base(firstName, lastName, middleName)
        {
            _readerInfo = readerInfo;
            _bornDate = new Date(bornDay, bornMonth, bornYear);
        }

        public string ReaderInfo
        {
            get => _readerInfo;
            set => _readerInfo = value ?? throw new ArgumentException("Argument can`t be null");
        }

        public Date BornDate 
        { 
            get => _bornDate;
            set => _bornDate = value ?? throw new ArgumentException("Argument can`t be null");
        }
    }
}
