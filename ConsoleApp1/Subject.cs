using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Subject
    {
        private string name;

        public Subject(string name)
        {
            this.name = name;
        }


        public string SubjectName { get { return name; } }
    }
}
