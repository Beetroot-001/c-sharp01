using ConsoleApp1.FIlters;
using ConsoleApp1.Lights;
using ConsoleApp1.Wheels;
using ConsoleApp1.Windows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{

    internal class Vehicle
    {
        private int wheelsNumber = 4;
        private List<Wheel> wheels = new List<Wheel>();

        private AirFilter airFilter;
        private FuelFilter fuelFilter;
        private OilFilter oilFilter;
      
        private Transmission transmission;
        private Battery battery;
        private Engine engine;

        private List<DoorGlass> doorGlasses = new List<DoorGlass>();
        private BackWindow backWindow;
        private FrontWindow frontWindow;

        private BrakeLight brakeLight;
        private TailLight tailLight;
        private HeadLight headLight;

 
        /// <summary>
        /// Add wheels to the vehicle
        /// </summary>
        /// <param name="wheel"></param>
        public void AddWheel(Wheel wheel)
        {
            if (wheels.Count< wheelsNumber)
            {
                wheels.Add(wheel);
            }
            else
            {
                Console.WriteLine($"The car has all {wheelsNumber} wheels. You can't add more.");
            }
        }    
        
        /// <summary>
        /// Show info about all wheels
        /// </summary>
        public void ShowWheelsInfo()
        {
            Console.WriteLine($"Currently this vehilce has {wheels.Count} wheels");
            foreach (var item in wheels)
            {
                item.Info();
            }
        }
        /// <summary>
        /// Add battery to the car
        /// </summary>
        /// <param name="battery"></param>
        public void AddBattery(Battery battery)
        {
            this.battery = battery;
        }   

        /// <summary>
        /// Add engine to the car
        /// </summary>
        /// <param name="engine"></param>
        public void AddEngine(Engine engine)
        {
            this.engine = engine;
        }
        
        /// <summary>
        /// Add trnasmission to the car
        /// </summary>
        /// <param name="engine"></param>
        public void AddTransmission(Transmission transmission)
        {
            this.transmission = transmission;
        }

        public enum LightType
        {
            BreakLight,
            TailLight,
            HeadLight
        }
        /// <summary>
        /// Add light to the car
        /// </summary>
        /// <param name="lightType"></param>
        /// <param name="light"></param>
        public void AddLights(LightType lightType, Light light)
        {
            switch (lightType)
            {
                case LightType.BreakLight:
                    brakeLight = (BrakeLight)light;
                    break;

                case LightType.TailLight:
                    tailLight = (TailLight)light;
                    break;

                case LightType.HeadLight:
                    headLight = (HeadLight)light;
                    break;               
            }
        }
       
        public enum FilterType
        {
            AirFilter,
            FuelFilter,
            OilFilter
        }
        /// <summary>
        /// Add filter to the car
        /// </summary>
        /// <param name="filterType"></param>
        /// <param name="filter"></param>
        public void AddFilter (FilterType filterType, Filter filter)
        {
            switch (filterType)
            {
                case FilterType.AirFilter:
                    airFilter = (AirFilter)filter;
                    break;
                case FilterType.FuelFilter:
                    fuelFilter = (FuelFilter)filter;
                    break;
                case FilterType.OilFilter:
                    oilFilter = (OilFilter)filter;
                    break;
                default:
                    break;
            }
        }

        public enum WindowType
        {
            DoorGlass,
            FrontWindow,      
            BackWindow
        }
        /// <summary>
        /// Add windows to the car
        /// </summary>
        /// <param name="windowType"></param>
        /// <param name="window"></param>
        public void AddWindow(WindowType windowType, Window window)
        {
            switch (windowType)
            {
                case WindowType.DoorGlass:
                    if (doorGlasses.Count < 4) doorGlasses.Add((DoorGlass)window);
                    break;
                case WindowType.FrontWindow:
                    frontWindow = (FrontWindow)window;
                    break;            
                case WindowType.BackWindow:
                    backWindow = (BackWindow)window;
                    break;                
            }
        }

        /// <summary>
        /// Show Car Info
        /// </summary>
        public void CarInfo()
        {
            Console.WriteLine($"The car has {wheels.Count} wheels");
            Console.WriteLine($"The battery capacity: {battery.Capacity}");
            Console.WriteLine($"The engine type: {engine.EngineType}");
            Console.WriteLine($"Transmission type: {transmission.TransmisionType}");
            Console.WriteLine($"Brake Light: {brakeLight.LightInfo}");
            Console.WriteLine($"Tail Light: {tailLight.LightInfo}");
            Console.WriteLine($"Head Light: {headLight.LightInfo}");
            Console.WriteLine($"Oil Filter: {oilFilter.Operation}");
            Console.WriteLine($"Air Filter: {airFilter.Operation}");
            Console.WriteLine($"Fuel Filter: {fuelFilter.Operation}");
            Console.WriteLine($"Back window info: {backWindow.WindowInfo}");
            Console.WriteLine($"Front window info: {frontWindow.WindowInfo}");
            foreach (var item in doorGlasses)
            {
                Console.WriteLine($"Door glass info: {item.WindowInfo}");
            }
        }

    }
}
