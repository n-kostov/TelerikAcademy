namespace _02.Colored_Rabbits
{
    using System;
    using System.Collections.Generic;

    public class ColoredRabbits
    {
        public static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<int, int> answers = new Dictionary<int, int>();
            for (int i = 0; i < n; i++)
            {
                int number = int.Parse(Console.ReadLine());
                if (answers.ContainsKey(number))
                {
                    answers[number]++;
                }
                else
                {
                    answers[number] = 1;
                }
            }

            int rabbitsCount = 0;
            foreach (var answer in answers)
            {
                int currentAnswerCount = answer.Value;
                while (currentAnswerCount > 0)
                {
                    rabbitsCount += answer.Key + 1;
                    currentAnswerCount -= answer.Key + 1;
                }
            }

            Console.WriteLine(rabbitsCount);
        }
    }
}
