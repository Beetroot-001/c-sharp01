using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Student
    {
        private string name;
        private List<Lesson> lessons;
        private List<Subject> subjects;

        public Student(string name)
        {
            this.name = name;
        }

        public string  Name { get { return name; } }

    }
}
