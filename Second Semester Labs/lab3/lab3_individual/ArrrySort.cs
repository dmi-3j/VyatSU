namespace lab3_individual
{
    class ArraySort
    {
       
        public int[] a;
        private static void swap(ref int x, ref int y)
        {
            int temp = x; x = y; y = temp;
        }
        public void BubbleSortRecursive(int[] a, int n, ref int obm, ref int sr)
        {
            if (n == 1) return;
            for (int i = 0; i < n - 1; i++)
            {
                sr++;
                if (a[i] > a[i + 1])
                {
                    swap(ref a[i], ref a[i + 1]);
                    obm++;
                }
            }
            BubbleSortRecursive(a, n - 1, ref obm, ref sr);
        }
        public void ShellSort(int[] a, int n, ref int sr, ref int obm)
        {
            int step = a.Length / 2;
            while (step > 0)
            {
                sr++;
                for (int i = 0; i < (a.Length - step); i++)
                {
                    int j = i;
                    while ((j >= 0) && (a[j] > a[j + step]))
                    {
                        sr++;
                        swap(ref a[j], ref a[j + step]);
                        obm++;
                        j = j - step;
                    }
                }
                step = step / 2;
            }
        }
        public void BubbleSortCycle(int[] a, ref int sr, ref int obm)
        {
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = 0; j < a.Length - i - 1; j++)
                {
                    sr++;
                    if (a[j] > a[j + 1])
                    {
                        swap(ref a[j], ref a[j + 1]);
                        obm++;
                    }
                }
            }
        }
        public void SelectionSortRecursive(int[] a, int n, ref int sr, ref int obm, int startIndex)
        {
            if (startIndex >= a.Length - 1) return;
            int minIndex = startIndex;
            for (int i = startIndex + 1; i < a.Length; i++)
            {
                sr++;
                if (a[i] < a[minIndex]) minIndex = i;
            }
            if (minIndex != startIndex)
            {
                swap(ref a[minIndex], ref a[startIndex]);
                obm++;
            }
            SelectionSortRecursive(a, n, ref sr, ref obm, startIndex + 1);
        }
    }
}