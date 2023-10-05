using System;

internal class Program
{
    static void BinaryInsertSort(int[] array)
    {
        for (int i = 1; i < array.Length; i++)
        {
            int key = array[i];
            int left = 0;
            int right = i - 1;
            // Используем бинарный поиск для нахождения места вставки
            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (array[mid] > key)
                    right = mid - 1;
                else
                    left = mid + 1;
            }
            // Перемещаем элементы для освобождения места
            for (int j = i - 1; j >= left; j--)
            {
                array[j + 1] = array[j];
            }
            // Вставляем элемент на правильное место
            array[left] = key;
        }
    }
    static void Main(string[] args)
    {
        Random random = new Random();
        int[] array = new int[10];
        Console.WriteLine("Исходный массив:");
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(1, 100);
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
        BinaryInsertSort(array);
        Console.WriteLine("\nОтосортированный массив:");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine("\n");
    }
}