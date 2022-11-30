using System;
    class Program
    {
        static void Main()
        {
        double s, x, result = 0; 
        Console.Write("Введите значение переменной n: "); //переменная n - диапазон суммирования
        int n = int.Parse(Console.ReadLine());
        Console.Write("Введите значение переменой x: "); //переменная x, вводимая с клавиатуры
        x = double.Parse(Console.ReadLine()); 
        if (Math.Abs(x) < 4)    //проверка числа х на соответствие условию
        {
           for (int i = 0;i <= n;i++)  //цикл с параметром
           {
               s = (Math.Pow(x, i + 2)) / (Math.Pow(5, i) + i); //вычисление члена последовательности
               if ((i + 1) % 3 == 0) Console.WriteLine("Выводится каждый третий элемент. Номер текущего: " + (i + 1) + ". Его значение: " + s); // вывод второй части задания (вывод каждого третьего элемента)
               result += s; //вычисление суммы (необходимый результат)
           }
           Console.WriteLine("Результат вычислений: " + result); //вывод результата первой части задания
        }
        else Console.WriteLine("Введите правильное значение х");
        Console.WriteLine("Для выхода из программы нажмите Enter.");
        Console.ReadLine();
        }
    }