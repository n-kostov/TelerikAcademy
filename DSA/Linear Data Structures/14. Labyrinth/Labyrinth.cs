using System;
using System.Collections.Generic;

namespace _14.Labyrinth
{
    public struct Position
    {
        public int X;
        public int Y;
    }

    public class Labyrinth
    {
        private static int[,] directions = { { 0, 1 }, { 0, -1 }, { 1, 0 }, { -1, 0 } };

        private static string[,] labyrinth = 
        {
            { "0", "0", "0", "X", "0", "X" },
            { "0", "X", "0", "X", "0", "X" },
            { "0", "*", "X", "0", "X", "0" },
            { "0", "X", "0", "0", "0", "0" },
            { "0", "0", "0", "X", "X", "0" },
            { "0", "0", "0", "X", "0", "X" }
        };

        public static void CalculateMinimalDistancesFromGivenPosition(string[,] labyrinth, Position startPosition)
        {
            Queue<Position> positions = new Queue<Position>();
            Queue<int> distances = new Queue<int>();

            positions.Enqueue(startPosition);
            distances.Enqueue(1);

            while (positions.Count != 0)
            {
                Position currentPosition = positions.Dequeue();
                int currentDistance = distances.Dequeue();

                for (int i = 0; i < directions.GetLength(0); i++)
                {
                    Position possiblePosition = new Position();
                    possiblePosition.X = currentPosition.X + directions[i, 0];
                    possiblePosition.Y = currentPosition.Y + directions[i, 1];

                    if (IsValidMove(labyrinth, possiblePosition))
                    {
                        positions.Enqueue(possiblePosition);
                        distances.Enqueue(currentDistance + 1);
                        labyrinth[possiblePosition.X, possiblePosition.Y] = currentDistance.ToString();
                    }
                }
            }

            FillUnreachableCells(labyrinth);
        }

        public static Position GetStartingPoint(string[,] labyrinth)
        {
            int rows = labyrinth.GetLength(0);
            int cols = labyrinth.GetLength(1);
            Position startingPoint = new Position();

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    if (labyrinth[row, col] == "*")
                    {
                        startingPoint.X = row;
                        startingPoint.Y = col;
                        return startingPoint;
                    }
                }
            }

            return startingPoint;
        }

        public static void PrintLabyirinth(string[,] labyrinth)
        {
            int rows = labyrinth.GetLength(0);
            int cols = labyrinth.GetLength(1);

            for (int row = 0; row < rows; row++)
            {
                for (int col = 0; col < cols; col++)
                {
                    Console.Write("{0,2} ", labyrinth[row, col]);
                }

                Console.WriteLine();
            }
        }

        public static void Main(string[] args)
        {
            Position startPosition = GetStartingPoint(labyrinth);
            PrintLabyirinth(labyrinth);

            Console.WriteLine();

            CalculateMinimalDistancesFromGivenPosition(labyrinth, startPosition);
            PrintLabyirinth(labyrinth);
        }

        private static void FillUnreachableCells(string[,] labyrinth)
        {
            const string UnreachableCell = "u";
            for (int row = 0; row < labyrinth.GetLength(0); row++)
            {
                for (int col = 0; col < labyrinth.GetLength(1); col++)
                {
                    if (labyrinth[row, col] == "0")
                    {
                        labyrinth[row, col] = UnreachableCell;
                    }
                }
            }
        }

        private static bool IsValidMove(string[,] labyrinth, Position position)
        {
            bool isValidMove = position.X >= 0 && position.X < labyrinth.GetLength(0) &&
                position.Y >= 0 && position.Y < labyrinth.GetLength(1) &&
                labyrinth[position.X, position.Y] == "0";

            return isValidMove;
        }
    }
}
