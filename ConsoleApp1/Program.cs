namespace ConsoleApp1
{
	 enum SortType
    {
        Selection,
        Bubble,
        Insertion

    }
    internal class Program
    {
        static Random random = new Random();
        static void Main(string[] args)
        {
            int[] randomArray = new int[random.Next(4,10)];

            Console.WriteLine("\n__________________Selection_______________");
            ArrayFilling(randomArray);
            PrintArray(randomArray);
            SelectionAlgorithms(randomArray);
            PrintArray(randomArray);

            Console.WriteLine("\n________________Bubble_________________");
            ArrayFilling(randomArray);
            PrintArray(randomArray);
            BubbleAlgorithms(randomArray);
            PrintArray(randomArray);

            Console.WriteLine("\n________________Insertion_________________");
            ArrayFilling(randomArray);
            PrintArray(randomArray);
            InsertionAlgorithms(randomArray);
            PrintArray(randomArray);
            Console.WriteLine("\n________________Extra_________________");
            SortType typeOfSort = new SortType();
            typeOfSort = (SortType)random.Next(0, 2);
            Console.WriteLine($"type of sort - {typeOfSort}");
            ArrayFilling(randomArray);
            PrintArray(randomArray);
            SortAlgorithmType(randomArray,typeOfSort);
            PrintArray(randomArray);

            Console.ReadLine();
        }


        static void ArrayFilling(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
                array[i] = random.Next(-10, 30);
        }

        static void PrintArray(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            { 
                Console.Write($"{array[i]}\t");
                if (i==array.Length-1)
                    Console.WriteLine();
            }
        }


        //Implement 3 sort algorithms:

        //Selection
        static void SelectionAlgorithms(int[] array)
        {
            for (int i = 0; i < array.Length-1; i++)
            {
                int minValue = i;
                for (int j = i+1; j < array.Length; j++)
                {
                    if (j < array[minValue])
                        minValue = j;   
                }
                int temp = array[minValue];
                array[minValue] = array[i];
                array[i] = temp;
            }
        }

        //Bubble
        static void BubbleAlgorithms(int[] array)
        {
            for (int i = 0; i < array.Length - 1; i++)
                for (int j = 0; j < array.Length - i - 1; j++)
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
        }

        //Insertion
        static void InsertionAlgorithms(int[] array)
        {
            for (int i = 1; i < array.Length; ++i)
            {
                int key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j = j - 1;
                }
                array[j + 1] = key;
            }
        }

        /*Extra:

        Define enum SortAlgorithmType with all 3 algorithms types and create single function Sort
        that will accept array and SortAlgorithmType and use passed algorithm to sort array

        Define enum OrderBy with 2 values: Asc and Desc and update Sort method with this parameter that will change sort order
        */

        static void SortAlgorithmType(int[] array, SortType typeOfSort)
        {
            switch (typeOfSort)
            {
                case SortType.Selection:
                    SelectionAlgorithms(array);
                    break;
                case SortType.Bubble:
                    BubbleAlgorithms(array);
                    break;
                case SortType.Insertion:
                    InsertionAlgorithms(array);
                    break;
                default:
                    Console.WriteLine("Error type Of Sort");
                    break;
            }
        }
    }
}