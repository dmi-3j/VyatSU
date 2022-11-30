using System;
class Program
{
    
    static int SumOfDividors(int k)
    {
        int s = 0;
        for (int i = 1; i*i <= k; i++)
        {
            if (k % i == 0)
            {
                s += i;
                if (i * i != k)
                {
                    s += k / i;
                }
            }
        }
        return s-k;
    }
    static void Main()
    {
        int sum;
        Console.WriteLine("Дружественные числа до 50000:");
        for (int i = 1;i<=50000; i++)
        {
            sum = SumOfDividors(i);
            if ((SumOfDividors(sum) == i) && (sum > i) && (sum != i)) Console.WriteLine(i + " И " + sum); 
        }
        Console.WriteLine("Для выхода из программы нажмите любую клавишу");
        Console.ReadKey();
    }
}