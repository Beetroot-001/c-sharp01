using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
	public partial class Pizza
	{
		public class PizzaBuilder
		{
			private int diameter = 20;
			private bool withTomatos;
			private bool withCheese;
			private bool withOlives;

			private PizzaBuilder()
			{

			}
			public PizzaBuilder SetDiameter(int diameter)
			{
				this.diameter = diameter; ;
				return this;
			}

			public PizzaBuilder AddTomatos()
			{
				withTomatos = true;
				return this;
			}

			public PizzaBuilder AddCheese()
			{
				withTomatos = true;
				return this;
			}

			public PizzaBuilder AddOlives()
			{
				withTomatos = true;
				return this;
			}

			public static PizzaBuilder CreateBuilder()
			{
				return new PizzaBuilder();
			}

			public Pizza Build()
			{
				return new Pizza(diameter, withTomatos, withCheese, withOlives);
			}
		}
	}
}
