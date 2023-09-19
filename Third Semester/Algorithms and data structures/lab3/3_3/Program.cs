using System;

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите номер месяца: ");
            if(!int.TryParse(Console.ReadLine(), out int x)) 
            {
                Console.WriteLine("Вы ввели не число");
                return;
            }
            switch(x)
            {
                case 1: case 2: case 12:
                    Console.WriteLine("Зима");
                    break;
                case 3:  case 4: case 5:
                    Console.WriteLine("Весна");
                    break;
                case 6: case 7: case 8:
                    Console.WriteLine("Лето");
                    break;
                case 9: case 10: case 11:
                    Console.WriteLine("Осень");
                    break;
                default:
                    Console.WriteLine("Некорректный номер месяца");
                    break;
            }

        }
    }