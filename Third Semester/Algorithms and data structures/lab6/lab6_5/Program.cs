using System;

internal class Program
{

    private static void swap(ref int x, ref int y)
    {
        int temp = x; x = y; y = temp;
    }
    static void Sort(int[] arr)
    {
        int leftIndex = 0, rightIndex = arr.Length-1;
      
        while (leftIndex <= rightIndex)
        {
            for (int i = leftIndex; i < rightIndex; i++)
            {
                if (arr[i] > arr[i + 1])
                {
                    swap(ref arr[i], ref arr[i + 1]);
                }
            }
            rightIndex--;

            for (int i = rightIndex; i > leftIndex; i--)
            {
                if (arr[i - 1] > arr[i])
                {
                    swap(ref arr[i], ref arr[i - 1]);
                }
            }
            leftIndex++;
        }
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
