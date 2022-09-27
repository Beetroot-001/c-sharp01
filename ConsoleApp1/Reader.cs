using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   

    class Reader
    {
        private string name;
        private string lastName;
        private ulong phoneNumber;
        private DateTime birthday;

        public Reader(string name, string lastName, ulong phoneNumber, DateTime birthday)
        
        {
            this.name = name;
            this.lastName = lastName;
            this.phoneNumber = phoneNumber;
            this.birthday = birthday;
        }

        public string Name {get {return name;} }
        public string LastName {get {return lastName;} }
        public DateTime Birthday {get {return birthday;} }

        public ulong PhoneNumber {get {return phoneNumber;} set {phoneNumber = value;}  }
        
        /// <summary>
        /// Display the info about reader
        /// </summary>
        /// <returns></returns>
        public string ReaderInfo()
        {
            return $"Name: {name}\nLastName: {lastName}\nPhone number: {phoneNumber}\nBirthday: {birthday.ToShortDateString()}";
        }

    }
}
