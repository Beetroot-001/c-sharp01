namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] ints = new int[10];

            ArrayRandom(ints);
            printArray(ints);
            Console.WriteLine("____________________________________________________");
            bubbleSort(ints);
            Console.WriteLine("Sorted array  bubbleSort");
            printArray(ints);
            Console.WriteLine("____________________________________________________");
            Insertionsort(ints);
            Console.WriteLine("Sorted array  Insertionsort");
            printArray(ints);
            Console.WriteLine("____________________________________________________");
            Selectionsort(ints);
            Console.WriteLine("Sorted array  Selectionsort");
            printArray(ints);



        }
        static void ArrayRandom(int[] arr)
        {
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(20);
            }
        }

        static void bubbleSort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] > arr[j + 1])
                    {
                        int temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                    }
                }

            }

        }
        static void Insertionsort(int[] arr)
        {
            int n = arr.Length;
            for (int i = 1; i < n; ++i)
            {
                int key = arr[i];
                int j = i - 1;
                while (j >= 0 && arr[j] > key)
                {
                    arr[j + 1] = arr[j];
                    j = j - 1;
                }
                arr[j + 1] = key;
            }
        }



        static void printArray(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n; ++i)
                Console.Write(arr[i] + " ");
            Console.WriteLine();
        }

        static void Selectionsort(int[] arr)
        {
            int n = arr.Length - 1;


            for (int i = 0; i < n; i++)
            {

                int min = i;
                for (int j = i + 1; j < n; j++)
                    if (arr[j] < arr[min])
                        min = j;


                int temp = arr[min];
                arr[min] = arr[i];
                arr[i] = temp;
            }
        }
    }
}