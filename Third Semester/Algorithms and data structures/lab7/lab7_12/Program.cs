using System;


internal class Program
{
    static int NOD(int a, int b)
    {
        if (a == b || b == 0) return a;
        if (a == 0) return b;
        if ((a & 1) == 0) //а четное
        {
            if ((b & 1) == 1) //b нечетное
            {
                return NOD(a >> 1, b); // второе соотношение
            }
            else
            {
                return NOD(a >> 1, b >> 1) << 1; //первое соотношение
            }
        }
        else //а нечетное
        {
            if (((b & 1) == 0)) //b четное
            {
                return NOD(a, b >> 1);  // второе соотношение
            }
            else //a и b нечетные
            {
                if (a > b)
                {
                    return NOD((a - b) >> 1, b);
                }
                else
                {
                    return NOD(a, (b - a) >> 1); 
                }
            }
        }
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Введите первое число: ");
        int a = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите второе число: ");
        int b = int.Parse(Console.ReadLine());
        Console.WriteLine("Наибольший общий делитель: " + NOD(a, b));
    }
}
