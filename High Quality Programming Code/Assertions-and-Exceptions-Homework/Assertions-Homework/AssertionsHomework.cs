﻿using System;
using System.Diagnostics;

public class AssertionsHomework
{
    public static void SelectionSort<T>(T[] arr) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "The input array is null!");

        for (int index = 0; index < arr.Length - 1; index++)
        {
            int minElementIndex = FindMinElementIndex(arr, index, arr.Length - 1);
            Swap(ref arr[index], ref arr[minElementIndex]);
        }

        for (int i = 0; i < arr.Length - 1; i++)
        {
            Debug.Assert(arr[i].CompareTo(arr[i + 1]) <= 0, "The array is not sorted!");
        }
    }

    public static int BinarySearch<T>(T[] arr, T value) where T : IComparable<T>
    {
        Debug.Assert(arr != null, "The input array cannot be null");
        Debug.Assert(value != null, "The searched value cannot be null!");

        for (int i = 0; i < arr.Length - 1; i++)
        {
            Debug.Assert(arr[i].CompareTo(arr[i + 1]) <= 0, "The input array is not sorted!");
        }

        return BinarySearch(arr, value, 0, arr.Length - 1);
    }

    public static void Main()
    {
        int[] arr = new int[] { 3, -1, 15, 4, 17, 2, 33, 0 };
        Console.WriteLine("arr = [{0}]", string.Join(", ", arr));
        SelectionSort(arr);
        Console.WriteLine("sorted = [{0}]", string.Join(", ", arr));

        SelectionSort(new int[0]); // Test sorting empty array
        SelectionSort(new int[1]); // Test sorting single element array

        Console.WriteLine(BinarySearch(arr, -1000));
        Console.WriteLine(BinarySearch(arr, 0));
        Console.WriteLine(BinarySearch(arr, 17));
        Console.WriteLine(BinarySearch(arr, 10));
        Console.WriteLine(BinarySearch(arr, 1000));
    }

    private static int BinarySearch<T>(T[] arr, T value, int startIndex, int endIndex)
    where T : IComparable<T>
    {
        Debug.Assert(startIndex <= endIndex, "The start index should be smaller than or equal to the end index!");
        Debug.Assert(startIndex >= 0, "The start index should be positive!");
        Debug.Assert(endIndex >= 0, "The end index should be positive!");
        Debug.Assert(endIndex <= arr.Length - 1, "The end index should be smaller than the length of the input array!");

        while (startIndex <= endIndex)
        {
            int midIndex = (startIndex + endIndex) / 2;
            if (arr[midIndex].Equals(value))
            {
                return midIndex;
            }

            if (arr[midIndex].CompareTo(value) < 0)
            {
                // Search on the right half
                startIndex = midIndex + 1;
            }
            else
            {
                // Search on the right half
                endIndex = midIndex - 1;
            }
        }

        for (int i = startIndex; i <= endIndex; i++)
        {
            Debug.Assert(!arr[i].Equals(value), "The index of value cannot be -1 since value is in the array.");
        }

        // Searched value not found
        return -1;
    }

    private static int FindMinElementIndex<T>(T[] arr, int startIndex, int endIndex)
        where T : IComparable<T>
    {
        Debug.Assert(arr != null, "The input array cannot be null!");
        Debug.Assert(startIndex >= 0, "The start index should be positive!");
        Debug.Assert(endIndex >= 0, "The end index should be positive!");
        Debug.Assert(endIndex <= arr.Length - 1, "The end index should be smaller than the length of the array!");
        Debug.Assert(startIndex <= endIndex, "Start index should be smaller than or equal to the end index!");

        int minElementIndex = startIndex;
        for (int i = startIndex + 1; i <= endIndex; i++)
        {
            if (arr[i].CompareTo(arr[minElementIndex]) < 0)
            {
                minElementIndex = i;
            }
        }

        for (int i = startIndex + 1; i < endIndex; i++)
        {
            Debug.Assert(
                arr[minElementIndex].CompareTo(arr[i]) <= 0,
                "The element" + arr[minElementIndex] + " is not the smallest one in the array!");
        }

        return minElementIndex;
    }

    private static void Swap<T>(ref T x, ref T y)
    {
        T oldX = x;
        x = y;
        y = oldX;
    }
}
