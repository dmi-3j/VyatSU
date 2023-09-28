using System;
using System.Collections.Generic;
using System.Linq;

namespace lab5_3
{
    internal class Program
    {

        static void IsEmpty<T>(List<T> list) //задание а
        {
            if(list.Count == 0) Console.WriteLine("Лист пустой");
            else Console.WriteLine("Лист не пустой");
        }
        static double ArithmeticMean(List<double> list) { //задание б
            double sum = 0;
            if (list.Count != 0)
            {
                foreach (double s in list)
                {
                    sum += s;
                }
                return sum / list.Count;
            }
            else
            {
                Console.WriteLine("Лист пустой");
                return 0;
            }
        }
        static void IsSorted<T>(List<T> list) //задание д
        {
            List<T> listTemp = new List<T> (list);
            listTemp.Sort();
            if (list.SequenceEqual(listTemp)) Console.WriteLine("Список упорядочен");
            else
            {
                listTemp.Reverse();
                if (list.SequenceEqual(listTemp)) Console.WriteLine("Список упорядочен");
                else Console.WriteLine("Список не упорядочен");
            } 
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Задание а");//////

            List<string> list = new List<string>();
            list.Insert(0, "a");
            list.Insert(0, "b");
            list.Insert(0, "c");
            IsEmpty(list);
            foreach (string s in list) //вывод элементов списка
            {
                Console.WriteLine(s);
            }

            Console.WriteLine("Задание б");//////

            List<double> doubles = new List<double>();
            doubles.Insert(0, 1.5);
            doubles.Insert(0, 3.0);
            doubles.Insert(0, 4.5);
            Console.WriteLine("Среднее арифметическое: " + ArithmeticMean(doubles));
            
            Console.WriteLine("Задание в");//////

            LinkedList<int> linkedList = new LinkedList<int>();
            linkedList.AddFirst(5);
            linkedList.AddFirst(2);
            linkedList.AddFirst(3);
            linkedList.AddFirst(2);
            linkedList.AddFirst(2);
            Console.WriteLine("До замены 2 на 22");
            foreach (int s in linkedList) //вывод элементов списка
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("После замены 2 на 22");
            LinkedListNode<int> cuur = linkedList.First;
            while(cuur != null)
            {
                if (cuur.Value == 2) cuur.Value = 22;
                cuur = cuur.Next;
            }
            foreach (int s in linkedList) //вывод элементов списка
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("Задание д");//////
            IsSorted(doubles);

            Console.WriteLine("Задание е");//////
            if (linkedList.Count >= 2)
            {
                int lastNode = linkedList.Last.Value;
                int secondToLastNode = linkedList.Last.Previous.Value;
                int sum = lastNode + secondToLastNode;
                Console.WriteLine("Сумма: " + sum);
            }
        }
    }
}
