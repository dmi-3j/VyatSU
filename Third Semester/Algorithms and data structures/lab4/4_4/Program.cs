using System;
using System.Diagnostics;

internal class Program
{
    static void Main(string[] args)
    {
        Stopwatch sw = new Stopwatch();
        sw.Start();
        int[,] B = new int[7, 3];
        int sum = 0, count = 0;
        Random random = new Random();
        Console.WriteLine("Массив: ");
        for (int i = 0; i < B.GetLength(0); i++)
        {
            for (int j = 0; j < B.GetLength(1); j++)
            {
                B[i, j] = random.Next(-100, 100);
                if (B[i, j] == 0) B[i, j] = 1;
                if (B[i, j] > 0) sum += B[i, j];
                else count++;
                Console.Write($"{B[i, j],-8}");
            }
            Console.Write("\n");
        }
        Console.WriteLine("Сумма положительных элементов = " + sum);
        Console.WriteLine("Количество отрицательных элементов: " + count);
        sw.Stop();
        Console.WriteLine("Время выполнения: " + sw.Elapsed);
    }
}

