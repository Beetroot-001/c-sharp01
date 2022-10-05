using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class AutoService
    {
        AutoService Main;
        Servis[] _Services;
        Car[] _CarsInService;
        Mechanic[] _Mechanics;
        Client[] _Clients;
        OrderList[] _orderLists;

        public AutoService()
        {
            this.Main = Main??new AutoService();
        }

        public void AddNewService(Servis servis)
        {
          
        }

        public void AddNewMechanic(Mechanic mechanic)
        {

        }

        public void AddCarInService(Car car)
        {

        }

        public void DelCarInServise(Car car) => Console.WriteLine("DelCarInServise()");

        public void DelService(Servis servis) => Console.WriteLine("DelService()");

        public void DellMechanic(Mechanic mechanic) => Console.WriteLine("DellMechanic()");

        public void DellClient(Client client) => Console.WriteLine("DellClient()");

        public void infoAboutCarsInService() => Console.WriteLine("infoAboutCarsInService()");

        public void infoAboutServices() => Console.WriteLine("infoAboutServices()");

        public void GetFullInfo() => Console.WriteLine("GetFullInfo()");
    }
}
