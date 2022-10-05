using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Buyer
    {
        private string _fname;
        private string FName
        {
            get => _fname;
            set => _fname = value;
        }

        private string _lname;
        private string LName
        {
            get => _lname;
            set => _lname = value;
        }

        private string _mname;
        private string MName
        {
            get => _mname;
            set => _mname = value;
        }

        private string _phone;
        private string Phone
        {
            get => _phone;
            set => _phone = value;
        }
    }
}
