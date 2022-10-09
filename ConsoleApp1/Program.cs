using System.Data;

namespace ConsoleApp1
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Car car = new Car();
			Mechanic mechanic = new Mechanic();
			Client client = new Client();
			TypesOfServices servis=new TypesOfServices();
			AutoService autoService = new AutoService();
			autoService.infoAboutServices();
			autoService.AddNewMechanic(mechanic);
		
        }
	}
}