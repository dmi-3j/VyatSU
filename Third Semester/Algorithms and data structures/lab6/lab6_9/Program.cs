using System;

internal class Program
{
    public static void ShellSort(int[] array)
    {
        int[] incs = { 5, 3, 1 }; //приращения

        foreach (int inc in incs)
        {
            for (int i = inc; i < array.Length; i++)
            {
                int temp = array[i];
                int j;
                for (j = i; j >= inc && array[j - inc] > temp; j -= inc) //идем с шагом inc в начало массива
                {
                    array[j] = array[j - inc]; // свдигаем элементы для вставки
                }
                array[j] = temp; //вставляем элемент
            }
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
        ShellSort(array);
        Console.WriteLine("\nОтосортированный массив:");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine("\n");
    }
}

