using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Animal
    {
        private string name;
        private string breed;
        private int age;
        private string owner;

        public string Breed => breed;
        public int Age => age;

        public string Name()
        {
            return name;
        }

        public void ChangeOwner(string newOwner)
        {
            owner = newOwner;
        }

    }
}
