using System;

class CalculationsWithVariableNumberOfAgruments
{

    static T Min<T>(params T[] array) where T : System.IComparable<T>
    {
        T min = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i].CompareTo(min) < 0)
            {
                min = array[i];
            }
        }
        return min;
    }

    static T Max<T>(params T[] array) where T : IComparable<T>
    {
        T max = array[0];
        for (int i = 1; i < array.Length; i++)
        {
            if (array[i].CompareTo(max) > 0)
            {
                max = array[i];
            }
        }
        return max;
    }

    static T Average<T>(params T[] array)
    {
        if (array.Length > 0)
        {
            dynamic average = 0;
            for (int i = 0; i < array.Length; i++)
            {
                average += array[i];
            }
            return average / array.Length;
        } 
        else
        {
            return default(T);
        }

    }

    static T Sum<T>(params T[] array)
    {
        if (array.Length > 0)
        {
            dynamic sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            return sum;
        } 
        else
        {
            return default(T);
        }

    }

    static T Product<T>(params T[] array)
    {
        if (array.Length > 0)
        {
            dynamic product = 1;
            for (int i = 0; i < array.Length; i++)
            {
                product *= array[i];
            }
            return product;
        } 
        else
        {
            return default(T);
        }

    }

    static void Main()
    {
        Console.WriteLine(Product(1,2,3,4));
    }
}

