using System;
    class Program
    {
        static void Main()
        {
        Console.WriteLine("Введите число а: ");
        int a = int.Parse(Console.ReadLine()); //ввод числа а (по условию)
        Console.WriteLine("Введите число b: ");
        int b = int.Parse(Console.ReadLine()); //ввод числа b (по условию)
        Console.WriteLine("Введите число с: ");
        int c = int.Parse(Console.ReadLine()); //ввод числа c (по условию)
        if ((a < c) && (b < c))
        {
            Console.WriteLine("Оба числа");
        }
        else
        {
            if ((a < c) || (b < c)) Console.WriteLine("Одно число");
            else Console.WriteLine("Нет таких чисел");
        }
        Console.WriteLine("Для выхода из программы нажмите Enter.");
        Console.ReadLine();
    }
    }