namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*
			Describe ‘auto service’ domain that defines several entities: vehicle, wheel, engine, etc.

			Extra:

			Create UML diagram for this domain
			*/

            Engine engine = new Engine("STR", "V6");
            Vehicle vehicle4 = new("Audi", "A6", engine, "gas", new Transmission("auto"), new Wheels("TOYO", 19));

        }
    }
}