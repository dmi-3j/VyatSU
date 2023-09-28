using System;

internal class Program
{
    static int ArithmeticProgressionSum(int first, int d, int n)
    {
        if (n == 1) return first;
        else
        {
            return ArithmeticProgressionSum(first + d, d, n-1)+first;
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Введите первый член последовательности: ");
        int first = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите величину шага: ");
        int d = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите номер члена, до которого суммировать: ");
        int n = int.Parse(Console.ReadLine());
        int result = ArithmeticProgressionSum(first, d, n);
        Console.WriteLine("Результат: " + result);
    }
}