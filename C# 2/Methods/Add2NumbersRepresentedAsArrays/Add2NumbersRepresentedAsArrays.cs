using System;

class Add2NumbersRepresentedAsArrays
{
    static int[] Add(int[] arr1, int[] arr2)
    {
        // we assume that both arrays have same number of elements
        int n = arr2.Length;
        int[] result = new int[n];
        int overflow = 0;
        for (int i = n - 1; i >= 0; i--)
        {
            if (i == 0)
            {
                result[i] = arr1[i] + arr2[i] + overflow;
            }
            else if (arr1[i] + arr2[i] + overflow > 9)
            {
                result[i] = (arr1[i] + arr2[i] + overflow) % 10;
                overflow = (arr1[i] + arr2[i] + overflow) / 10;
            } 
            else
            {
                result[i] = arr1[i] + arr2[i] + overflow;
                overflow = 0;
            }
        }
        return result;
    }

    static void Main()
    {
        int[] arr1 = { 3, 6, 7 };
        int[] arr2 = { 8, 1, 9 };
        int[] result = Add(arr1, arr2);
    }
}

