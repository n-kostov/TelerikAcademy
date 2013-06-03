using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Minesweeper
{
    private const int TopResultsToKeep = 6;
    private const int BoardRows = 5;
    private const int BoardColumns = 10;
    private const char DefaultBoardCharacter = '?';
    private const char DefaultMineCharacter = '*';
    private const int MaxMines = 35;

    public static void Main(string[] args)
    {
        string command = string.Empty;
        char[,] board = InitializeTheBoard();
        char[,] mineField = GenerateBombs();
        int currentPoints = 0;
        bool hasHitMine = false;
        List<Score> champions = new List<Score>(TopResultsToKeep);
        int row = 0;
        int column = 0;
        bool needOfIntroduction = true;
        bool wonTheGame = false;

        do
        {
            if (needOfIntroduction)
            {
                PrintHelp();
                needOfIntroduction = false;
            }

            Console.Write("Row and Column: ");
            command = Console.ReadLine().Trim();

            if (command.Length >= 3)
            {
                if (int.TryParse(command[0].ToString(), out row) &&
                int.TryParse(command[2].ToString(), out column) &&
                    row <= board.GetLength(0) && column <= board.GetLength(1))
                {
                    command = "turn";
                }
            }

            switch (command)
            {
                case "top":
                    PrintHighscore(champions);
                    break;
                case "restart":
                    board = InitializeTheBoard();
                    mineField = GenerateBombs();
                    DrawTheBoard(board);
                    hasHitMine = false;
                    needOfIntroduction = false;
                    break;
                case "exit":
                    Console.WriteLine("Goodbye!");
                    break;
                case "turn":
                    if (mineField[row, column] != DefaultMineCharacter)
                    {
                        if (mineField[row, column] == DefaultBoardCharacter)
                        {
                            ChangeTurn(board, mineField, row, column);
                            currentPoints++;
                        }

                        if (MaxMines == currentPoints)
                        {
                            wonTheGame = true;
                        }
                        else
                        {
                            DrawTheBoard(board);
                        }
                    }
                    else
                    {
                        hasHitMine = true;
                    }

                    break;
                default:
                    Console.WriteLine("\nError! Invalid command\n");
                    break;
            }

            if (hasHitMine)
            {
                DrawTheBoard(mineField);
                Console.Write("\nYou hit a mine and got {0} points. " + "Your nickname: ", currentPoints);
                string nickname = Console.ReadLine();
                Score currentScore = new Score(nickname, currentPoints);
                if (champions.Count < 5)
                {
                    champions.Add(currentScore);
                }
                else
                {
                    for (int i = 0; i < champions.Count; i++)
                    {
                        if (champions[i].Points < currentScore.Points)
                        {
                            champions.Insert(i, currentScore);
                            champions.RemoveAt(champions.Count - 1);
                            break;
                        }
                    }
                }

                champions.Sort((Score r1, Score r2) => r2.NickName.CompareTo(r1.NickName));
                champions.Sort((Score r1, Score r2) => r2.Points.CompareTo(r1.Points));
                PrintHighscore(champions);

                board = InitializeTheBoard();
                mineField = GenerateBombs();
                currentPoints = 0;
                hasHitMine = false;
                needOfIntroduction = true;
            }

            if (wonTheGame)
            {
                Console.WriteLine("\nYou win! You have correctly identified all mines.");
                DrawTheBoard(mineField);
                Console.WriteLine("Your nickname: ");
                string nickname = Console.ReadLine();

                Score score = new Score(nickname, currentPoints);
                champions.Add(score);
                PrintHighscore(champions);

                board = InitializeTheBoard();
                mineField = GenerateBombs();
                currentPoints = 0;
                wonTheGame = false;
                needOfIntroduction = true;
            }
        }
        while (command != "exit");

        Console.WriteLine("Minesweeper 1.00 is made in Bulgaria!");
        Console.Read();
    }

    private static void PrintHelp()
    {
        Console.WriteLine(
            "Let's play Minesweeper.\n" +
            "Try to clear the minefield without detonating a mine.\nCommands:\n" +
            "\t- \"<row> <column>\": checks the field for a mine\n" +
            "\t- \"top\": shows the top results;\n" +
            "\t- \"restart\": starts a new game;\n" +
            "\t- \"exit\": exits the application.\n");
    }

    private static void PrintHighscore(List<Score> highscore)
    {
        Console.WriteLine("\nHighscore:");

        if (highscore.Count > 0)
        {
            for (int i = 0; i < highscore.Count; i++)
            {
                Console.WriteLine("{0}. {1} --> {2} points", i + 1, highscore[i].NickName, highscore[i].Points);
            }

            Console.WriteLine();
        }
        else
        {
            Console.WriteLine("The high score is empty!\n");
        }
    }

    private static void ChangeTurn(char[,] board, char[,] bombs, int row, int column)
    {
        char numberOfBombs = GetCountOfMinesNextToElement(bombs, row, column);
        bombs[row, column] = numberOfBombs;
        board[row, column] = numberOfBombs;
    }

    private static void DrawTheBoard(char[,] board)
    {
        int rows = board.GetLength(0);
        int columns = board.GetLength(1);

        Console.WriteLine("\n    0 1 2 3 4 5 6 7 8 9");
        Console.WriteLine("   ---------------------");

        for (int i = 0; i < rows; i++)
        {
            Console.Write("{0} | ", i);

            for (int j = 0; j < columns; j++)
            {
                Console.Write(string.Format("{0} ", board[i, j]));
            }

            Console.Write("|");
            Console.WriteLine();
        }

        Console.WriteLine("   ---------------------\n");
    }

    private static char[,] InitializeTheBoard()
    {
        char[,] board = new char[BoardRows, BoardColumns];

        for (int i = 0; i < BoardRows; i++)
        {
            for (int j = 0; j < BoardColumns; j++)
            {
                board[i, j] = DefaultBoardCharacter;
            }
        }

        return board;
    }

    private static char[,] GenerateBombs()
    {
        char[,] mineField = new char[BoardRows, BoardColumns];

        for (int i = 0; i < BoardRows; i++)
        {
            for (int j = 0; j < BoardColumns; j++)
            {
                mineField[i, j] = DefaultBoardCharacter;
            }
        }

        List<int> randomNumbers = new List<int>();
        Random randomNumberGenerator = new Random();

        while (randomNumbers.Count < 15)
        {
            int number = randomNumberGenerator.Next(BoardRows * BoardColumns);

            if (!randomNumbers.Contains(number))
            {
                randomNumbers.Add(number);
            }
        }

        foreach (int number in randomNumbers)
        {
            int row = number / BoardColumns;
            int column = number % BoardColumns;

            mineField[row, column] = DefaultMineCharacter;
        }

        return mineField;
    }

    private static char GetCountOfMinesNextToElement(char[,] board, int row, int column)
    {
        int countOfNeighborMines = 0;
        int rows = board.GetLength(0);
        int columns = board.GetLength(1);

        if (row - 1 >= 0)
        {
            if (board[row - 1, column] == DefaultMineCharacter)
            {
                countOfNeighborMines++;
            }
        }

        if (row + 1 < rows)
        {
            if (board[row + 1, column] == DefaultMineCharacter)
            {
                countOfNeighborMines++;
            }
        }

        if (column - 1 >= 0)
        {
            if (board[row, column - 1] == DefaultMineCharacter)
            {
                countOfNeighborMines++;
            }
        }

        if (column + 1 < columns)
        {
            if (board[row, column + 1] == DefaultMineCharacter)
            {
                countOfNeighborMines++;
            }
        }

        if ((row - 1 >= 0) && (column - 1 >= 0))
        {
            if (board[row - 1, column - 1] == DefaultMineCharacter)
            {
                countOfNeighborMines++;
            }
        }

        if ((row - 1 >= 0) && (column + 1 < columns))
        {
            if (board[row - 1, column + 1] == DefaultMineCharacter)
            {
                countOfNeighborMines++;
            }
        }

        if ((row + 1 < rows) && (column - 1 >= 0))
        {
            if (board[row + 1, column - 1] == DefaultMineCharacter)
            {
                countOfNeighborMines++;
            }
        }

        if ((row + 1 < rows) && (column + 1 < columns))
        {
            if (board[row + 1, column + 1] == DefaultMineCharacter)
            {
                countOfNeighborMines++;
            }
        }

        return char.Parse(countOfNeighborMines.ToString());
    }
}
