using System;

internal class Program
{
    static int ArithmeticProgression(int first, int d, int n)
    {
        if (n == 1) return first;
        else
        {
            return ArithmeticProgression(first, d, n - 1) + d;
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Введите первый член последовательности: ");
        int first  = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите величину шага: ");
        int d = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите номер члена, который необходимо вычислить: ");
        int n = int.Parse(Console.ReadLine());
        int result = ArithmeticProgression(first,d, n);
        Console.WriteLine("Результат: " + result);
    }
}

