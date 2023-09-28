using System;


internal class Program
{
    static int fibonachi(int n)
    {
        if (n == 1 || n == 2)
        {
            return 1;
        }
        return fibonachi(n - 1) + fibonachi(n - 2);
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Введите номер члена Фибоначчи: ");
        int n = int.Parse(Console.ReadLine());
        if (n >= 1)
        {
            int result = fibonachi(n);
            Console.WriteLine("Результат: " + result);
        }
        else Console.WriteLine("Введите коррекный номер члена");
    }
}
