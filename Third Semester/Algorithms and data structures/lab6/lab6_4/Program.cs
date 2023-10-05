using System;

internal class Program
{
    private static void swap(ref int x, ref int y)
    {
        int temp = x; x = y; y = temp;
    }
    static void BubbleSort(int[] arr)
    {
        bool isSwap;
        do
        {
            isSwap = false;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i - 1] > arr[i])
                {
                    // Обмен элементов местами
                    swap(ref arr[i], ref arr[i - 1]);
                    isSwap = true;
                }
            }
        } 
        while (isSwap);
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Исходный массив: ");
        Random random = new Random();
        int[] a = new int[10];
        for(int i = 0; i < a.Length; i++)
        {
            a[i] = random.Next(-22, 32);
            Console.Write(a[i] + " ");
        }
        Console.WriteLine("\nОтстортированный массив: ");
        BubbleSort(a);
        for (int i = 0; i < a.Length; i++) Console.Write(a[i] + " ");
        Console.WriteLine("\n");
    }
}

