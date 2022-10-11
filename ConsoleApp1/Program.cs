﻿using ConsoleApp1.FIlters;
using ConsoleApp1.Lights;
using ConsoleApp1.Wheels;
using ConsoleApp1.Windows;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Vehicle mazda = new Vehicle();
			Wheel wheel = new Wheel(new Rim("alloy"), new Tire("natural rubber"), 16);

			mazda.AddWheel(wheel);
			mazda.AddWheel(wheel);
			mazda.AddWheel(wheel);
			mazda.AddWheel(wheel);

			mazda.AddBattery(new Battery(1000));
			mazda.AddEngine(new Engine(Engine.Type.InternalCombustion));
			mazda.AddTransmission(new Transmission(Transmission.Type.AutomaticTransmission));

			BrakeLight breakLight = new BrakeLight(new Glass(12, 6), new Frame("plastic", 2), Light.Bulbs.square, Light.Colors.red);		
			TailLight tailLight = new TailLight(new Glass(22, 6), new Frame("plastic", 2), Light.Bulbs.round, Light.Colors.red);
			HeadLight headLight = new HeadLight(new Glass(28, 6), new Frame("plastic", 5), Light.Bulbs.round, Light.Colors.white);

			mazda.AddLights(Vehicle.LightType.BreakLight, breakLight);		
			mazda.AddLights(Vehicle.LightType.TailLight, tailLight);
			mazda.AddLights(Vehicle.LightType.HeadLight, headLight);

			mazda.AddFilter(Vehicle.FilterType.OilFilter, new OilFilter());
			mazda.AddFilter(Vehicle.FilterType.AirFilter, new AirFilter());
			mazda.AddFilter(Vehicle.FilterType.FuelFilter, new FuelFilter());

			FrontWindow frontWindow = new FrontWindow(new Glass(16, 2), new Frame("plastic", 4));
			BackWindow backWindow = new BackWindow(new Glass(20, 2), new Frame("plastic", 4));
			DoorGlass doorGlass = new DoorGlass(new Glass(14, 3), new Frame("plastic", 2));
	
			mazda.AddWindow(Vehicle.WindowType.FrontWindow, frontWindow);
			mazda.AddWindow(Vehicle.WindowType.BackWindow, backWindow);
			mazda.AddWindow(Vehicle.WindowType.DoorGlass, doorGlass);

			mazda.CarInfo();
        }
	}
}