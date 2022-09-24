namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] exOne = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            int[] exTwo = { 3, 1, 2, 4, 5, 6, 7, 8, 10, 9 };
            Console.WriteLine("Selection sort: ");

            Select(exOne, SortedBy.Asc);
            Print(exOne);

            Console.WriteLine();

            Select(exOne, SortedBy.Desc);
            Print(exOne);

            Console.WriteLine();

            Console.WriteLine("Bubble sort: ");
            Bubble(exOne, SortedBy.Asc);
            Print(exOne);

            Console.WriteLine();

            Bubble(exOne, SortedBy.Desc);
            Print(exOne);

            Console.WriteLine();

            Console.WriteLine("Insert sort: ");

            Insert(exOne, SortedBy.Asc);
            Print(exOne);

            Console.WriteLine();

            Insert(exOne, SortedBy.Desc);
            Print(exOne);

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
        static void Select(int[] ints, SortedBy sortedBy)
        {
            int x = ints.Length;
            switch (sortedBy)
            {
                case SortedBy.Asc:

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

                    break;
                case SortedBy.Desc:
                    for (int i = 0; i < x - 1; i++)
                    {
                        int min = i;
                        for (int j = i + 1; j < x; j++)
                        {
                            if (ints[j] > ints[min])
                                min = j;
                        }
                        int temp = ints[min];
                        ints[min] = ints[i];
                        ints[i] = temp;

                    }
                    break;
            }
        }
        static void Print(int[] ints)
        {
            for (int i = 0; i < ints.Length; i++)
            {
                Console.Write(ints[i] + " ");
            }
        }
        static void Bubble(int[] ints, SortedBy sortedBy)
        {
            int x = ints.Length - 1;
            switch (sortedBy)
            {
                case SortedBy.Asc:
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
                    break;
                case SortedBy.Desc:
                    for (int i = 0; i < x; i++)
                    {
                        for (int j = 0; j < x; j++)
                        {
                            if (ints[j] < ints[j + 1])
                            {
                                int temp = ints[j];
                                ints[j] = ints[j + 1];
                                ints[j + 1] = temp;
                            }
                        }
                    }
                    break;
            }
        }
        static void Insert(int[] ints, SortedBy sortedBy)
        {
            int x = ints.Length;
            switch (sortedBy)
            {
                case SortedBy.Asc:

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
                    break;
                case SortedBy.Desc:
                    for (int i = 0; i < x; i++)
                    {
                        int key = ints[i];
                        int value = i - 1;
                        while (value >= 0 && ints[value] < key)
                        {
                            ints[value + 1] = ints[value];
                            value--;
                        }
                        ints[value + 1] = key;
                    }
                    break;
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
                    Select(ints, SortedBy.Asc);
                    Print(ints);
                    break;
                case (SortAlgorithmType.Select, SortedBy.Desc):
                    Select(ints, SortedBy.Desc);

                    Console.Write("|| ");
                    Print(ints);
                    break;
                case (SortAlgorithmType.Bubble, SortedBy.Asc):
                    Bubble(ints, SortedBy.Asc);
                    Print(ints);
                    break;
                case (SortAlgorithmType.Bubble, SortedBy.Desc):
                    Bubble(ints, SortedBy.Desc);

                    Console.Write("|| ");
                    Print(ints);
                    break;

                case (SortAlgorithmType.Insert, SortedBy.Asc):
                    Insert(ints, SortedBy.Asc);
                    Print(ints);
                    break;
                case (SortAlgorithmType.Insert, SortedBy.Desc):
                    Insert(ints, SortedBy.Desc);
                    Console.Write("|| ");
                    Print(ints);
                    break;

            }
        }
    }
}