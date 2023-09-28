using System;
using System.Collections.Generic;
using System.Collections;

internal class Program
{
    public class DoublyNode<T>// элемент дека
    {
        public DoublyNode(T data)
        {
            Data = data;
        }
        public T Data { get; set; }
        public DoublyNode<T> Previous { get; set; }
        public DoublyNode<T> Next { get; set; }
    }

    public class Deque<T> : IEnumerable<T>  // двусвязный список
    {
        DoublyNode<T> head; // головной/первый элемент
        DoublyNode<T> tail; // последний/хвостовой элемент
        int count;  // количество элементов в списке

        // добавление элемента в конец
        public void AddLast(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);

            if (head == null)
                head = node;
            else
            {
                tail.Next = node;
                node.Previous = tail;
            }
            tail = node;
            count++;
        }

        // добавление элемента в начало
        public void AddFirst(T data)
        {
            DoublyNode<T> node = new DoublyNode<T>(data);
            DoublyNode<T> temp = head;
            node.Next = temp;
            head = node;
            if (count == 0)
                tail = head;
            else
                temp.Previous = node;
            count++;
        }
        // удаление элемента с начала
        public T RemoveFirst()
        {
            if (count == 0)
                throw new InvalidOperationException();
            T output = head.Data;
            if (count == 1)
            {
                head = tail = null;
            }
            else
            {
                head = head.Next;
                head.Previous = null;
            }
            count--;
            return output;
        }

        // удаление элемента с конца
        public T RemoveLast()
        {
            if (count == 0)
                throw new InvalidOperationException();
            T output = tail.Data;
            if (count == 1)
            {
                head = tail = null;
            }
            else
            {
                tail = tail.Previous;
                tail.Next = null;
            }
            count--;
            return output;
        }
        // получение первого элемента
        public T First
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return head.Data;
            }
        }
        // получение последнего элемента
        public T Last
        {
            get
            {
                if (IsEmpty)
                    throw new InvalidOperationException();
                return tail.Data;
            }
        }

        public int Count { get { return count; } }
        public bool IsEmpty { get { return count == 0; } }

        public void Clear()
        {
            head = null;
            tail = null;
            count = 0;
        }

        public bool Contains(T data)
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                if (current.Data.Equals(data))
                    return true;
                current = current.Next;
            }
            return false;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            DoublyNode<T> current = head;
            while (current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }
    }
    static void Main(string[] args)
    {
        Stack<string> numbers = new Stack<string>();
        Console.WriteLine("Стек");
        numbers.Push("Раз");
        numbers.Push("Два");
        numbers.Push("Три");
        numbers.Push("Четыре");
        numbers.Push("Пять");

        Console.WriteLine("Первоначальный стек:");
        foreach (string number in numbers)
        {
            Console.WriteLine(number);
        }

        Console.WriteLine("\nPopping '{0}'", numbers.Pop());
        Console.WriteLine("Peek at next item to destack: {0}",
            numbers.Peek());
        Console.WriteLine("Popping '{0}'", numbers.Pop());

        Stack<string> stack2 = new Stack<string>(numbers.ToArray());

        Console.WriteLine("\nContents of the first copy:");
        foreach (string number in stack2)
        {
            Console.WriteLine(number);
        }

        string[] array2 = new string[numbers.Count * 2];
        numbers.CopyTo(array2, numbers.Count);

        Stack<string> stack3 = new Stack<string>(array2);

        Console.WriteLine("\nContents of the second copy, with duplicates and nulls:");
        foreach (string number in stack3)
        {
            Console.WriteLine(number);
        }
        //////////////////////////////////////////////////////////////////////
        Queue<string> numbers2 = new Queue<string>();
        Console.WriteLine("Очередь");
        numbers2.Enqueue("one");
        numbers2.Enqueue("two");
        numbers2.Enqueue("three");
        numbers2.Enqueue("four");
        numbers2.Enqueue("five");

        // вывод очереди
        foreach (string number in numbers2)
        {
            Console.WriteLine(number);
        }

        Console.WriteLine("\nDequeuing '{0}'", numbers2.Dequeue());
        Console.WriteLine("Peek at next item to dequeue: {0}",
            numbers.Peek());
        Console.WriteLine("Dequeuing '{0}'", numbers2.Dequeue()); // Удаляет объект из начала очереди Queue и возвращает его

        //Создаеn копию очереди, используя метод toArray и конструктор

        Queue<string> queueCopy = new Queue<string>(numbers2.ToArray());

        Console.WriteLine("\nContents of the first copy:");
        foreach (string number in queueCopy)
        {
            Console.WriteLine(number);
        }

        // Создайем массив, в два раза превышающий размер очереди, и копируем его
        // элементы очереди, начиная с середины
        // массива.
        string[] array3 = new string[numbers2.Count * 2];
        numbers.CopyTo(array3, numbers2.Count);  // Копирует элементы коллекции Queue в существующий одномерный массив Array, начиная с указанного значения индекса массива.

        // Создаем вторую очередь, используя конструктор

        Queue<string> queueCopy2 = new Queue<string>(array3);

        Console.WriteLine("\nContents of the second copy, with duplicates and nulls:");
        foreach (string number in queueCopy2)
        {
            Console.WriteLine(number);
        }
        //////////////////////////////////////////////////////////////////////
        Console.WriteLine("ДЕК");
        Deque<string> deque = new Deque<string>();
        //заполняем дек
        deque.AddFirst("Первый");
        deque.AddLast("Второй");
        Console.WriteLine("Первоначальный дек:");
        foreach (string s in deque)
            Console.WriteLine(s);
        Console.WriteLine();

        deque.AddFirst("Добавлен перед первым"); //добавляем в начало
        Console.WriteLine("Дек после добавления в начало:");
        foreach (string s in deque)
            Console.WriteLine(s);
        Console.WriteLine();

        deque.AddLast("Третий добавлен в конец"); //добавляем в конец
        Console.WriteLine("Дек после добавления в конец:");
        foreach (string s in deque)
            Console.WriteLine(s);
        Console.WriteLine();
        string removedItemFirst = deque.RemoveFirst();
        Console.WriteLine("Удален первый элемент: {0}", removedItemFirst);
        string removedItemLast = deque.RemoveLast();
        Console.WriteLine("Удален последний элемент: {0}", removedItemLast);
        Console.WriteLine();

        Console.WriteLine("Дек после удаления из начала и конца:");
        foreach (string s in deque)
            Console.WriteLine(s);
    }
}