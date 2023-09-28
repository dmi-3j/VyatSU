using System;

internal class Program
{
    static long Pow(int num, int pow)
    { 
        return (pow == 0) ? 1 : num*(Pow(num, --pow)); 
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Введите первое число: ");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите второе число: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine("Результат " + Pow(a, n));
    }
}

