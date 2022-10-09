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

        private string _model, _engine;

        private int _graduationYear;

        public Car()
        {

        }

        public Car(BrandCar brandCar, string _model,string _engine, int _graduationYear)
        {

        }
        public virtual void DisplayFullInfo()
        {

        }
        public void Edit()
        {

        }
    }
    public class FuellCar:Car
    {
        private byte _engineCapacity;
        public FuelType fuelType;
        private byte _consumptionPer100km;

        public FuellCar()
        {

        }

        public override void DisplayFullInfo()
        {

        }

        public new void Eddit()
        {

        }
    }
    public class ElectroCar:Car
    {
        private int _enginePower, _batteryCapacity, _power, _powerReserve;
        private string _batteryCooling;


        public ElectroCar(int enginePower, int batteryCapacity, int power, int powerReserve, string batteryCooling)
        {
            _enginePower = enginePower;
            _batteryCapacity = batteryCapacity;
            _power = power;
            _powerReserve = powerReserve;
            _batteryCooling = batteryCooling;
        }

        public override void DisplayFullInfo()
        {

        }

        public void Eddit()
        {

        }
    }
}
