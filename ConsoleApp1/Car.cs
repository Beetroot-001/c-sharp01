using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
   public enum BrandCar
    {
        Tesla,
        BMW,
        Ford,
        Toyota,
        Honda,
        Audi,
        Jeep
    }
    public enum FuelType
    {
        Gas,
        Gasoline,
        Diesel,
        Hybrid
    }
    public class Car
    {
        public BrandCar brandCar;

        string _model, _engine;

        int _graduationYear;

        public Car()
        {

        }
        public void GetFullInform()
        {

        }
        public void Edit()
        {

        }
    }
    public class FuellCar:Car
    {
        byte _engineCapacity;
        FuelType fuelType;
        byte _consumptionPer100km;

        public FuellCar()
        {

        }

        public void GetFullInfo()
        {

        }

        public void Eddit()
        {

        }
    }
    public class ElectroCar:Car
    {
        int _enginePower, _batteryCapacity, _power, _powerReserve;
        string _batteryCooling;
        public ElectroCar()
        {

        }

        public void GetFullInfo()
        {

        }

        public void Eddit()
        {

        }
    }
}
