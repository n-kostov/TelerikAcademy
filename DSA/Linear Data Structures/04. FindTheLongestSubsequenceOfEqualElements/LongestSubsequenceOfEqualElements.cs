using System;
using System.Collections.Generic;

namespace _04.FindTheLongestSubsequenceOfEqualElements
{
    public class LongestSubsequenceOfEqualElements
    {
        public static List<int> GetLongestSubsequenceOfEqualNumbers(List<int> sequence)
        {
            if (sequence.Count == 0)
            {
                return new List<int>();
            }

            int value = sequence[0];

            int currentSequenceStartIndex = 0;
            int currentSequenceLength = 1;

            int maxSequenceStartIndex = 0;
            int maxSequenceLength = 1;

            for (int i = 1; i < sequence.Count; i++)
            {
                if (sequence[i] == value)
                {
                    currentSequenceLength++;
                    continue;
                }

                if (currentSequenceLength > maxSequenceLength)
                {
                    maxSequenceLength = currentSequenceLength;
                    maxSequenceStartIndex = currentSequenceStartIndex;
                }

                currentSequenceStartIndex = i;
                currentSequenceLength = 1;
                value = sequence[i];
            }

            if (currentSequenceLength > maxSequenceLength)
            {
                maxSequenceLength = currentSequenceLength;
                maxSequenceStartIndex = currentSequenceStartIndex;
            }

            List<int> subsequence = sequence.GetRange(maxSequenceStartIndex, maxSequenceLength);
            return subsequence;
        }

        public static void Main(string[] args)
        {
            List<int> sequence = new List<int> { 2, 1, 1, 2, 3, 3, 2, 2, 2, 1 };
            List<int> subsequence = GetLongestSubsequenceOfEqualNumbers(sequence);

            Console.WriteLine("The longest subsequence of equal numbers the sequence is: ");
            Console.WriteLine(string.Join(", ", subsequence));
        }
    }
}
