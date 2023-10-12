using System;

internal class Program
{
    static int[] Merge(int[] a, int[] b)
    {
        int[] buffArray = new int[a.Length + b.Length];
        int cnt0 = 0; //для buffArray
        int cnt1 = 0; //для a
        int cnt2 = 0; //для b
        for (; cnt0 < buffArray.Length; cnt0++)
        {
            if (cnt2 >= b.Length)
            {
                buffArray[cnt0] = a[cnt1];
                cnt1++;
            }
            else if (cnt1 < a.Length && a[cnt1] < b[cnt2])
            {
                buffArray[cnt0] = a[cnt1];
                cnt1++;
            }
            else
            {
                buffArray[cnt0] = b[cnt2];
                cnt2++;
            }
        }
        return buffArray;

    }
    static int[] MergeSort(int[] array)
    {
        if (array.Length == 1) return array;
        int sredElement = array.Length / 2;
        int[] l = new int[sredElement];
        int[] r = new int[array.Length - sredElement];
        for (int i = 0; i < array.Length; i++)
        {
            if (i < sredElement) l[i] = array[i];
            else r[i - sredElement] = array[i];
        }
        return Merge(MergeSort(l), MergeSort(r));
    }
    static void Main(string[] args) 
    {
        int[] a = new int[23];
        Random random = new Random();
        Console.WriteLine("Исходный массив:");
        for (int i = 0;i < a.Length;i++)
        {
            a[i] = random.Next(-23, 43);
            Console.Write(a[i] + " ");
        }
        Console.WriteLine("\nОтсортированный массив:");
        int[] b = new int[23];
        b = MergeSort(a);
        for (int i = 0; i < b.Length; i++)
        {
            Console.Write(b[i] + " ");
        }
        Console.WriteLine("\n");
    }
}

