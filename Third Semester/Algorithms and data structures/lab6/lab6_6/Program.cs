using System;

internal class Program
{
    private static void swap(ref int x, ref int y)
    {
        int temp = x; x = y; y = temp;
    }
    static void Sort(int[] arr)
    {
        bool isSwap;
        do
        {
            isSwap = false;
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    swap(ref arr[i], ref arr[i + 1]);
                    isSwap = true;
                }
            }

            if (!isSwap) break;
            isSwap = false;

            for (int i = arr.Length - 1; i > 0; i--)
            {
                if (arr[i - 1] > arr[i])
                {
                    swap(ref arr[i], ref arr[i - 1]);
                    isSwap = true;
                }
            }
        }
        while (isSwap);
    }
    static void Main(string[] args)
    {
        Random random = new Random();
        int[] a = new int[14];
        Console.WriteLine("Исходный массив:");
        for (int i = 0; i < a.Length; i++)
        {
            a[i] = random.Next(-12, 23);
            Console.Write(a[i] + " ");
        }
        Console.WriteLine("\nОтсортированный массив:");
        Sort(a);
        for (int i = 0; i < a.Length; i++)
        {
            Console.Write(a[i] + " ");
        }
        Console.WriteLine("\n");
    }
}

