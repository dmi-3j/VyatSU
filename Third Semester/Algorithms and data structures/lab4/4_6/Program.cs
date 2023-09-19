using System;
using System.Diagnostics;

internal class Program
{
    static void Main(string[] args)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Random random = new Random();
        int[] X = new int[14];
        int[,] M = new int[5, 5];
        int[] C = new int[X.Length + M.Length];
        int count = 0;
        Console.WriteLine("Исходный массив 1: ");
        for (int i = 0; i < X.Length; i++)
        {
            X[i] = random.Next(-100, 100);
            if (X[i] > 0)
            {
                C[count] = X[i];
                count++;
            }
            Console.Write(X[i] + " ");
        }
        Console.WriteLine("\nИсходный массив 2: ");
        for (int i = 0; i < M.GetLength(0); i++)
        {
            for (int j = 0; j < M.GetLength(1); j++)
            {
                M[i, j] = random.Next(-100, 100);
                if (M[i, j] > 0)
                {
                    C[count] = M[i, j];
                    count++;
                }
                Console.Write($"{M[i, j],-8}");
            }
            Console.Write("\n");
        }
        Array.Resize(ref C, count);
        Console.WriteLine("Исходный сформированный массив: ");
        for (int i = 0; i < C.Length; i++)
        {
            Console.Write(C[i] + " ");
        }
        Console.WriteLine("\nОтсортированный сформированный массив: ");
        for (int i = 1; i < C.Length; i++)
        {
            for (int j = 0; j < C.Length - 1; j++)
            {
                if (C[j] > C[j + 1])
                {
                    int tmp = C[j];
                    C[j] = C[j + 1];
                    C[j + 1] = tmp;
                }
            }
        }
        for (int i = 0; i < C.Length; i++)
        {
            Console.Write(C[i] + " ");
        }
        Console.WriteLine();
        sw.Stop();
        Console.WriteLine("Время выполнения: " + sw.Elapsed);
    }
}
