using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Teacher
    {
        private string name;
        private Subject subject;
        private List <Lesson> lessons;

        public Teacher(string name, Subject subject)
        {
            this.name = name;
            this.subject = subject;
        }
        public string Name { get { return name; }}

        public string GetTeacherInfo()
        {
            return $"{name} teaches {subject.Name}";
        }

        public void TeachLesson(List<Lesson> lesson)
        {
            Console.WriteLine($"Teacher {name} starts lesson {lessons}");
        }


    }

}
