using System;
using System.Threading;

internal class Program
{
    static void Hoare(int[] arr, int left, int right)
    {
        if (left >= right) return;
        int pivotIndex = Partition(arr, left, right);
        Hoare(arr, left, pivotIndex - 1);
        Hoare(arr, pivotIndex, right);
    }

    static int Partition(int[] arr, int left, int right)
    {
        int pivot = arr[(left + right) / 2];
        while (left <= right)
        {
            while (arr[left] < pivot) left++;
            while (arr[right] > pivot) right--;
            if (left <= right)
            {
                Swap(ref arr[left], ref arr[right]);
                left++;
                right--;
            }
        }
        return left;
    }

    static void Swap(ref int i, ref int j)
    {
        (i, j) = (j, i);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("Исходный массив:");
        int[] arr = {31, 9, 21, 34,7 };
        Random rand = new Random();
        for (int i = 0; i < arr.Length; i++)
        {
           // arr[i] = rand.Next(1, 50);
            Console.Write(arr[i] + " ");
        }
        Hoare(arr, 0, arr.Length-1);
        Console.WriteLine("\nОтсортированный массив");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine("\n");

    }
}

