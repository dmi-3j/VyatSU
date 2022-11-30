using System;
    class Program
    {
        static void Main()
        {
        double a,b,c,y;
        do
        {
            Console.WriteLine("Введите корректные значения переменных a, b, c, лежащие в области определения функции: ");
            Console.Write("Введите значение переменной a: ");
            a = double.Parse(Console.ReadLine());
            Console.Write("Введите значение переменной b: ");
            b = double.Parse(Console.ReadLine());
            Console.Write("Введите значение переменной c: ");
            c = double.Parse(Console.ReadLine());
        }
        while ((a == 0) || (b + c <= 0) || (b + c == 1));
        y = (Math.Pow(Math.E, c) + Math.Abs(Math.Pow(b, 2) - a)) / (a * Math.Pow(Math.Log(b + c), 2));
        Console.WriteLine("Результат вычислений: " + y);
        Console.WriteLine("Для выхода из программы нажмите любую клавишу");
        Console.ReadKey();
        }
    }