using System;

internal class Program
{
    static int NOD(int a, int b)
    {
        if (a == b) return a;
        else return (a > b) ? NOD(a - b, b) : NOD(b - a, a);
    }
    static int NOK(int a, int b)
    {
        return (a * b) / NOD(a, b);
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Введите первое число: ");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите второе число: ");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine("Наименьшее общее кратное: " + NOK(a, b));
    }
}

