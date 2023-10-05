using System;

internal class Program
{
    private static void swap(ref int x, ref int y)
    {
        int temp = x; x = y; y = temp;
    }
    static void SelectSortOnlyNegative(int[] a)
    {
        int length = a.Length;
        for (int i = 0; i < length - 1; i++)
        {
            if (a[i] >= 0) continue; // Пропускаем положительные элементы
            int minNegative = i;
            for (int j = i + 1; j < length; j++)
            {
                if (a[j] < 0 && a[j] < a[minNegative]) minNegative = j;
            }
            if (minNegative != i) swap(ref a[i], ref a[minNegative]);
        }
    }
    static void Main(string[] args)
    {
        Random random = new Random();
        int[] array = new int[10];
        Console.WriteLine("Исходный иассив:");
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(-100, 100);
            Console.Write(array[i] + " ");
        }
        Console.WriteLine("\nОтсортированный массив:");
        SelectSortOnlyNegative(array);
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine("\n");
    }
}