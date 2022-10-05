using System.Diagnostics.CodeAnalysis;

namespace ConsoleApp1
{
	internal class Program
	{
		public Vector Vector { get; set; }

		public Program()
		{
			Vector = new Vector();
		}

		static void Main(string[] args)
		{
			Vector vector = new Vector();

			Console.WriteLine($"X: {vector.X}");
			Console.WriteLine($"Y: {vector.Y}");

			Vector vector2 = new Vector()
			{
				X = 5,
				Y = 7
			};
			Console.WriteLine($"X: {vector2.X}");
			Console.WriteLine($"Y: {vector2.Y}");

			Vector vector3 = new Vector()
			{
				X = 5,
				Y = 7
			};

			Vector vector4 = new Vector()
			{
				X = 7,
				Y = 7
			};

			Vector vector5 = new Vector(10, 12);

			Console.WriteLine($"Equals: {vector2.Equals(vector3)}");
			Console.WriteLine($"Equals: {vector2.Equals(vector4)}");
			Console.WriteLine($"GetHashCode: {vector2.GetHashCode()}");
			Console.WriteLine($"GetHashCode: {vector3.GetHashCode()}");
			Console.WriteLine($"GetHashCode: {vector4.GetHashCode()}");
			Console.WriteLine($"ToString: {vector2}");
			Console.WriteLine($"ToString: {vector3}");
			Console.WriteLine($"ToString: {vector4}");
			Console.WriteLine($"ToString: {vector5}");

			// boxing
			int a = 5;
			object o = a;

			// unboxing
			int y = (int)o;

			double vectorLength = vector5;
			int roundedLength = (int)vector5;
			Console.WriteLine($"Vector's length: {vectorLength}");


			Vector vA = new Vector(3, 4);
			Vector vB = new Vector(4, 5);

			Vector vRes = vA + vB;
			Console.WriteLine(vRes);
			Console.WriteLine(vA == vB);
			Console.WriteLine(vA != vB);


			Vector vector6 = new Vector(3, 5);
			vector6[Dimension.Y] = -10;

			Console.WriteLine($"X: {vector6[Dimension.X]}");
			//Console.WriteLine($"Y: {vector6[(Dimension)1000]}");

			Vector v = new Vector(1, 1);

			AddXValue(v, 10);
			Console.WriteLine(v.ToString());

			MyClass myClass = new MyClass();
			Console.WriteLine(myClass.GetVector().ToString());

			myClass.GetVector().AddX(10);
			Console.WriteLine(myClass.GetVector().ToString());
		}

		private static void AddXValue(Vector vector, double num)
		{
			vector.X += num;
		}
	}

	public enum Dimension : int
	{
		X,
		Y
	}

	public struct Vector : IEquatable<Vector>
	{
		public double X { get; set; }
		public double Y { get; set; }


		public Vector(double x, double y)
		{
			X = x;
			Y = y;
		}

		public double this[Dimension dimension]
		{
			get => dimension switch
			{
				Dimension.X => X,
				Dimension.Y => Y,
				_ => throw new ArgumentOutOfRangeException(nameof(dimension))
			};
			set
			{
				switch (dimension)
				{
					case Dimension.X:
						X = value;
						break;
					case Dimension.Y:
						Y = value;
						break;
					default:
						throw new ArgumentOutOfRangeException(nameof(dimension));
				}
			}
		}

		/// <summary>
		/// Adds some value to X
		/// </summary>
		/// <param name="x">Value to be added</param>
		/// <exception cref="ArgumentException" >If x less than 0</exception>
		public void AddX(double x)
		{
			if(x < 0)
			{
				throw new ArgumentException(nameof(x));
			}
			X += x;
		}

		public bool Equals(Vector other)
		{
			return X == other.X && Y == other.Y;
		}

		public override int GetHashCode()
		{
			return (int)X.GetHashCode() ^ Y.GetHashCode();
		}

		public override string ToString()
		{
			return $"{{X: {X}, Y: {Y}}}";
		}

		public static implicit operator double(Vector vector)
		{
			return Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
		}

		public static explicit operator int(Vector vector)
		{
			return (int)Math.Sqrt(vector.X * vector.X + vector.Y * vector.Y);
		}

		public static Vector operator +(Vector vectorA, Vector vectorB)
		{
			return new Vector(vectorA.X + vectorB.X, vectorA.Y + vectorB.Y);
		}

		public static Vector operator -(Vector vectorA, Vector vectorB)
		{
			return new Vector(vectorA.X - vectorB.X, vectorA.Y - vectorB.Y);
		}

		public static bool operator ==(Vector vectorA, Vector vectorB)
		{
			return vectorA.Equals(vectorB);
		}

		public static bool operator !=(Vector vectorA, Vector vectorB)
		{
			return !vectorA.Equals(vectorB);
		}

		public static bool operator >(Vector vectorA, Vector vectorB)
		{
			return vectorA.X > vectorB.X && vectorA.Y > vectorB.Y;
		}

		public static bool operator <(Vector vectorA, Vector vectorB)
		{
			return vectorA.X < vectorB.X && vectorA.Y < vectorB.Y;
		}

		public static bool operator >=(Vector vectorA, Vector vectorB)
		{
			return vectorA.X > vectorB.X && vectorA.Y > vectorB.Y;
		}

		public static bool operator <=(Vector vectorA, Vector vectorB)
		{
			return vectorA.X < vectorB.X && vectorA.Y < vectorB.Y;
		}
	}


	public class MyClass
	{
		private Vector vector;

		public Vector GetVector()
		{
			return vector;
		}

		public void SetVector(Vector value)
		{
			vector = value;
		}

		public MyClass()
		{
			SetVector(new Vector(1, 1));
		}
	}
}