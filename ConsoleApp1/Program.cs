namespace ConsoleApp1
{
  internal class Program
  {
    static void Main(string[] args)
    {

      /* Implement 3 sort algorithms:
      * 1. Selection
      * 2. Bubble
      * 3. Insertion
      */

      // Insertion sort algorithms

      int[] inseertionAl = new int[] { 23, 9, 85, 12, 99, 34, 60, 15, 100, 1 };
      int topGun = 10,
      number1,
      number2;

      for (int i = 1; i < topGun; i++)
      {
        number1 = inseertionAl[i];
        number2 = 0;
        for (int a = i - 1; a >= 0 && number2 != 1;)
        {
          if (number1 < inseertionAl[a])
          {
            inseertionAl[a + 1] = inseertionAl[a];
            a--;
            number1 = inseertionAl[a + 1];
          }
          else number2 = 1;
        }
      }
      Console.WriteLine("Sorted Array # 3: ");
      for (int i = 0; i < topGun; i++)
      {
        Console.Write(inseertionAl[i] + " ");
      }

      // Bubble sort algorithms

      int[] number3 = new int[] { 1, 3, 7, 7, 2, 4, 3, 61, 8 };
      int number4;

      for (int i = 0; i <= number3.Length - 2; i++)
      {
        for (int b = 0; b <= number3.Length - 2; b++)
        {
          if (number3[b] > number3[b + 1])
          {
            number4 = number3[b + 1];
            number3[b + 1] = number3[b];
            number3[b] = number4;
          }
        }
      }
      foreach (int number in number3)
      {
        Console.Write("Sorted array: ");
        Console.Write(number);
      }

      // Selection sort algorithms

      int[] selectionAl = new int[10] { 56, 1, 99, 67, 89, 23, 44, 12, 78, 34 };
      int topAce = 10;
      int number5,
      number6;

      for (int i = 0; i < topGun - 1; i++)
      {
        number6 = i;

        for (int a = i + 1; a < topGun; a++)
        {
          if (selectionAl[a] < selectionAl[number6])
          {
            number6 = a;
          }
        }

        number5 = selectionAl[number6];
        selectionAl[number6] = selectionAl[i];
        selectionAl[i] = number5;
      }

      Console.Write("Sorted array # 1: ");
      for (int i = 0; i < topAce; i++)
      {
        Console.Write($"{selectionAl[i]} ");
      }
    }
  }
}
