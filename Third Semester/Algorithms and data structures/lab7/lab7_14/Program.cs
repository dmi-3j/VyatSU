using System;

internal class Program
{
    static double FindNthElement(double b1, double q, int n)
    {
        if (n == 1) return b1;
        else return FindNthElement(b1, q, n - 1) * q;
    }
    static double SumOfNElements(double b1, double q, int n)
    {
        if (n == 0) return 0;
        else return SumOfNElements(b1,q, n-1) + FindNthElement(b1,q, n);
    }
    static double SumInRange(double b1, double q, int i, int k)
    {
        if (i > k) return 0;
        else return FindNthElement(b1, q, i) + SumInRange(b1, q, i + 1, k);
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Введите первый член последовательности: ");
        double b1 = double.Parse(Console.ReadLine());
        Console.WriteLine("Веедите знаменатель прогрессии (число q): ");
        double q = double.Parse(Console.ReadLine());
        Console.WriteLine("Введите номер члена для вычисления: ");
        int n = int.Parse(Console.ReadLine());
        Console.WriteLine(n + " член последовательности равен: " + FindNthElement(b1, q, n));
        Console.WriteLine("Сумма " +n + " первых членов последовательности = " + SumOfNElements(b1, q,n));
        Console.WriteLine("Введите левую границу диапазона:");
        int i = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите правую границу диапазона:");
        int k = int.Parse(Console.ReadLine());
        Console.WriteLine("Сумма с " + i + " по " + k +" член прогрессии =  " + SumInRange(b1,q,i,k));
    }
}

