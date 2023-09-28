using System;
using System.Collections.Generic;

internal class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Задание а");

        LinkedList<int> L1 = new LinkedList<int>(new[] { 1, 2, 3, 4 });
        LinkedList<int> L2 = new LinkedList<int>(new[] { 7, 4, 5, 6 });
        LinkedList<int> L = new LinkedList<int>();
        foreach (int item in L1)
        {
            if (!L.Contains(item)) L.AddLast(item); // Добавляем элементы из L1, которые еще не содержатся в L
        }
        foreach (int item in L2)  // Перебираем элементы из L2
        {
            if (!L.Contains(item)) L.AddLast(item); // Добавляем элементы из L2, которые еще не содержатся в L
        }
        Console.WriteLine("Список L:"); // Выводим содержимое списка L
        foreach (int item in L) Console.WriteLine(item);

        Console.WriteLine("Задание в");
        L.Clear();
        foreach (int item in L1)
        {
            if(!L2.Contains(item)) L.AddLast(item);
        }
        foreach (int item in L) Console.WriteLine(item);
    }
}

