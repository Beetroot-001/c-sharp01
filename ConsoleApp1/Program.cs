namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] exOne = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] exTwo = { 3, 1, 2, 4, 5, 6, 7, 8, 10, 9 };
            Console.WriteLine("Selection sort: ");
            
            Select(exOne);
            Print(exOne);
            
            Console.WriteLine();
            
            Select(exTwo);
            Print(exTwo);
            
            Console.WriteLine();
            
            Console.WriteLine("Bubble sort: ");
            Bubble(exOne);
            Print(exOne);
            
            Console.WriteLine();
            
            Bubble(exTwo);
            Print(exTwo);
            
            Console.WriteLine();
            
            Console.WriteLine("Insert sort: ");
            
            Insert(exOne);
            Print(exOne);

            Console.WriteLine();

            Insert(exTwo);
            Print(exTwo);

            Console.WriteLine();

            Console.WriteLine("Enums: ");

            

            Sort(exTwo, SortAlgorithmType.Select, SortedBy.Asc);
            Sort(exTwo, SortAlgorithmType.Select, SortedBy.Desc);
            Console.WriteLine();
            
            Sort(exTwo, SortAlgorithmType.Bubble, SortedBy.Asc);
            Sort(exTwo, SortAlgorithmType.Bubble, SortedBy.Desc);
            Console.WriteLine();

            Sort(exTwo, SortAlgorithmType.Insert, SortedBy.Asc);
            Sort(exTwo, SortAlgorithmType.Insert, SortedBy.Desc);
            Console.WriteLine();
        }
        static void Select(int[] ints)
        {
            int x = ints.Length;
            for (int i = 0; i < x - 1; i++)
            {
                int min = i;
                for (int j = i + 1; j < x; j++)
                {
                    if (ints[j] < ints[min])
                        min = j;
                }
                int temp = ints[min];
                ints[min] = ints[i];
                ints[i] = temp;
            }
        }
        static void Print(int[] ints)
        {
            for (int i = 0; i < ints.Length; i++)
            {
                Console.Write(ints[i] + " ");
            }
        }
        static void Bubble(int[] ints)
        {
            int x = ints.Length - 1;
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < x; j++)
                {
                    if (ints[j] > ints[j + 1])
                    {
                        int temp = ints[j];
                        ints[j] = ints[j + 1];
                        ints[j + 1] = temp;
                    }
                }
            }
        }
        static void Insert(int[] ints)
        {
            int x = ints.Length;
            for (int i = 0; i < x; i++)
            {
                int key = ints[i];
                int value = i - 1;
                while (value >= 0 && ints[value] > key)
                {
                    ints[value + 1] = ints[value];
                    value--;
                }
                ints[value + 1] = key;
            }
        }
        enum SortAlgorithmType
        {
            Select,
            Bubble,
            Insert

        }
        enum SortedBy
        {
            Asc,
            Desc
        }
        static void Sort(int[] ints, SortAlgorithmType sortAlgorithmType, SortedBy sortedBy)
        {

            switch ((sortAlgorithmType, sortedBy))
            {
                case (SortAlgorithmType.Select, SortedBy.Asc):
                    Select(ints);
                    Print(ints);
                    break;
                case (SortAlgorithmType.Select, SortedBy.Desc):
                    Select(ints);
                    Array.Reverse(ints);
                    Console.Write("|| ");
                    Print(ints);
                    break;
                case (SortAlgorithmType.Bubble, SortedBy.Asc):
                    Bubble(ints);
                    Print(ints);
                    break;
                case (SortAlgorithmType.Bubble, SortedBy.Desc):
                    Bubble(ints);
                    Array.Reverse(ints);
                    Console.Write("|| ");
                    Print(ints);
                    break;

                case (SortAlgorithmType.Insert, SortedBy.Asc):
                    Insert(ints);
                    Print(ints);
                    break;
                case (SortAlgorithmType.Insert, SortedBy.Desc):
                    Insert(ints);
                    Array.Reverse(ints);
                    Console.Write("|| ");
                    Print(ints);
                    break;

            }
        }
    }
}