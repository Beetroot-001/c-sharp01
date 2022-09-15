namespace ConsoleApp1
{
	internal class Program
	{
        /// <summary>
        /// SelectionSort algorithm in direct order
        /// </summary>
        /// <param name="array">sort this array in direct order</param>
        public static void SelectionSortAsc(int[] array)
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

            for (int i = 0; i < array.Length; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < array.Length; j++)
                {
                    if (array[j] > array[minIndex])
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
        /// BubbleSort algorithm in direct order
        /// </summary>
        /// <param name="array">sort this array in direct order</param>

        public static void BubbleSortAsc(int[] array)
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

        public static void BubbleSortDesc(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (array[j] < array[j + 1])
                    {
                        int temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }


        /// <summary>
        /// InsertionSort algorithm in direct order
        /// </summary>
        /// <param name="array">sort this array in direct order</param>
        public static void InsertionSortAsc(int[] array)
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
        public static void InsertionSortDesc(int[] array)
        {

            for (int i = 1; i < array.Length; i++)
            {
                int key = i;
                while (key > 0 && array[key] > array[key - 1])
                {
                    int temp = array[key - 1];
                    array[key - 1] = array[key];
                    array[key] = temp;
                    key--;
                }
            }
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

            int[] array = {1, 9, 2, 8, 7,1, 5, 4, 0, 6, 3 };
           

            SortArray(array,SortAlgorithmType.SelectionSort, OrderBy.Desc);

            foreach (var item in array)
            {
                Console.Write(item + " ");
            }

          



        }
	}
}