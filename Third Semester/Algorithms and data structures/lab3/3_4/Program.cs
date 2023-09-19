using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            int n=1;
            double sum=0, q=1, f = 1;
            Console.WriteLine("Введите значение x: ");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите значение епсилон: ");
            double e = double.Parse(Console.ReadLine());
            while (e <= q)
            {
                for (int i = 1; i <= n; i++)
                {
                    f = f * i;
                }
                q = 3 * n * x * Math.Pow(3, n) / f;
                Console.WriteLine(q);
                sum += q;
                n++;
            }
            Console.WriteLine("Сумма ряда = " + sum);


        }
    }
