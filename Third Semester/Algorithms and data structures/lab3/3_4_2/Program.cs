using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            int n = 1;
            double sum = 0, q, f = 1;
            Console.WriteLine("Введите значение x: ");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите максимальное значение: ");
            double V = double.Parse(Console.ReadLine());
            do
            {
                for (int i = 1; i <= n; i++)
                {
                    f = f * i;
                }
                q = 3 * n * x * Math.Pow(3, n) / f;
                sum += q;
                n++;
            }
            while (sum < V);
            Console.WriteLine("Номер члена, после которого сумма больше " + V + " = " + (n-1));
        }
    }

