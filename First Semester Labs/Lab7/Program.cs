using System;
class Program
{
    static void ArMean(double[,] array, int n, int m)
    {
        double res = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                res += array[i, j];
            }
        }
        res /= n * m;
        Console.WriteLine("Среднее арифметическое массива = " + res);
    }
    static void Swap(double[,] array, int m, int k, int p)
    {
        double temp;
        for (int j = 0; j < m; j++)
        {
            temp = array[k - 1, j];
            array[k - 1, j] = array[p, j];
            array[p, j] = temp;
        }
    }
    static int FindLineWithMin(double[,] array, int n, int m)
    {
        int line = 0;
        double min = array[0, 0];
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (array[i, j] < min)
                {
                    min = array[i, j];
                    line = i;
                }
            }
        }
        return line;
    }
    static void PrintArr(double[,] array, int n,int m)
    {
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                Console.Write("{0,-7}", array[i, j]);
            }
            Console.WriteLine("\n");
        }
    }
    static void Input(double[,] arrSrc, double[,] arrPrc, int n,int m)
    {
        Console.WriteLine("Введите элементы массива: ");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                arrSrc[i, j] = double.Parse(Console.ReadLine());
                arrPrc[i, j] = arrSrc[i, j];
            }
        }
    }
    static void Main()
    {
        Console.Write("Введите количество строк: ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Введите количество столбцов: ");
        int m = int.Parse(Console.ReadLine());
        double[,] srcArr = new double[n, m];
        double[,] prcArr = new double[n, m];
        Console.Write("Введите номер строки, которую нужно поменять: ");
        int k = int.Parse(Console.ReadLine());
        Input(srcArr, prcArr, n, m);
        Console.WriteLine("Исходный массив: ");
        PrintArr(srcArr, n, m);
        ArMean(srcArr, n, m);
        int p = FindLineWithMin(srcArr, n, m);
        Swap(prcArr,m, k, p);
        Console.WriteLine("Сформированный массив: ");
        PrintArr(prcArr, n, m);
        ArMean(prcArr, n, m);
        Console.WriteLine("Для выхода нажмите любую клавишу.");
        Console.ReadKey();
    }
}