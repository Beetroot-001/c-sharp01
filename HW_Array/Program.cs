using System.ComponentModel.DataAnnotations;

namespace Less6
{
    internal class Program
    {
        enum SortAlgorithmType
        {
            SelectionSort,
            BubbleSort,
            InsertionSort
        }
        enum OrderBy
        {
            Asc = 33,
            Desc = 17
        }

        static void Main(string[] args)
        {
            Random random = new Random();
            int[] array = new int[random.Next(6, 12)];

            Console.WriteLine("Array Lenght: " + array.Length);
            Console.Write("Array contains: ");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(0, 10);
                Console.Write(array[i] + " ");
            }

            ArraySelectionSort(array);
            BubbleSort(array);
            InsertionSort(array);
            VariousSort(array, OrderBy.Desc);
            VariousSort1(array, SortAlgorithmType.SelectionSort);

        }

        private static void InsertionSort(int[] array)
        {
            Console.Write("InsertionSort: ");
            int n = array.Length;
            for (int i = 1; i < n; ++i)
            {
                int a = array[i];
                int j = i - 1;

                for (; j >= 0 && array[j] > a; j -= -1)
                    array[j + 1] = array[j];

                array[j + 1] = a;
            }
            for (int i = 0; i < n; ++i)
                Console.Write(array[i] + " ");


        }

        public static void BubbleSort(int[] array)
        {
            Console.Write("BubbleSort:    ");
            for (int i = 0; i < array.Length - 1; i++)
                for (int j = 0; j < array.Length - i - 1; j++)
                    if (array[j] > array[j + 1])
                    {
                        int a = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = a;
                    }

            for (int i = 0; i < array.Length; ++i) Console.Write(array[i] + " ");
            Console.WriteLine();
        }
        static void ArraySelectionSort(int[] array)
        {
            Console.Write("\nSelectionSort: ");
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minVal = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minVal]) minVal = j;
                }
                int a = array[minVal];
                array[minVal] = array[i];
                array[i] = a;
            }
            for (int j = 0; j<array.Length; ++j) Console.Write($"{array[j]} ");
            Console.WriteLine();
        }

        static void VariousSort(int[] array, OrderBy orderBy)
        {
            if (orderBy > OrderBy.Asc)
            {
                Console.WriteLine("\nExtr ******* ArraySelectionSort");
                ArraySelectionSort(array);
            }

            else if (orderBy < OrderBy.Asc)
            {
                Console.WriteLine("\nExtr ******* BubbleSort");
                BubbleSort(array);
            }
            else
                Console.WriteLine("\nExtr ******* InsertionSort");
            InsertionSort(array);
        }
        static void VariousSort1(int[] array, SortAlgorithmType sortAlgor)

        {
            {
                switch (sortAlgor)
                {
                    case SortAlgorithmType.SelectionSort:
                        Console.WriteLine("\nExtr ******* ArraySelectionSort");
                        ArraySelectionSort(array);
                        break;
                    case SortAlgorithmType.BubbleSort:
                        Console.WriteLine("\nExtr ******* BubbleSort");
                        BubbleSort(array);
                        break;
                    case SortAlgorithmType.InsertionSort:
                        Console.WriteLine("\nExtr ******* InsertionSort");
                        InsertionSort(array);
                        break;
                }
            }
            {
                switch (sortAlgor)
                {
                    case SortAlgorithmType.SelectionSort:
                        Console.WriteLine("\nExtr ******* ArraySelectionSort");
                        ArraySelectionSort(array);
                        break;
                    case SortAlgorithmType.BubbleSort:
                        Console.WriteLine("\nExtr ******* BubbleSort");
                        BubbleSort(array);
                        break;
                    case SortAlgorithmType.InsertionSort:
                        Console.WriteLine("\nExtr ******* InsertionSort");
                        InsertionSort(array);
                        break;
                }
            }

        }



    }





}
