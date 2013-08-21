namespace Minimum_Edit_Distance
{
    using System;

    public class MinimumEditDistance
    {
        private const decimal DeleteCost = 0.9m;
        private const decimal InsertCost = 0.8m;
        private const decimal ReplaceCost = 1m;

        private static decimal[,] costs;
        private static string initialWord;
        private static string editedWord;

        public static decimal FindMinimumEditDistance()
        {
            int m = initialWord.Length;
            int n = editedWord.Length;
            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    decimal insertOperation = costs[i, j - 1];
                    decimal deleteOperation = costs[i - 1, j];
                    decimal replaceOperation = costs[i - 1, j - 1];
                    decimal min;
                    if (i == j)
                    {
                        if (initialWord[i - 1] != editedWord[j - 1])
                        {
                            deleteOperation += DeleteCost;
                            insertOperation += InsertCost;
                            replaceOperation += ReplaceCost;
                        }

                        min = Math.Min(deleteOperation, insertOperation);
                        min = Math.Min(min, replaceOperation);
                    }
                    else if (j > i)
                    {
                        if (initialWord[i - 1] != editedWord[j - 1])
                        {
                            insertOperation += InsertCost;
                            replaceOperation += ReplaceCost;
                            min = Math.Min(insertOperation, replaceOperation);
                        }
                        else
                        {
                            min = costs[i - 1, j - 1];
                        }
                    }
                    else
                    {
                        if (initialWord[i - 1] != editedWord[j - 1])
                        {
                            deleteOperation += DeleteCost;
                            replaceOperation += ReplaceCost;
                            min = Math.Min(deleteOperation, replaceOperation);
                        }
                        else
                        {
                            min = costs[i - 1, j - 1];
                        }
                    }

                    costs[i, j] = min;
                }
            }

            return costs[m, n];
        }

        public static void PrintEditions(int i, int j)
        {
            if (i == 0 || j == 0)
            {
                if (i > j)
                {
                    Console.WriteLine("Deleted {0}", initialWord[0], costs[i, j]);
                }
                else if (j > i)
                {
                    Console.WriteLine("Inserted {0}", editedWord[0]);
                }

                return;
            }

            decimal deleteOperation = costs[i - 1, j];
            decimal insertOperation = costs[i, j - 1];
            decimal replaceOperation = costs[i - 1, j - 1];
            decimal min = Math.Min(deleteOperation, insertOperation);
            min = Math.Min(min, replaceOperation);

            if (costs[i, j - 1] == min)
            {
                PrintEditions(i, j - 1);
            }
            else if (costs[i - 1, j] == min)
            {
                PrintEditions(i - 1, j);
            }
            else
            {
                PrintEditions(i - 1, j - 1);
            }

            if (costs[i, j] - min == ReplaceCost)
            {
                Console.WriteLine("Replaced {0} with {1}", initialWord[i - 1], editedWord[j - 1]);
            }
            else if (costs[i, j] - min == DeleteCost)
            {
                Console.WriteLine("Deleted {0}", initialWord[i - 1]);
            }
            else if (costs[i, j] - min == InsertCost)
            {
                Console.WriteLine("Inserted {0}", editedWord[j - 1]);
            }
        }

        public static void InitializeCosts()
        {
            for (int i = 1; i < costs.GetLength(0); i++)
            {
                costs[i, 0] = i * DeleteCost;
            }

            for (int i = 1; i < costs.GetLength(1); i++)
            {
                costs[0, i] = i * InsertCost;
            }

            costs[0, 0] = 0;
        }

        public static void Main(string[] args)
        {
            initialWord = "developer";
            editedWord = "enveloped";
            costs = new decimal[X.Length + 1, editedWord.Length + 1];

            InitializeCosts();
            decimal optimalCost = FindMinimumEditDistance();
            Console.WriteLine(optimalCost);
            PrintEditions(initialWord.Length, editedWord.Length);
        }
    }
}
