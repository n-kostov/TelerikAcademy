using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labyrinth
{
    class Program
    {
        struct Position
        {
            public int Level { get; set; }
            public int Row { get; set; }
            public int Col { get; set; }

            public Position(int l, int r, int c)
                : this()
            {
                this.Level = l;
                this.Row = r;
                this.Col = c;
            }
        }


        const char Unpassable = '#';
        const char Up = 'U';
        const char Down = 'D';
        private static char[, ,] labyrinth;
        private static HashSet<Position> visited;
        static int x;
        static int y;
        static int z;
        static int l;
        static int r;
        static int c;

        static int BFS()
        {
            Queue<Tuple<Position, int>> queue = new Queue<Tuple<Position, int>>();
            queue.Enqueue(new Tuple<Position, int>(new Position(x, y, z), 0));
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                visited.Add(current.Item1);
                if (current.Item1.Level < 0 || current.Item1.Level >= l)
                {
                    return current.Item2;
                }

                Position pUp = new Position(current.Item1.Level + 1, current.Item1.Row, current.Item1.Col);
                Position pDown = new Position(current.Item1.Level - 1, current.Item1.Row, current.Item1.Col);
                if (labyrinth[current.Item1.Level, current.Item1.Row, current.Item1.Col] == Up)
                {
                    if (current.Item1.Level == l - 1)
                    {
                        queue.Enqueue(new Tuple<Position, int>(pUp, current.Item2 + 1));

                    }
                    else if (labyrinth[current.Item1.Level + 1, current.Item1.Row, current.Item1.Col] != Unpassable)
                    {
                        queue.Enqueue(new Tuple<Position, int>(pUp, current.Item2 + 1));
                    }
                }
                else if (labyrinth[current.Item1.Level, current.Item1.Row, current.Item1.Col] == Down)
                {
                    if (current.Item1.Level == 0)
                    {
                        queue.Enqueue(new Tuple<Position, int>(pDown, current.Item2 + 1));
                    }
                    else if (labyrinth[current.Item1.Level - 1, current.Item1.Row, current.Item1.Col] != Unpassable)
                    {
                        queue.Enqueue(new Tuple<Position, int>(pDown, current.Item2 + 1));
                    }
                }

                Position p = new Position(current.Item1.Level, current.Item1.Row, current.Item1.Col - 1);
                if (current.Item1.Col > 0 && labyrinth[current.Item1.Level, current.Item1.Row, current.Item1.Col - 1] != Unpassable)
                {
                    queue.Enqueue(new Tuple<Position, int>(p, current.Item2 + 1));
                }

                p.Col += 2;
                //Position pRight = new Position(current.Item1.Level, current.Item1.Row, current.Item1.Col + 1);
                if (current.Item1.Col < c - 1 && labyrinth[current.Item1.Level, current.Item1.Row, current.Item1.Col + 1] != Unpassable)
                {
                    queue.Enqueue(new Tuple<Position, int>(p, current.Item2 + 1));
                }

                p.Col -= 1;
                p.Row -= 1;
                //Position pNorth = new Position(current.Item1.Level, current.Item1.Row - 1, current.Item1.Col);
                if (current.Item1.Row > 0 && labyrinth[current.Item1.Level, current.Item1.Row - 1, current.Item1.Col] != Unpassable)
                {
                    queue.Enqueue(new Tuple<Position, int>(p, current.Item2 + 1));
                }

                p.Row += 2;
                //Position pSouth = new Position(current.Item1.Level, current.Item1.Row + 1, current.Item1.Col);
                if (current.Item1.Row < r - 1 && labyrinth[current.Item1.Level, current.Item1.Row + 1, current.Item1.Col] != Unpassable)
                {
                    queue.Enqueue(new Tuple<Position, int>(p, current.Item2 + 1));
                }

                labyrinth[current.Item1.Level, current.Item1.Row, current.Item1.Col] = Unpassable;
            }

            return 0;
        }

        static void Main(string[] args)
        {
            ProccessInput();
            visited = new HashSet<Position>();
            Console.WriteLine(BFS());
        }

        static void ProccessInput()
        {
            string[] first = Console.ReadLine().Split(' ');
            x = int.Parse(first[0]);
            y = int.Parse(first[1]);
            z = int.Parse(first[2]);

            string[] second = Console.ReadLine().Split(' ');
            l = int.Parse(second[0]);
            r = int.Parse(second[1]);
            c = int.Parse(second[2]);

            labyrinth = new char[l, r, c];
            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < r; j++)
                {
                    string line = Console.ReadLine();
                    for (int k = 0; k < c; k++)
                    {
                        labyrinth[i, j, k] = line[k];
                    }
                }
            }
        }
    }
}
