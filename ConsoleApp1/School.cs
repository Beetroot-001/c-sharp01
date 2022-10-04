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
      
        private List<Lesson> lessons = new List<Lesson>();


        public School(string name)
        {
            this.name = name; 
        }


         public void CreateNewLesson(Lesson lesson)
        {
            lessons.Add(lesson);
        }


        public void AddNewTeacher(params Teacher [] teacher)
        {           
            
            foreach (var item in teacher)
            {
                teachers.Add(item);
            }
        }   
        
        public void AddNewStudent(params Student [] student)
        {
            foreach (var item in student)
            {
                students.Add(item);
            }
        } 
        
        public void AddNewSubject(params Subject [] subject)
        {
            foreach (var item in subject)
            {
                subjects.Add(item);
            }
        }

        public void RemoveTeacher(Teacher teacher)
        {
            if (teachers.Contains(teacher))
            {
                teachers.Remove(teacher);               
            }
        }   
        
        public void RemoveStudent(Student student)
        {
            if (students.Contains(student))
            {
                students.Remove(student);               
            }
        } 
        
        public void RemoveSubject(Subject subject)
        {
            if (subjects.Contains(subject))
            {
                subjects.Remove(subject);               
            }
        }


        public void GetListOfTeachers()
        {
            Console.WriteLine($"The list of teachers who work at {name}");
            foreach (var item in teachers)
            {
                Console.WriteLine(item.GetTeacherInfo());
            }
        }  
        
        public void GetListOfStudents()
        {
            Console.WriteLine($"The list of students who study at {name}");
            foreach (var item in students)
            {
                Console.WriteLine(item.Name);
            }
        }  
        
        public void GetListOfSubjects()
        {
            Console.WriteLine($"The list of subjects that student study at {name}");
            foreach (var item in subjects)
            {
                Console.WriteLine(item.Name);
            }
        }




    }
}
