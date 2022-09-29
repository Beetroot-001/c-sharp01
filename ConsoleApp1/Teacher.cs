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



        public string GetTeacherInfo()
        {
            return $"{name} teaches {subject.SubjectName}";
        }

        public void TeachLesson(List<Lesson> lesson)
        {
            Console.WriteLine($"Teacher {name} start lesson {lessons}");
        }


    }

}
