using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Lesson
    {
        private string name;
        private int duration;
        private Subject subject;
        private Teacher teacher;
        private List<Student> students;

        public Lesson(string name, int duration, Subject subject, Teacher teacher)
        {
            this.name = name;
            this.duration = duration;
            this.subject = subject;
            this.teacher = teacher;

        }

        public void AddStudentsToLesson(params Student[] student )
        {
            foreach (var item in student)
            {
                students.Add(item);
            }
        }


    }

    



}
