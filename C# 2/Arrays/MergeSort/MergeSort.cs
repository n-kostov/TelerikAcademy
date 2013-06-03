using System;

class MergeSort
{

    // this in not mine implementation
    // just searched the web for merge sort without methods
    static void Main()
    {
        int[] a = {5,4,3,2,1};
        int n = a.Length;
        int[] b = new int[n];
        for (int width = 1; width < n; width = 2 * width)
        {

            /* Array a is full of runs of length width. */
            for (int i = 0; i < n; i = i + 2 * width)
            {
                /* Merge two runs: a[i:i+width-1] and a[i+width:i+2*width-1] to b[] */
                /* or copy a[i:n-1] to b[] ( if(i+width >= n) ) */
                int i0 = i;
                int i1 = Math.Min(i + width, n);
                int iRight = Math.Min(i + width, n);
                int iEnd = Math.Min(i + 2 * width, n);
                /* While there are elements in the left or right lists */
                for (int j = i; j < iEnd; j++)
                {
                    /* If left list head exists and is <= existing right list head */
                    if (i0 < iRight && (i1 >= iEnd || a[i0] <= a[i1]))
                    {
                        b[j] = a[i0];
                        i0 = i0 + 1;
                    }
                    else
                    {
                        b[j] = a[i1];
                        i1 = i1 + 1;
                    }
                }
            }

            a = (int[])b.Clone();
        }

        foreach (int item in a)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }
}

