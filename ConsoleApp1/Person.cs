using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Person
    {
        private string name;
        private int age;
        private long salary;
        private bool isMarried;
        private DateTime birthday;
        private bool hasKids;

        public string Name => name;
        public int Age => age;

        public DateTime Birthday => birthday;

        public bool IsMarried 
        { 
            get { return isMarried; } 
            set { isMarried = value;}
        }

        public long GetCurrentSalary(long promotion)
        {
            return salary + promotion;
        }

        private bool HasKids()
        {
            return hasKids;
        }

    }
}
