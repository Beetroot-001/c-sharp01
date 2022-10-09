using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
     public enum StatusMechanic
    {
        Vacation,
        Hospital,
        ArmedForces
    }

    public class Person
    {
        private string _firstNama, _lastName;
        private int _contactPhone;

        public Person()
        {

        }

        public virtual void DisplayFullinfo()
        {

        }
    }
    public class Client: Person
    {
        private string _email ;
        public int id { get; set; }

        private byte _quantityOfCars;
        public string GetEmail()
        {
            return _email;
        }

        public void EditInform() => Console.WriteLine();

        public override void DisplayFullinfo()
        {
            base.DisplayFullinfo();
        }
    }
    public class Mechanic:Person
    {
        private int _quantityOfOrderList, _idMechanic;
        public StatusMechanic status;
        private OrderList[] orderLists;

        public  void DisplayFullinfo()
        {

        }

        public void DisplayStatus()
        {

        }

        public int GetId()
        {
            return this._idMechanic;
        }

        public void AddOrder()
        {

        }

        public void DelOrder()
        {

        }
    }
}
