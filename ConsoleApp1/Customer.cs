using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApp1
{
    public class Customer : Person
    {
        public Vehicle Vehicle
        {
            get; set; 
        }

        public AutoService AutoService
        {
            get; set;
        }

        public void LeaveVehicle()
        {
            throw new System.NotImplementedException();
        }

        public void TakeVehicle()
        {
            throw new System.NotImplementedException();
        }

        public void PayForJob()
        {
            throw new System.NotImplementedException();
        }
    }
}