using System;

internal class Program
{
    private static void swap(ref int x, ref int y)
    {
        int temp = x; x = y; y = temp;
    }
    static void BubbleSort(int[] array, ref int sr, ref int obm)
    {
        for (int i = 0; i < array.Length; i++)
        {
            for (int j = 0; j < array.Length - i - 1; j++)
            {
                sr++;
                if (array[j] > array[j + 1])
                {
                    swap(ref array[j], ref array[j + 1]);
                    obm++;
                }
            }
        }
    }
    static void InsertSort(int[] a, ref int sr, ref int obm)
    {
        for (int i = 1; i < a.Length; i++)
        {
            int cur = a[i];
            int j = i;
            while (j > 0 && cur < a[j - 1])
            {
                sr++;
                a[j] = a[j - 1];
                j--;
            }
            a[j] = cur;
        }
        sr++;
    }
    static void SelectSort(int[] a, ref int sr, ref int obm)
    {
        int max;
        int length = a.Length;
        for (int i = 0; i < length - 1; i++)
        {
            max = i;
            for (int j = i + 1; j < length; j++)
            {
                sr++;
                if (a[j] < a[max]) max = j;
            }
            sr++;
            if (max != i)
            {
                swap(ref a[i], ref a[max]);
                obm++;
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
        //BubbleSort(array, ref sr, ref obm);
        InsertSort(array, ref sr, ref obm);
        //SelectSort(array, ref sr, ref obm);
        for (int i = 0; i < array.Length; i++) Console.Write(array[i] + " ");
        Console.WriteLine("\nКоличество сравниений: " + sr + " \nКоличество обменов: " + obm);
    }
}