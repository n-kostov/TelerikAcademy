using System;

class PolynomialAddititon
{

    static int[] AddPolynomials(int[] arr1, int[] arr2)
    {
        int n = Math.Max(arr1.Length, arr2.Length);
        int[] result = new int[n];
        for (int i = 0; i < arr1.Length && i < arr2.Length; i++)
        {
            result[n - 1 - i] = arr1[arr1.Length - 1 - i] + arr2[arr2.Length - 1 - i];
        }
        if (arr1.Length > arr2.Length)
        {
            for (int i = arr2.Length; i < arr1.Length; i++)
            {
                result[n - 1 - i] = arr1[arr1.Length - 1 - i];
            }
        }
        else
        {
            for (int i = arr1.Length; i < arr2.Length; i++)
            {
                result[n - 1 - i] = arr2[arr2.Length - 1 - i];
            }
        }
        return result;
    }

    static int[] SusbstractPolynomials(int[] arr1, int[] arr2)
    {
        int n = Math.Max(arr1.Length, arr2.Length);
        int[] result = new int[n];
        for (int i = 0; i < arr1.Length && i < arr2.Length; i++)
        {
            result[n - 1 - i] = arr1[arr1.Length - 1 - i] - arr2[arr2.Length - 1 - i];
        }
        if (arr1.Length > arr2.Length)
        {
            for (int i = arr2.Length; i < arr1.Length; i++)
            {
                result[n - 1 - i] = arr1[arr1.Length - 1 - i];
            }
        }
        else
        {
            for (int i = arr1.Length; i < arr2.Length; i++)
            {
                result[n - 1 - i] = -arr2[arr2.Length - 1 - i];
            }
        }
        return result;
    }

    static int[] MultiplyPolynomials(int[] arr1, int[] arr2)
    {
        int n = (arr1.Length - 1) + (arr2.Length - 1) + 1;
        int[] result = new int[n];
        for (int i = 0; i < n; i++)
        {
            result[i] = 0;
        }
        for (int i = arr1.Length - 1; i >= 0; i--)
        {
            for (int j = arr2.Length - 1; j >= 0; j--)
            {
                //if (i != 0)
                //{
                //    result[i + j - 1] += arr1[i] * arr2[j];
                //} 
                //else
                //{
                    result[i + j] += arr1[i] * arr2[j];
                

            }
        }
        return result;
    }

    static void Main()
    {
        int[] arr1 = { 1, 1 };
        int[] arr2 = { 1, 1 };
        int[] res = MultiplyPolynomials(arr1, arr2);
        int[] result = MultiplyPolynomials(arr1, res);
        foreach (int item in result)
        {
            Console.Write(item + " ");
        }
    }
}

