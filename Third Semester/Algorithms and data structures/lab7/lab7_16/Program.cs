using System;

internal class Program
{
    static int FindMinRecursive(int[] array, int currIndex = 0)
    {
        if (currIndex == array.Length - 1) return currIndex;
        int nextIndex = FindMinRecursive(array, currIndex + 1);

        return (array[currIndex] < array[nextIndex]) ? currIndex : nextIndex;
    }
    static void Main(string[] args)
    {
        Random rnd = new Random();
        int[] arr = new int[10];
        for (int i = 0; i < arr.Length; i++)
        {
            arr[i] = rnd.Next(-100, 100);
            Console.Write(arr[i] + " ");
        }
        Console.WriteLine("\nИндекс минимального элемента: " + FindMinRecursive(arr));
    }
}

