namespace ConsoleApp1
{
	internal class Program
	{
        static void Main(string[] args)
        {
            int[] arr = new int[10] { 56, 1, 99, 67, 89, 23, 44, 12, 78, 34 };
            Sort(arr, SortAlgorithmType.Selection, OrderBy.Desc);
            Sort(arr, SortAlgorithmType.Selection, OrderBy.Asc);

        }
       //Info is taken from:
       //1.https://www.tutorialspoint.com/selection-sort-program-in-chash
       //2.https://www.w3resource.com/csharp-exercises/searching-and-sorting-algorithm/searching-and-sorting-algorithm-exercise-3.php
       //3.https://www.w3resource.com/csharp-exercises/searching-and-sorting-algorithm/searching-and-sorting-algorithm-exercise-6.php


            //Extra: 
            //Define enum SortAlgorithmType with all 3 algorithms types
            //and create single function Sort that will accept array
            //and SortAlgorithmType and use passed algorithm to sort array

        enum SortAlgorithmType
        {
            Selection,
            Bubble,
            Insertion
        }


        //Selection
        static int[] Selection(int[] arr)
        {
            int temp;
            int smallest;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                smallest = i;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] < arr[smallest])
                    {
                        smallest = j;
                    }
                }
                temp = arr[smallest];
                arr[smallest] = arr[i];
                arr[i] = temp;
            }
            Console.WriteLine();
            Console.Write("Sorted array is: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
            return arr;
        }

        //Bubble
         static int[] Bubble(int[] a)
        {
            int t;
            Console.WriteLine("Original array :");
            foreach (int aa in a)
                Console.Write(aa + " ");
            for (int p = 0; p <= a.Length - 2; p++)
            {
                for (int i = 0; i <= a.Length - 2; i++)
                {
                    if (a[i] > a[i + 1])
                    {
                        t = a[i + 1];
                        a[i + 1] = a[i];
                        a[i] = t;
                    }
                }
            }
            Console.WriteLine("\n" + "Sorted array :");
            foreach (int aa in a)
                Console.Write(aa + " ");
            Console.Write("\n");
            return a;
        }

        //Insertion
        static int[] InsertionSort(int[] inputArray)
        {
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (inputArray[j - 1] > inputArray[j])
                    {
                        int temp = inputArray[j - 1];
                        inputArray[j - 1] = inputArray[j];
                        inputArray[j] = temp;
                    }
                }
            }
            return inputArray;
        }

        //In progress
        static int[] Sort(int[] array, SortAlgorithmType type, OrderBy order)
        {
            switch (type)
            {
                case SortAlgorithmType.Selection:
                    Selection(array);
                    break;
                case SortAlgorithmType.Bubble:
                    Bubble(array);
                    break;
                case SortAlgorithmType.Insertion:
                    InsertionSort(array);
                    break;
            }
            //TODO
            if(order == OrderBy.Asc)
            {
                return array;
            }
            else
            {
                int[] array2  = new int[array.Length];
                int j = 0;
                for(int i = array.Length-1; i > 0; i--)
                {
                    array2[j] = array[i];
                    j++;
                }
                return array2;
            }
           
        }

        //TODO: in progress
        //Define enum OrderBy with 2 values: Asc and Desc and
        //update Sort method with this parameter that will change sort order


        enum OrderBy
        {
            Asc,
            Desc
        }
    }
}