using System;
using System.Diagnostics;

namespace Lab2_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            //Random rnd = new Random();
            //double a = rnd.NextDouble();
            //double b = rnd.NextDouble();
            //double c = rnd.NextDouble();
            //double d = rnd.NextDouble();
            Console.WriteLine("Введите первое число");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите второе число");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите третье число");
            double c = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите четвертое число");
            double d = double.Parse(Console.ReadLine());
            double sum_pos = 0, sum_neg = 0;
            if (a > 0)
            {
                sum_pos += a;
            }
            else
            {
                sum_neg += a;
            }
            if (b > 0)
            {
                sum_pos += b;
            }
            else
            {
                sum_neg += b;
            }
            if (c > 0)
            {
               sum_pos += c;
            }
            else
            {
                sum_neg += c;
            }
            if (d > 0)
            {
                sum_pos += d;
            }
            else
            {
                sum_neg += d;
            }
            Console.WriteLine("Сумма положительных = " + sum_pos);
            Console.WriteLine("Сумма отрицательных = " + sum_neg);
            sw.Stop();
            Console.WriteLine("Время выполнения: " + sw.Elapsed);
            Console.ReadKey();
        }
    }
}
