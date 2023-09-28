using System;

internal class Program
{
    static int FindMinArray(int[] array, int n)
    {
        if (n == 1) return array[0];
        else
        {
            return (array[n - 1] < FindMinArray(array, n - 1)) ? array[n - 1] : FindMinArray(array, n - 1);
        }
    }
    static void Main(string[] args)
    {
        int[] ints = new int[10];
        Random random = new Random();
        Console.WriteLine("Исходный массив: ");
        for (int i = 0; i < ints.Length; i++)
        {
            ints[i] = random.Next(-100,100);
            Console.Write(ints[i] + " ");
        }
        Console.WriteLine("\n "+ FindMinArray(ints, ints.Length));
    }
}

