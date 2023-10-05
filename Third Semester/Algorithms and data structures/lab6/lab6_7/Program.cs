using System;

internal class Program
{
    private static void swap(ref int x, ref int y)
    {
        int temp = x; x = y; y = temp;
    }
    static void InsertSort(int[] a) { 
        
        for (int i = 1; i < a.Length; i++)
        {
            int j = i-1;
            while (j >= 0 && a[j+1] < a[j])
            {
                swap( ref a[j+1], ref a[j]);
                j--;
            }
        }
    }
    static void Main(string[] args)
    {
        Random random = new Random();
        int[] array = new int[10];
        Console.WriteLine("Исходный массив:");
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(1, 100);
            Console.Write(array[i] + " ");
        }
        int sr = 0, obm = 0;
        Console.WriteLine("\nОтосортированный массив:");

        InsertSort(array);
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine("\n");
    }
}

