using System.Collections.Generic;
using System.Net.Http.Headers;

namespace ConsoleApp1
{
    internal class Program
    {
        enum SortAlgorithmType
        {
            SELECTION,
            BUBBLE,
            INSERTION
        }

        enum OrderBy
        {
            ASC,
            DESC
        }

        static void swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void Main(string[] args)
        {
            int[] ints = { 1, 1, 1, 2, 1, 3, 4, 3, 5, 6, 7, 8 };

            Console.WriteLine("Start mas: ");
            for (int i = 0; i < ints.Length; i++)
            {
                Console.Write(ints[i]);
            }
            Console.WriteLine();

            Console.WriteLine("selection/asc");
            sort(ints, OrderBy.ASC, SortAlgorithmType.SELECTION);
            for (int i = 0; i < ints.Length; i++)
            {
                Console.Write(ints[i]);
            }
            Console.WriteLine();

            Console.WriteLine("selection/desc");
            sort(ints, OrderBy.DESC, SortAlgorithmType.SELECTION);
            for (int i = 0; i < ints.Length; i++)
            {
                Console.Write(ints[i]);
            }
            Console.WriteLine();

            Console.WriteLine("Bubble/asc");
            sort(ints, OrderBy.ASC, SortAlgorithmType.BUBBLE);
            for (int i = 0; i < ints.Length; i++)
            {
                Console.Write(ints[i]);
            }
            Console.WriteLine();

            Console.WriteLine("Bubble/desc");
            sort(ints, OrderBy.DESC, SortAlgorithmType.BUBBLE);
            for (int i = 0; i < ints.Length; i++)
            {
                Console.Write(ints[i]);
            }
            Console.WriteLine();

            Console.WriteLine("Insetion/asc");
            sort(ints, OrderBy.ASC, SortAlgorithmType.INSERTION);
            for (int i = 0; i < ints.Length; i++)
            {
                Console.Write(ints[i]);
            }
            Console.WriteLine();

            Console.WriteLine("selection/desc");
            sort(ints, OrderBy.DESC, SortAlgorithmType.INSERTION);
            for (int i = 0; i < ints.Length; i++)
            {
                Console.Write(ints[i]);
            }
            Console.WriteLine();

            Console.WriteLine("\n--==SUPER EXTRA==--");

            int[] ints2 = { 1, 1, 1, 2, 1, 3, 4, 3, 5, 6, 7, 8, 8 };
            //first solution
            var temp = ints2.GroupBy(x => x).Where(x => x.Count() == 1);
            int a = temp.Count() == 0 ? 47 : temp.Last().Key;

            //second solution
            int b = 47;
            int[,] arr_res = new int[ints2.Length, 2]; //int[num, amount in ints2]
            int arr_res_count = 0; //number of unique nums in ints2

            for (int i = 0; i < ints2.Length; i++)
            {
                bool flag = true;

                for (int j = 0; j < arr_res_count; j++)
                {
                    if (arr_res[j, 0] == ints2[i])
                    {
                        arr_res[j, 1]++;
                        flag = false;
                        break;
                    }
                }

                if (flag)
                {
                    arr_res[arr_res_count, 0] = ints2[i];
                    arr_res[arr_res_count, 1] = 1;
                    arr_res_count++;
                }
            }

            for (int i = arr_res_count - 1; i >= 0; i--)
            {
                if (arr_res[i, 1] == 1)
                {
                    b = arr_res[i, 0];
                    break;
                }
            }

            Console.WriteLine($"a: {a}, b: {b}");
        }

        static void sort(int[] arr, OrderBy order = 0, SortAlgorithmType type = SortAlgorithmType.BUBBLE)
        {
            switch (type)
            {
                case SortAlgorithmType.SELECTION:
                    Selection(arr, order);
                    break;
                case SortAlgorithmType.BUBBLE:
                    Bubble(arr, order);
                    break;
                case SortAlgorithmType.INSERTION:
                    Insertion(arr, order);
                    break;
            }
        }

        static void Selection(int[] arr, OrderBy order = 0)
        {
            Func<int, int, bool> func = (a, b) => order == OrderBy.ASC ? a < b : a > b;

            for (int i = 0; i < arr.Length - 1; i++)
            {
                int elem_index = i;

                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (func(arr[j], arr[elem_index]))
                    {
                        elem_index = j;
                    }
                }

                swap(ref arr[i], ref arr[elem_index]);
            }
        }

        static void Bubble(int[] arr, OrderBy order = 0)
        {
            Func<int, int, bool> func = (a, b) => order == OrderBy.ASC ? a > b : a < b;

            for (int i = 0; i < arr.Length; i++)
            {
                for (int j = 0; j < arr.Length - 1 - i; j++)
                {
                    if (func(arr[j], arr[j + 1]))
                    {
                        swap(ref arr[j], ref arr[j + 1]);
                    }
                }
            }
        }

        static void Insertion(int[] arr, OrderBy order = 0)
        {
            Func<int, int, bool> func = (a, b) => order == OrderBy.ASC ? a > b : a < b;

            for (int i = 1; i < arr.Length; i++)
            {
                int j = i;
                while (j > 0 && func(arr[j - 1], arr[j]))
                {
                    swap(ref arr[j], ref arr[j - 1]);
                    j--;
                }
            }
        }
    }
}