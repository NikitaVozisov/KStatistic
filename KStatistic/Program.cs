using System;
using System.IO;

namespace KStatistic
{
    class Program
    {
        
        static int partition(int[] arr, int left, int right)
        {
            int i = left, j = right;
            int tmp;
            double pivotindex = ((left + right) / 2);
            int pivot = arr[(int)Math.Floor(pivotindex)];

            while (i <= j)
            {
                while (arr[i] < pivot)
                    i++;
                while (arr[j] > pivot)
                    j--;
                if (i <= j)
                {
                    tmp = arr[i];
                    arr[i] = arr[j];
                    arr[j] = tmp;
                    i++;
                    j--;
                }
            };

            return i;
        }

        static void quickSort(int[] arr, int left, int right, int k)
        {
            int index = partition(arr, left, right);
            if (k <= index)
            {
                if (left < index - 1)
                    quickSort(arr, left, index - 1, k);
            }
            if (k >= index)
            {
                if (index < right)
                    quickSort(arr, index, right, k);
            }
        }

        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("kth.in"))
            {
                //int num = int.Parse(sr.ReadLine());
                string[] s = (sr.ReadLine()).Split(' ');
                int n = int.Parse(s[0]);
                int k = int.Parse(s[1]);
                s = (sr.ReadLine()).Split(' ');
                int A = int.Parse(s[0]);
                int B = int.Parse(s[1]);
                int C = int.Parse(s[2]);
                int[] a = new int[n];
                a[0] = int.Parse(s[3]);
                a[1] = int.Parse(s[4]);

                for (int i = 2; i < n; i++)
                {
                    try
                    {
                        a[i] = A * a[i - 2] + B * a[i - 1] + C;
                    }
                    catch { }
                }               
                quickSort(a, 0, n-1, k-1);
                using (StreamWriter sw = new StreamWriter("kth.out"))
                {
                   sw.Write(a[k - 1]);
                }
            }

        }
    }   
}
