using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    enum StatusMechanic
    {
        Vacation,
        Hospital,
        ArmedForces
    }

    public class Person
    {
        string _firstNama, _lastName;
        int _contactFone;

        public Person()
        {

        }

        public virtual void GettFullName()
        {

        }
    }
    public class Client: Person
    {
        string _E_mail ;
        public int id { get; set; }
        byte _quantityOfCars;
        public void GetEmail()
        {

        }

        public void EditInform() => Console.WriteLine();

        public override void GettFullName()
        {
            base.GettFullName();
        }
        
        public void GetFullInfo()
        {

        }
    }
    public class Mechanic:Person
    {
        int _quantityOfOrderList, _idMechanic;
        StatusMechanic status;
        OrderList[] orderLists;

        public  void GetFullinfo()
        {

        }

        public void GetStatus()
        {

        }

        public void GetId()
        {

        }

        public void AddOrder()
        {

        }

        public void DelOrder()
        {

        }
    }
}
