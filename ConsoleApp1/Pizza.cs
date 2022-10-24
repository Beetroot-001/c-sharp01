using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	public partial class Pizza
	{
		private readonly int diameter;
		private readonly bool withTomatos;
		private readonly bool withCheese;
		private readonly bool withOlives;

		private Pizza(int diameter, bool withTomatos, bool withCheese, bool withOlives)
		{
			this.diameter = diameter;
			this.withTomatos = withTomatos;
			this.withCheese = withCheese;
			this.withOlives = withOlives;
		}
	}
}
