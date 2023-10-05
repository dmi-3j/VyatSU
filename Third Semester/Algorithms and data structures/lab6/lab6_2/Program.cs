using System;

internal class Program
{
    static int[] MySort(int[] array)
    {
        int length = array.Length;
        int[] result = new int[array.Length];
        for(int i = 0; i < length; i++)
        {
            int minIndex = FindMinIndex(array);
            result[i] = array[minIndex];
            array = Remove(array, minIndex);
        }
        return result;
    }
    static int FindMinIndex(int[] array) 
    {
        int minIndex = 0;
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i] < array[minIndex]) minIndex = i;
        }
        return minIndex;
    }
    static int[] Remove(int[] array, int index) 
    {
        int[] newArray = new int[array.Length - 1];
        for (int i = 0, j = 0; i < array.Length; i++)
        {
            if (i != index)
            {
                newArray[j] = array[i];
                j++;
            }
        }
        return newArray;
    }
    static void Main(string[] args)
    {
        Random random = new Random();
        int[] array = new int[12];
        Console.WriteLine("Исходный массив:");
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(-111, 100);
            Console.Write(array[i] + " ");
        }
        Console.WriteLine("\nОтосортированный массив:");
        array = MySort(array);
        for (int i = 0; i < array.Length; i++) Console.Write(array[i] + " ");
        Console.WriteLine("\n");
    }
}