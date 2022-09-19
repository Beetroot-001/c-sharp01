using System;

namespace ConsoleApp1
{
	internal class Program
	{

        /// <summary>
        /// SelectionSort algorithm in direct order
        /// </summary>
        /// <param name="array">sort this array in direct order</param>
        static void SelectionSortAsc(int[] array)
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
        }

        /// <summary>
        /// SelectionSort algorithm in reverse order
        /// </summary>
        /// <param name="array">sort this array in reverse order</param>
        static void SelectionSortDesc(int[] array)
        {
            SelectionSortAsc(array);
            Array.Reverse(array);
        }


        /// <summary>
        /// BubbleSort algorithm in direct order
        /// </summary>
        /// <param name="array">sort this array in direct order</param>

        static void BubbleSortAsc(int[] array)
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
        }


        /// <summary>
        /// BubbleSort algorithm in reverse order
        /// </summary>
        /// <param name="array">sort this array in reverse order</param>

         static void BubbleSortDesc(int[] array)
        {
            SelectionSortAsc(array);
            Array.Reverse(array);
        }


        /// <summary>
        /// InsertionSort algorithm in direct order
        /// </summary>
        /// <param name="array">sort this array in direct order</param>
         static void InsertionSortAsc(int[] array)
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
        }

        /// <summary>
        /// InsertionSort algorithm in reverse order
        /// </summary>
        /// <param name="array">sort this array in reverse order</param>
         static void InsertionSortDesc(int[] array)
        {

            SelectionSortAsc(array);
            Array.Reverse(array);
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
        /// Sort array in accordance with choosen algorithm and direction
        /// </summary>
        /// <param name="array">array to sort</param>
        /// <param name="sortAlgorithmType">type of algorithm sort</param>
        /// <param name="orderBy">Asc - direct order, Desc - reverse order</param>
        static void SortArray( int[] array, SortAlgorithmType sortAlgorithmType, OrderBy orderBy)
        {

            if (orderBy == OrderBy.Asc)
            {
                switch (sortAlgorithmType)
                {
                    case SortAlgorithmType.SelectionSort:
                        SelectionSortAsc(array);
                        break;
                    case SortAlgorithmType.BubbleSort:
                        BubbleSortAsc(array);
                        break;
                    case SortAlgorithmType.InsertionSort:
                        InsertionSortAsc(array);
                        break;       
                }
            }
            else
            {
                switch (sortAlgorithmType)
                {
                    case SortAlgorithmType.SelectionSort:
                        SelectionSortDesc(array);
                        break;
                    case SortAlgorithmType.BubbleSort:
                        BubbleSortDesc(array);
                        break;
                    case SortAlgorithmType.InsertionSort:
                        InsertionSortDesc(array);
                        break;
                }
            }                     
        }

        static void Main(string[] args)
		{

            int[] array0 = { 3, 6, 1, 6, 4, 9, 2, 0 };
            SortArray(array0, SortAlgorithmType.SelectionSort, OrderBy.Desc);

            foreach (var item in array0)
            {
                Console.Write(item + " ");
            }


            //Extra Task
            Console.WriteLine();
            double[] array = { 23,4,46,23,1,4 };

            static double UniqueNum(double[] array )
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
            int [] array8 = { 5, 8, 3, 1, 9, 6, 4, 0, 7 };

            SelectionSortDesc(array8);

            foreach (var item in array8)
            {
                Console.Write($"{item}, ");
            }
        }
	}
}