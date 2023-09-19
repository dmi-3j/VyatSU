using System;
using System.Diagnostics;

internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Random random = new Random();

            int[] N = new int[20];
            int[] Y = new int[20];
            Console.Write("Исходный   массив: ");
            for (int i = 0; i < N.Length; i++)
            {
                N[i] = random.Next(1, 100);
                Console.Write(N[i] + " "); 
                Y[i] = N[i] * N[i];
            }
            Console.Write("\nПолученный массив: ");
            for (int i = 0;i < Y.Length; i++) 
            {
                Console.Write(Y[i] + " ");
            }
            Console.WriteLine("\n");
            sw.Stop();
            Console.WriteLine("Время выполнения: " + sw.Elapsed);
    }
    }