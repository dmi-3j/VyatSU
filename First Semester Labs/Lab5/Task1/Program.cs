using System;
class Program
{
    static void Main()
    {
        double element, sum = 0;
        long factorial;
        int n = 0;
        Console.Write("Введите число x: ");
        double x = double.Parse(Console.ReadLine());
        Console.Write("Введите значение бесконечно малой величины: ");
        double eps = double.Parse(Console.ReadLine());
        Console.Write("Введите значение бесконечно большой величины: ");
        double g = double.Parse(Console.ReadLine());
        Console.Write("Введите шаг вывода процесса сходимости: ");
        double step = double.Parse(Console.ReadLine());
        do
        {
            factorial = 1;
            for (int i = 2; i <= (2 * n + 1); i++)  //Цикл с предусловием для вычисления факториала.
            {
                factorial *= i;
            }
            element = Math.Pow(x, 3 * n) / factorial; //Вычисление члена ряда.
            sum += element; //Вычисление суммы ряда.
            if (((n + 1) % step) == 0) Console.WriteLine("Итерация: " + (n + 1) + ". Значение текущего элемента: " + element + ". Сумма: " + sum); //Вывод процесса сходимости ряда с задданным шагом.
            n++;
            
        }
        while ((Math.Abs(element) < g) && (Math.Abs(element) > eps)); //Цикл с постусловием
        if (Math.Abs(element) < eps)  //Проверка на сходимость.
        {
            Console.WriteLine("Ряд сходится");
            Console.WriteLine("Приблизительная сумма ряда = " + sum);
        }
        else Console.WriteLine("Ряд расходится");
    }
}