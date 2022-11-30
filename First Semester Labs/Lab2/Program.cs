using System;
    class Program
    {
        static void Main()                              //Вариант 24
        {
        Console.WriteLine("Введите сторону квадрата: ");
        double a = double.Parse(Console.ReadLine());   //ввод переменной а - сторона квадрата (из условия)
        Console.WriteLine("Введите радиус окружностей: "); 
        double r = double.Parse(Console.ReadLine());   //ввод переменной r - радиус окружности (из условия)
        double square = (Math.PI * Math.Pow(r, 2) / 8) + ((Math.Pow(a, 2) - ((Math.PI * Math.Pow(r, 2)) / 4)) / 2); //вычисление площади фигуры, если упростить, получается square = Math.Pow(a, 2)/2
        double perimeter = 2 * a + (Math.Sqrt(2 * Math.Pow(a, 2)));   //вычисление периметра фигуры
        Console.WriteLine("Площадь фигуры: " + square);               //вывод результата вычисления площади фигуры
        Console.WriteLine("Периметр: " + perimeter);                  //вывод результата вычисления периметра фигуры
        Console.WriteLine("Для завершения программы нажмите Enter.");
        Console.ReadLine();
        
        }
    }