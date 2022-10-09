using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class AutoService
    {
        private AutoService Main;
        private TypesOfServices[] _Services;
        private Car[] _CarsInService;
        private Mechanic[] _Mechanics;
        private Client[] _Clients;
        private OrderList[] _orderLists;

        public AutoService()
        {
            this.Main = Main??new AutoService();
        }

        public void AddNewService(TypesOfServices servis)
        {
          
        }

        public void AddNewMechanic(Mechanic mechanic)
        {

        }

        public void AddCarInService(Car car)
        {

        }

        public void DelCarInServise(Car car) => Console.WriteLine("DelCarInServise()");

        public void DelService(TypesOfServices servis) => Console.WriteLine("DelService()");

        public void DellMechanic(Mechanic mechanic) => Console.WriteLine("DellMechanic()");

        public void DellClient(Client client) => Console.WriteLine("DellClient()");

        public void infoAboutCarsInService() => Console.WriteLine("infoAboutCarsInService()");

        public void infoAboutServices() => Console.WriteLine("infoAboutServices()");

        public void DisplayFullinfo() => Console.WriteLine("GetFullInfo()");
    }
}
