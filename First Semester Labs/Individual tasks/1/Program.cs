using System;
     class Program
    {
        static void Main()                              //вариант 24
        {
        Console.WriteLine("Введите переменную а: ");
        double a = double.Parse(Console.ReadLine());    //ввод переменной а по условию
        Console.WriteLine("Введите переменную b: ");
        double b = double.Parse(Console.ReadLine());    //ввод переменной b по условию
        Console.WriteLine("Введите переменную c: ");
        double c = double.Parse(Console.ReadLine());    //ввод переменной с по условию
        double y = (Math.Pow(Math.E, c) + Math.Abs(Math.Pow(b, 2) - a)) / (a * Math.Pow(Math.Log(b + c), 2));  //вычисление результата
        Console.WriteLine("Результат: " + y);           //вывод результатата
        Console.WriteLine("Для выхода из программы нажмите Enter.");
        Console.ReadLine();
        }
    }