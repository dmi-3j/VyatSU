using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            const double b = 6;
            double a = 1;
            while (a < b )
            {
                double Y = Math.Sqrt(a * Math.Pow(a - 3, 4));
                Console.WriteLine("Y = " + Y);
                a += 0.25;
            }
        }
    }