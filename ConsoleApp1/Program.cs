namespace ConsoleApp1
{
  internal class Program
  {
    static void Main(string[] args)
    {
      /* Define and call with different parameters next methods: 
      * 1. Method that will return max value among all the parameters 
      * 2. … min value … 
      * 3. Method TrySumIfOdd that accepts 2 parameters and returns true if sum of numbers between inputs is odd, 
      *    otherwise false, sum return as out parameter * 4. Overload first two methods with 3 and 4 parameters */
      //1 & 2 

      int a = ReturnMax(12, 14);
      int b = ReturnMin(1, 67);
      Console.WriteLine(a); Console.WriteLine(b);

      //3 
      int i = 1; int j = 90; int sum; bool c = TrySumIfOdd(i, j, out sum);
      Console.WriteLine(i);
      Console.WriteLine(j);
      Console.WriteLine(c);

      //4 
      int d = FindMax(12, 90);
      Console.WriteLine(d);

      double g = FindMax(23, 67.6);
      Console.WriteLine(g);
    }

    //1 & 2 
    static int ReturnMax(int Number1, int Number2) => Number1 > Number2 ? Number1 : Number2; static int ReturnMin(int Number1, int Number2) => Number1 < Number2 ? Number1 : Number2;

    //3 
    static bool TrySumIfOdd(int number3, int number4, out int sum) { sum = number3 + number4; return sum % 2 != 0; }

    //4 
    static int FindMax(int number5, int number6)
    {
      if (number5 > number6)
      {
        return Math.Max(number5, number6);
      }

      return Math.Min(number5, number6);
    }

    static double FindMax(double number5, double number6)
    {
      if (number5 > number6)
      {
        return Math.Max(number5, number6);
      }

      return Math.Min(number5, number6);
    }
  }
}
