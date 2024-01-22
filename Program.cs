using System.Diagnostics;

namespace selectionSort;

class Program
{
    private static int[] CreateArray(int length)
    {
        var random = new Random();
        var array = new int[length];
        var exists = new bool[length];

        for (int i = 0; i < length;)
        {
            var newInt = random.Next(length);
            if (exists[newInt] == false)
            {
                exists[newInt] = true;
                array[i++] = newInt + 1;
            }
        }

        return array;
    }

    private static void Main(string[] args)
    {
        var stopwatch = new Stopwatch();
        int[] arr = CreateArray(10);
        Console.WriteLine($"Unsorted Array: [ {string.Join(", ", arr)} ]");

        stopwatch.Start();
        Table.SelectionSortHelper(arr);
        stopwatch.Stop();

        Table.Rotate(arr);

        Console.WriteLine($"\nSorted Array: [ {string.Join(", ", arr)} ]");
        Console.WriteLine($"\nTime elapsed to sort: {stopwatch.Elapsed}");
    }
}


class Table
{
    public static int Min(int[] arr, int from, int to)
    {
        int minIndex = from;
        int minVal = arr[from];

        for (int i = from + 1; i < to; i++)
        {
            if (arr[i] < minVal)
            {
                minIndex = i;
                minVal = arr[minIndex];
            }
        }

        return minIndex;
    }

    public static int Min(int[] arr)
    {
        return Min(arr, 0, arr.Length);
    }


    public static int Max(int[] arr, int from, int to)
    {
        int maxIndex = from;
        int maxVal = arr[from];

        for (int i = from + 1; i < to; i++)
        {
            if (arr[i] > maxVal)
            {
                maxIndex = i;
                maxVal = arr[maxIndex];
            }
        }

        return maxIndex;
    }

    public static int Max(int[] arr)
    {
        return Max(arr, 0, arr.Length);
    }


    public static void Swap(int[] arr, int index1, int index2)
    {
        (arr[index1], arr[index2]) = (arr[index2], arr[index1]);
    }


    public static void Rotate(int[] arr)
    {
        int n = arr.Length - 1;

        for (int i = 0; i < arr.Length / 2; i++)
        {
            (arr[i], arr[n - i]) = (arr[n - i], arr[i]);
        }
    }


    public static void SelectionSort(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            int minIndex = i;
            int minVal = arr[i];

            for (int j = i + 1; j < arr.Length; j++)
            {
                if (arr[j] < minVal)
                {
                    minIndex = j;
                    minVal = arr[minIndex];
                }
            }

            (arr[i], arr[minIndex]) = (arr[minIndex], arr[i]);
        }
    }

    public static void SelectionSortHelper(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            Swap(arr, i, Min(arr, i, arr.Length));
        }
    }

    public static void SelectionSortHelperMax(int[] arr)
    {
        for (int i = 0; i < arr.Length - 1; i++)
        {
            Swap(arr, i, Max(arr, i, arr.Length));
        }
    }

}