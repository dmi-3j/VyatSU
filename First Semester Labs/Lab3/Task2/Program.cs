using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("Введите номер дня в году (от 1 до 365): ");
        int k = int.Parse(Console.ReadLine()); //вводимый номер дня по условию
        Console.WriteLine("Введите, какой день недели 1 января (от 1 до 7):");
        int d = int.Parse(Console.ReadLine()); //день недели 1 января по условию
        int result = (k + d - 2) % 7 + 1; //вычисление дня недели
        switch (result) //вывод нужного результата
        {
            case 1 : Console.WriteLine("Рабочий день"); break;
            case 2 : Console.WriteLine("Рабочий день"); break;
            case 3: Console.WriteLine("Рабочий день"); break;
            case 4: Console.WriteLine("Рабочий день"); break;
            case 5: Console.WriteLine("Рабочий день"); break;
            case 6: Console.WriteLine("Суббота"); break;
            case 7: Console.WriteLine("Воскресенье"); break;
        }
        Console.WriteLine("Для выхода из программы нажмите Enter.");
        Console.ReadLine();
    }
}