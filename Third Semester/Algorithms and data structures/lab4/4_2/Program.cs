using System;
using System.Diagnostics;

internal class Program
{
    static void Main(string[] args)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Random random = new Random();
        int min = int.MaxValue;
        int[] C = new int[15];
        Console.Write("Исходный   массив: ");
        for (int i = 0; i < C.Length; i++)
        {
            C[i] = random.Next(1, 100);
            Console.Write(C[i] + " ");
        }
        for (int i = 0; i < C.Length; i++)
        {
            if ((C[i] < min) && ((i + 1) % 2 != 0))
            {
                min = C[i];
            }
        }
        Console.WriteLine("\nМинимальный нечетный элемент: " + min);
        sw.Stop();
        Console.WriteLine("Время выполнения: "+ sw.Elapsed);
    }
}
