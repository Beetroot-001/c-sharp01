using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1
{
    internal class School
    {
        private string name;
        private List<Teacher> teachers = new List<Teacher>();
        private List<Student> students = new List<Student>();
        private List<Subject> subjects = new List<Subject>();

        public School(string name)
        {
            this.name = name;
           
        }

       public enum AddNew
        {
            teacher,
            student,
            subject
        }

        public void AddNewToSchool(AddNew addnew, object newOne )
        {
            switch (addnew)
            {
                case AddNew.teacher:
                    teachers.Add((Teacher)newOne);
                    break;
                case AddNew.student:
                    students.Add((Student)newOne);
                    break;
                case AddNew.subject:
                    subjects.Add((Subject)newOne);
                    break;              
            }

        }


        public void AddNewTeacher(params Teacher [] teacher)
        {
            foreach (var item in teacher)
            {
                teachers.Add(item);
            }
        }






        public void FireTeacher(Teacher teacher)
        {
            if (teachers.Contains(teacher))
            {
                teachers.Remove(teacher);               
            }
        }




        public void GetListOfTeachers()
        {
            Console.WriteLine($"The list of teachers who work in {name}");
            foreach (var item in teachers)
            {
                Console.WriteLine(item.GetTeacherInfo());
            }
        }




    }
}
