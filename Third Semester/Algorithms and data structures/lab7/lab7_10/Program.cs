using System;

internal class Program
{
    static int NOD(int a, int b)
    {
        if (a == b) return a;
        else return (a > b) ? NOD(a - b, b) : NOD(b - a, a);
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Введите первое число: ");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите второе число: ");
        int b = int.Parse(Console.ReadLine());
        if (NOD(a, b) == 1) Console.WriteLine("Взаимно простые");
        else Console.WriteLine("Не взаимно простые");   
    }
}