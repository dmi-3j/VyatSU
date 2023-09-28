using System;

internal class Program
{
    static int NOD(int x, int y)
    {
        if (y == 0) return x;
        int r = x % y;
        return NOD(y, r);
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Введите первое число: ");
        int x = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите второе число: ");
        int y = int.Parse(Console.ReadLine());
        if (x < 0 || y <0)
        {
            Console.WriteLine("Введите неотрицательные числа ");
            return;
        }
        Console.WriteLine("Наибольший общий делитель: " + NOD(x, y));
    }
}
