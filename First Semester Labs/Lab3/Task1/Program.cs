using System;
    class Program
    {
        static void Main()
        {
        Console.WriteLine("Введите значение переменной х: ");
        double y;
        double x = double.Parse(Console.ReadLine());  //ввод переменной х (из условия)
        if (x < 0)                                    //проверка первого условия  (ветвь 1)
        {
            Console.WriteLine("x < 0. Используется формула y = (sin(x) + (-x)^(1/2)) / (e^x)"); 
            y = (Math.Sin(x) + Math.Sqrt(-x)) / Math.Pow(Math.E, x);  //вычисление результата
        }
        else
        {
            if (x > 0) //проверка второго условия (ветвь 2)
            {
                Console.WriteLine("x > 0. Используется формула y = (x^2 + x^(3/2)) / (e^(x^2) + sin(x))");
                y = (Math.Pow(x, 2) + Math.Sqrt(Math.Pow(x, 3))) / ((Math.Pow(Math.E, Math.Pow(x, 2))) + Math.Sin(x)); //вычисление результата
            }
            else
            {
                Console.WriteLine("x = 0. Используется формула y = (2 * PI * cos(x))^(1/3)"); //ветвь 3 - выполняется при условии x=0
                y = Math.Pow((2 * Math.PI * Math.Cos(x)), 1.0 / 3.0);  //вычисление результата
            }   
        }
        Console.WriteLine("Результат: " + y);   //вывод полученного результата
        Console.WriteLine("Для выхода из программы нажмите Enter.");
        Console.ReadLine();
        }
    }