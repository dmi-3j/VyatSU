using System;
using System.Diagnostics;

internal class Program
{
    static void Main(string[] args)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        int[,] B = new int[6, 6];
        int[] X = new int[36];
        int count = 0;
        Console.WriteLine("Введите число К: ");
        int K = int.Parse(Console.ReadLine());
        Random random = new Random();
        Console.WriteLine("Исходный массив: ");
        for (int i = 0; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                B[i, j] = random.Next(-100, 100);
                if (i > j)
                {
                    if ((B[i, j] <= K) && (B[i, j] > (i + j)))
                    {
                        X[count] = B[i, j];
                        count++;
                    }
                }
                Console.Write($"{B[i, j],-8}");
            }
            Console.Write("\n");
        }
        Array.Resize(ref X, count);
        Console.WriteLine("Полученный массив: ");
        for (int i = 0; i < X.Length; i++)
        {
            Console.Write(X[i] + " ");
        }
        Console.WriteLine();
        sw.Stop();
        Console.WriteLine("Время выполнения: " + sw.Elapsed);
    }
}