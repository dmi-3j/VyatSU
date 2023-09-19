using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

internal class Program
{
    static void Main(string[] args)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        Random random = new Random();
        int[,] A = new int[6, 6];
        int sum = 0, sq = 1;
        Console.WriteLine("Матрица: ");
        for (int i = 0; i < A.GetLength(0); i++)
        {
            for (int j = 0; j < A.GetLength(1); j++)
            {
                A[i, j] = random.Next(-100, 100);
                Console.Write($"{A[i, j],-8}");
            }
            Console.Write("\n");
        }
        for (int i = 0; i < A.GetLength(0); i++)
        {
            for (int j = 0; j < A.GetLength(1); j++)
            {
                if ((i == j) && (A[i, j] > 0))
                {
                    sq *= A[i, j];
                }
                if (j == ((A.GetLength(0) - 1) - i))
                {
                    Console.Write(A[i,j] + " " );
                    sum += A[i, j];
                }
            }
        }
        Console.WriteLine("\nПроизведение положительных элементов главной диагонали = " + sq);
        Console.WriteLine("Сумма элементов побочной диагонали = " + sum);
        sw.Stop();
        Console.WriteLine("Время выполнения: " + sw.Elapsed);
    }
}

