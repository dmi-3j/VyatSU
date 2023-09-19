using System;
using System.Diagnostics;

class Program
    {
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            const int a = 2;
            const double b = 0.5;
            
            //Console.WriteLine("Введите x:");
            Random rnd = new Random();
        double x = rnd.NextDouble();
           //double x = Convert.ToDouble(Console.ReadLine());
      
            double Y = (x + a) * (Math.Atan(x) - Math.Sqrt(Math.Abs(Math.Pow((x - a), 3))) + Math.Log(Math.Pow(x, 3) + 1));

            Console.WriteLine("Y=" + Y + "\n");

            double F = Math.Sin(x) - Math.Pow(Math.E, (-a * x)) + Math.Log(Math.Abs(x + a) + 2);
            Console.WriteLine("F=" + F);
            sw.Stop();
            Console.WriteLine("Время выполнения: " + sw.Elapsed);
            Console.ReadKey();
        }
    }