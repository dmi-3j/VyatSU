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
    static void Main(string[] args)
    {
 
        int[] a = new int[11] { 2, 5, 7, 8, 9, 13, 17, 19, 22, 27, 31 };
        int[] b = new int[11] { 4, 6, 12, 13, 14, 18, 23, 25, 33, 35, 41 };
        int[] c = new int[a.Length+b.Length];
        Console.WriteLine("Первый массив");
        for (int i = 0; i < a.Length; i++)
        {
            Console.Write(a[i] + " ");
        }
        Console.WriteLine("\nВторой массив");
        for (int i = 0; i < b.Length; i++)
        {
            Console.Write(b[i] + " ");
        }
        Console.WriteLine("\nCоединенный массив ");
        c = Merge(a, b);
        for(int i = 0; i < c.Length; i++)
        {
            Console.Write(c[i] + " ");
        }
        Console.WriteLine("\n");
    }
}
