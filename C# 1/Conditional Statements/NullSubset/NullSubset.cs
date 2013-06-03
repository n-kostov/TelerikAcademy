using System;

class NullSubset
{
    static void Main()
    {
        int firstNumber = 3;
        int secondNumber = -2;
        int thirdNumber = 1;
        int fourthNumber = 1;
        int fifthNumber = 8;
        int[] minimals = new int[5];
        int minCount = 0;
        int[] maximals = new int[5];
        int maxCount = 0;

        if (firstNumber < 0)
        {
            minimals[minCount] = firstNumber;
            minCount++;
        }
        else
        {
            maximals[maxCount] = firstNumber;
            maxCount++;
        }
        if (secondNumber < 0)
        {
            minimals[minCount] = secondNumber;
            minCount++;
        }
        else
        {
            maximals[maxCount] = secondNumber;
            maxCount++;
        }
        if (thirdNumber < 0)
        {
            minimals[minCount] = thirdNumber;
            minCount++;
        }
        else
        {
            maximals[maxCount] = thirdNumber;
            maxCount++;
        }
        if (fourthNumber < 0)
        {
            minimals[minCount] = fourthNumber;
            minCount++;
        }
        else
        {
            maximals[maxCount] = fourthNumber;
            maxCount++;
        }
        if (fifthNumber < 0)
        {
            minimals[minCount] = fifthNumber;
            minCount++;
        }
        else
        {
            maximals[maxCount] = fifthNumber;
            maxCount++;
        }
        bool flag = false;
        int sum = 0;
        for (int i = 0; i < minCount; i++)
        {
            sum += minimals[i];
            int sumOfMaxElements = 0;
            for (int j = 0; j < maxCount; j++ )
            {
                if (maximals[j] + sumOfMaxElements + sum > 0)
                {
                    continue;
                } 
                else
                {
                    if ((maximals[j] + sumOfMaxElements + sum) == 0)
                    {
                        Console.WriteLine("Yes");
                        flag = true;
                    } 
                    else
                    {
                        sumOfMaxElements += maximals[j];
                    }
                }
            }
        }
        if (!flag)
        {
            Console.WriteLine("No");
        }
    }
}

