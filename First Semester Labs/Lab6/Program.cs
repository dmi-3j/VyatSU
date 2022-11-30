using System;
class Program
{
    static double Average(double[] array, int n)
    {
        double result = 0;
        for (int i = 0; i < n; i++)
        {
            result += array[i];
        }
        result /= n;
        return result;
    }
    static void Main()
    {
        Console.Write("Введите размер массива: ");
        int n = int.Parse(Console.ReadLine());
        double[] arrA = new double[n];
        double[] arrB = new double[n];
        string arr1 = "", arr2 = "";
        Console.WriteLine("Введите элементы массива: ");
        for (int i = 0; i < n; i++)
        {
            arrA[i] = double.Parse(Console.ReadLine());
            arr1 += arrA[i] + " ";
        }
        int count = 0;
        for (int j = 0; j < n; j++)
        {
            if (Math.Abs(arrA[j]) > Average(arrA, n))
            {
                arrB[count] = arrA[j];
                arr2 += arrB[count] + " ";
                count++;
            }
        }
        Array.Resize(ref arrB, count);
        Console.WriteLine("Исходный массив: " + arr1);
        Console.WriteLine("Среднее арифметическое исходного массива: " + Average(arrA, n));
        if (count != 0)
        {
            Console.WriteLine("Сформированный массив: " + arr2);
            Console.WriteLine("Среднее арифметическое сформированного массива: " + Average(arrB, count));
        }
        else Console.WriteLine("Сформированный массив пуст.");
        Console.WriteLine("Для выхода нажмите любую клавишу.");
        Console.ReadKey();
    }
}