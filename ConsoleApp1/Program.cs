
namespace ConsoleApp1
{
    enum SortAlgorithmType : short
    {
        Selection
        , Bubble
        , Insertion
    }
    enum OrderBy : short
    {
        Asc
        , Desc
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int[] array = new[] { 3, 5, 2, 4, 6, 1 };
            Console.WriteLine("in array");
            PrintArray(array);

            Sort(array, OrderBy.Asc, SortAlgorithmType.Selection);
            Sort(array, OrderBy.Desc, SortAlgorithmType.Selection);

            Sort(array, OrderBy.Asc, SortAlgorithmType.Bubble);
            Sort(array, OrderBy.Desc, SortAlgorithmType.Bubble);

            Sort(array, OrderBy.Asc, SortAlgorithmType.Insertion);
            Sort(array, OrderBy.Desc, SortAlgorithmType.Insertion);

            Console.WriteLine("FindLastUnique");
            double[] array2 = { 1, 2, 3, 4, 4 };
            Console.WriteLine(FindLastUnique(array2));
            array2 = new double[] { 1,1,1,1,1,1,1,1 };
            Console.WriteLine(FindLastUnique(array2));
            array2 = new double[] { 23, 0.47, 23 };
            Console.WriteLine(FindLastUnique(array2));
        }

        static void PrintArray(int[] array)
        {
            Console.WriteLine("unsorted");
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(Environment.NewLine);
        }
        static void PrintArray(int[] array, OrderBy orderBy, SortAlgorithmType sortAlgorithm)
        {
            Console.WriteLine(string.Format("{0} {1}", orderBy, sortAlgorithm));
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine(Environment.NewLine);
        }

        static void Sort(int[] array, OrderBy order, SortAlgorithmType algorithmType)
        {
            switch (algorithmType)
            {
                case SortAlgorithmType.Selection:
                    {
                        Selection(array, order);
                    }
                    break;
                case SortAlgorithmType.Bubble:
                    {
                        Bubble(array, order);
                    }
                    break;
                case SortAlgorithmType.Insertion:
                    {
                        Insertion(array, order);
                    }
                    break;
            }
            PrintArray(array, order, algorithmType);
        }

        static void Selection(int[] array, OrderBy order)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                int minId = i;
                for (int j = i + 1; j < array.Length; j++)
                {
                    if (order is OrderBy.Asc ? array[j] < array[minId] : array[j] > array[minId])
                    {
                        minId = j;
                    }
                }
                int temp = array[minId];
                array[minId] = array[i];
                array[i] = temp;
            }
        }

        static void Bubble(int[] array, OrderBy order)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - i - 1; j++)
                {
                    if (order is OrderBy.Asc ? array[j] > array[j + 1] : array[j] < array[j + 1])
                    {
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
        }

        static void Insertion(int[] array, OrderBy order)
        {
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = i + 1; j > 0; j--)
                {
                    if (order is OrderBy.Asc ? array[j - 1] > array[j] : array[j - 1] < array[j])
                    {
                        int temp = array[j - 1];
                        array[j - 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        static double FindLastUnique(double[] array)
        {
            double result = 47;
            if (array.Length == 0 )
            {
                return result;
            }

            if (array.Length == 1)
            {
                return array[0];
            }
                        
            for (int i = 0; i < array.Length; i++)
            {               
                double t = array[i];
                int count = 0;
                for (int j = 0; j < array.Length; j++)
                {
                    if(t == array[j]) count++;
                }
                if (count == 1)
                {
                    result = array[i];
                }
            }

            return result;
        }

    }
}