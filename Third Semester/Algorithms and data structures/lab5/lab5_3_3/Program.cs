using System;
using System.Collections.Generic;

internal class Program
{
    static List<double> Merge(List<double> L1, List<double> L2)
    {
        List<double> L = new List<double>();
        int cnt1 = 0, cnt2= 0;
        while (cnt1 < L1.Count && cnt2 < L2.Count)
        {
            if (L1[cnt1] <= L2[cnt2])
            {
                L.Add(L1[cnt1]);
                cnt1++;
            }
            else
            {
                L.Add(L2[cnt2]);
                cnt2++;
            }
        }
        while (cnt1 < L1.Count)
        {
            L.Add(L1[cnt1]);
            cnt1++;
        }
        while (cnt2 < L2.Count)
        {
            L.Add(L2[cnt2]);
            cnt2++;
        }
        return L;

    }
    static void Main(string[] args)
    {
        List<double> L1 = new List<double>() {3, 2.4, 7.11, 1.1, 8.12, 2.4 };
        List<double> L2 = new List<double>() { 4.5, 6.7, 7.11, 1.1, 8.88, 9.11, 15.05, 4.5};
        L1.Sort();
        L2.Sort();
        List<double> L1L2 = Merge(L1, L2);
        foreach (double s in L1L2) //вывод элементов списка
        {
            Console.WriteLine(s);
        }
    }
}
