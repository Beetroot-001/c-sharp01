using System;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            int[] ints = new int[10];
            ArrayRandom(ints);
            bool num = true;
            int numKey2 = 0;
            do
            {
                try
                {
                    Console.WriteLine("Choose a sorting method");
                    Console.WriteLine("Press key 1 if you want to use it bubbleSort\nPress key 2 if you want to use it Insertionsort\nPress key 3 if you want to use it Selectionsort\n");
                    Console.WriteLine();
                    num = int.TryParse(Console.ReadLine(), out numKey2);
                    if(numKey2 > 4||numKey2 < 1)
                    {
                        num = false;
                    }
                    
                }
                catch (Exception)
                {
                    Console.WriteLine("Exception");
                    num = false;
                }

            } while (num == false);
            
           
            if(numKey2 == 1)
            {
                Console.WriteLine("You chose bubbleSort");
                int numKey3 = 0;
                bool num2 = true;
                do
                {
                    try
                    {
                        Console.WriteLine("How do you want to sort? \nIf from smaller to larger press 1.\nIf from larger to smaller press 2.\n");
                        num2 = int.TryParse(Console.ReadLine(), out numKey3);
                        if (numKey3 > 2 || numKey3 < 1)
                        {
                            num2 = false;
                        }

                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Exception");
                        num2 = false;
                    }

                } while (num2 == false);
               if(numKey3 == (int)Sort.bubbleSortSmaler)
                {
                    printArray(ints);
                    bubbleSortSmaller(ints);
                    printArray(ints);
                }else if(numKey3 == (int)Sort.bubbleSortLarger)
                {
                    printArray(ints);
                    bubbleSortLarger(ints);
                    printArray(ints);
                }
            }
            else if(numKey2 == 2)
            {
                Console.WriteLine("You chose Insertionsort");
            }
            else if(numKey2 == 3)
            {
                Console.WriteLine("You chose Selectionsort");
            }
           


        }
        enum Sort
        {
            bubbleSortSmaler = 1,
            bubbleSortLarger, 
            Insertionsortmin,
            Insertionsortmax,
            Selectionsortmin,
            Selectionsortmax,
        }
        static void ArrayRandom(int[] arr)
        {
            Random random = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = random.Next(20);
            }
        }

        static void bubbleSortSmaller(int[] arr)
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
        static void bubbleSortLarger(int[] arr)
        {
            int n = arr.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    if (arr[j] < arr[j + 1])
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
            int n = arr.Length ;


            for (int i = 0; i < n - 1; i++)
            {

                int min = i;
                for (int j = i + 1; j < n; j++)
                {

                    if (arr[j] < arr[min])
                    {
                        min = j;
                    }
                }
                       
                int temp = arr[min];
                arr[min] = arr[i];
                arr[i] = temp;
            }
        }
    }
}