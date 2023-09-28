using System;

internal class Program
{
    static int factorial(int n)
    {
        return (n == 1 || n == 0) ? 1 : (n * factorial(n - 1));
    }
    static void Main(string[] args)
    {
        int result = factorial(10) / (factorial(6) * factorial(4));
        Console.WriteLine(result + " способов");
    }
}