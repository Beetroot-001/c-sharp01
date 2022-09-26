using System;

namespace ConsoleApp1
{
	internal class Program
	{
        /// <summary>
        /// Selection sort algorithm
        /// </summary>
        /// <param name="array">array to sort</param>
        /// <param name="sortOrder">direct or reverse sort order</param>
        static void SelectionSort(int[] array, OrderBy sortOrder)
        {
            for (int i = 0; i < array.Length; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }
                int tempValue = array[minIndex];
                array[minIndex] = array[i];
                array[i] = tempValue;
            }

            if (sortOrder == OrderBy.Desc) Array.Reverse(array);    
            
        }

        /// <summary>
        /// Bubble sort algorithm
        /// </summary>
        /// <param name="array">array to sort</param>
        /// <param name="sortOrder">direct or reverse sort order</param>

        static void BubbleSort(int[] array, OrderBy sortOrder)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length -i -1; j++)
                {
                    if (array[j] > array[j+1])
                    {
                        int temp = array[j+1];
                        array[j+1] = array[j];
                        array[j] = temp; 
                    }
                }
            }

            if(sortOrder == OrderBy.Desc) Array.Reverse(array);

        }


        /// <summary>
        /// Insertion sort algorithm
        /// </summary>
        /// <param name="array">array to sort</param>
        /// <param name="sortOrder">direct or reverse sort order</param>
        static void InsertionSort(int[] array, OrderBy sortOrder)
        {
           
            for (int i = 1; i < array.Length; i++)
            {
                int key = i;
                while (key > 0 && array[key] < array[key - 1] )
                {
                    int temp = array[key-1];
                    array[key - 1] = array[key];
                    array[key] = temp;
                    key--;
                }
            }

            if (sortOrder == OrderBy.Desc) Array.Reverse(array);

        }

        enum SortAlgorithmType
        {
            SelectionSort,
            BubbleSort,
            InsertionSort
        }
        enum OrderBy
        {
            Asc,
            Desc
        }


        /// <summary>
        /// Sort array by chosen algorithm and order
        /// </summary>
        /// <param name="array">array to sort</param>
        /// <param name="sortAlgorithmType">algorithm sort type</param>
        /// <param name="orderBy">sort order type</param>
        static void SortArray(int[] array, SortAlgorithmType sortAlgorithmType, OrderBy orderBy)
        {
            switch (sortAlgorithmType)
            {
                case SortAlgorithmType.SelectionSort:
                    SelectionSort(array, orderBy);
                    break;
                case SortAlgorithmType.BubbleSort:
                    BubbleSort(array, orderBy);
                    break;
                case SortAlgorithmType.InsertionSort:
                    InsertionSort(array, orderBy);
                    break; 
            }

        }


        static void Main(string[] args)
		{

            int[] array0 = { 3, 6, 1, 6, 4, 9, 2, 0 };
            SortArray(array0, SortAlgorithmType.SelectionSort, OrderBy.Asc);

            foreach (var item in array0)
            {
                Console.Write(item + " ");
            }



            //Extra Task
            Console.WriteLine();
            double[] array = { 23, 4, 46, 23, 1, 4 };

            static double UniqueNum(double[] array)
            {
                for (int i = 0; i < array.Length; i++)
                {
                    bool numMatch = false;
                    int index = array.Length - 1 - i;
                    double num = array[index];

                    for (int j = 0; j < array.Length; j++)
                    {
                        if (array[index] == array[j] && index != j)
                        {
                            numMatch = true;
                            break;
                        }
                    }

                    if (!numMatch)
                    {
                        return num;
                    }
                }
                return 47;
            }

            Console.WriteLine(UniqueNum(array));


            Console.WriteLine("test");
            int[] array8 = { 5, 8, 3, 1, 9, 6, 4, 0, 7 };

            SelectionSortDesc(array8);

            foreach (var item in array8)
            {
                Console.Write($"{item}, ");
            }
        }
    }
}