using System;

internal class Program
{
    static string Tr(int num, int osn)
    {
        if (osn <= 10 && osn >= 2)
        {
            if (num < osn) return num.ToString();
            else
            {
                int remain = num % osn;
                int  wholePart = num / osn;
                return Tr(wholePart, osn) + remain.ToString();
            }
        }
        else return "Введите корректное основание системы счисления";
    }
    static void Main(string[] args)
    {
        Console.WriteLine("Введите число в 10 системе счисления: ");
        int num = int.Parse(Console.ReadLine());
        Console.WriteLine("Введите основание новой системы счисления от 2 до 10: ");
        int osn = int.Parse(Console.ReadLine());
        string res = Tr(num, osn);
        Console.WriteLine("Результат: " + res);
    }
}

