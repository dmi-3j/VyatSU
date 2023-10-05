using System;

internal class Program
{
    private static void swap(ref int x, ref int y)
    {
        int temp = x; x = y; y = temp;
    }
    public static void QuadroSelectSort(int[] array)
    {

        int groupSize = (int)Math.Sqrt(array.Length);

        for (int i = 0; i < array.Length; i += groupSize)
        {
            int end = Math.Min(i + groupSize, array.Length);
            int maxIndex = i;
            // Находим индекс максимального элемента в текущей группе
            for (int j = i + 1; j < end; j++)
            {
                if (array[j] > array[maxIndex])
                {
                    maxIndex = j;
                }
            }
            // Обмениваем максимальный элемент с последним элементом в группе
            swap(ref array[maxIndex], ref array[end - 1]);
        }

        // Сортируем максимальные элементы
        for (int i = array.Length - 1; i >= 0; i--)
        {
            int maxIndex = 0;

            // Находим индекс максимального элемента в текущей части массива
            for (int j = 1; j <= i; j++)
            {
                if (array[j] > array[maxIndex])
                {
                    maxIndex = j;
                }
            }
            // Обмениваем максимальный элемент с последним элементом в текущей части
            swap(ref array[maxIndex], ref array[i]);
        }
    }
    static void Main(string[] args)
    {
        Random random = new Random();
        int[] array = new int[9];
        Console.WriteLine("Исходный массив:");
        for (int i = 0; i < array.Length; i++)
        {
            array[i] = random.Next(1, 100);
            Console.Write(array[i] + " ");
        }
        Console.WriteLine();
        QuadroSelectSort(array);
        Console.WriteLine("\nОтосортированный массив:");
        for (int i = 0; i < array.Length; i++)
        {
            Console.Write(array[i] + " ");
        }
        Console.WriteLine("\n");
    }
}

