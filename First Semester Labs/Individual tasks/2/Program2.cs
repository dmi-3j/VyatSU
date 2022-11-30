using System;
class Program
    {
        static void Main()
        {
        Console.WriteLine("Введите число а: ");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите число b: ");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите число с: ");
        int c = int.Parse(Console.ReadLine());
        int count = 0;
        if (a < c) count++;
        if (b < c) count++;
        Console.WriteLine("Количество таких чисел: " + count);
        Console.WriteLine("Для выхода из прораммы нажмите Enter.");
        Console.ReadLine();
        }
    }