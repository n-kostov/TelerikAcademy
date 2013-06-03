using System;
using System.Collections.Generic;
using System.Text;

public class ExceptionsHomework
{
    public static T[] Subsequence<T>(T[] arr, int startIndex, int count)
    {
        if (arr == null)
        {
            throw new ArgumentNullException("arr", "The input array cannot be null!");
        }

        if (startIndex < 0)
        {
            throw new ArgumentOutOfRangeException("startIndex", "The start index cannot be negative!");
        }

        if (startIndex > arr.Length)
        {
            throw new ArgumentOutOfRangeException(
                "startIndex",
                "The start index cannot be larger than the length of the input array.");
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException("count", "The count cannot be negative.");
        }

        if (startIndex + count > arr.Length)
        {
            throw new ArgumentOutOfRangeException("startIndex + count", "The sequence elements must be in the input array!");
        }

        List<T> result = new List<T>();
        for (int i = startIndex; i < startIndex + count; i++)
        {
            result.Add(arr[i]);
        }

        return result.ToArray();
    }

    public static string ExtractEnding(string str, int count)
    {
        if (str == null)
        {
            throw new ArgumentNullException("str", "The input string cannot be null!");
        }

        if (count < 0)
        {
            throw new ArgumentOutOfRangeException("count", "The count cannot be negative!");
        }

        if (count > str.Length)
        {
            throw new ArgumentOutOfRangeException(
                "count",
                "The count of the ending cannot be greater than the length of the string!");
        }

        if (count > str.Length)
        {
            return "Invalid count!";
        }

        StringBuilder result = new StringBuilder();
        for (int i = str.Length - count; i < str.Length; i++)
        {
            result.Append(str[i]);
        }

        return result.ToString();
    }

    public static bool CheckPrime(int number)
    {
        for (int divisor = 2; divisor <= Math.Sqrt(number); divisor++)
        {
            if (number % divisor == 0)
            {
                return false;
            }
        }

        return true;
    }

    public static void Main()
    {
        var substr = Subsequence("Hello!".ToCharArray(), 2, 3);
        Console.WriteLine(substr);

        var subarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 2);
        Console.WriteLine(string.Join(" ", subarr));

        var allarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 4);
        Console.WriteLine(string.Join(" ", allarr));

        var emptyarr = Subsequence(new int[] { -1, 3, 2, 1 }, 0, 0);
        Console.WriteLine(string.Join(" ", emptyarr));

        Console.WriteLine(ExtractEnding("I love C#", 2));
        Console.WriteLine(ExtractEnding("Nakov", 4));
        Console.WriteLine(ExtractEnding("beer", 4));
        Console.WriteLine(ExtractEnding("Hi", 100));

        if (CheckPrime(23))
        {
            Console.WriteLine("23 is prime");
        }
        else
        {
            Console.WriteLine("23 is not prime");
        }

        if (CheckPrime(33))
        {
            Console.WriteLine("33 is prime");
        }
        else
        {
            Console.WriteLine("33 is not prime");
        }

        List<Exam> peterExams = new List<Exam>()
        {
            new SimpleMathExam(2),
            new CSharpExam(55),
            new CSharpExam(100),
            new SimpleMathExam(1),
            new CSharpExam(0),
        };
        Student peter = new Student("Peter", "Petrov", peterExams);
        double peterAverageResult = peter.CalcAverageExamResultInPercents();
        Console.WriteLine("Average results = {0:p0}", peterAverageResult);
    }
}
