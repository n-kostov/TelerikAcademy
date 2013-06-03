using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallInCuboid
{
    class Program
    {
        static void Main(string[] args)
        {
            /// w h d
            /// w d h   could be
            // d w h    formatexception
            // d h w    formatexception
            // h d w
            // h w d

            string firstLine = Console.ReadLine();
            string[] first = firstLine.Split(' ');
            int d = int.Parse(first[0]);
            int h = int.Parse(first[1]);
            int w = int.Parse(first[2]);

            //string[] example = { "(S L)(E)(S L) | (S L)(S R)(S L) | (B)(S F)(S L)", "(S B)(S F)(E) | (S B)(S F)(T 1 1) | (S L)(S R)(B)", "(S FL)(S FL)(S FR) | (S FL)(S FL)(S FR) | (S F)(S BR)(S FR)" };
            string[] example = new string[d];
            for (int i = 0; i < d; i++)
            {
                example[i] = Console.ReadLine();
            }
            string[, ,] grid = new string[d, h, w];
            for (int i = 0; i < example.Length; i++)    // d
            {
                char[] str = { '|' };
                string[] line = example[i].Split(str, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < line.Length; j++)   //  h
                {
                    char[] delims = { '(', ')' };
                    string[] commands = line[j].Trim().Split(delims, StringSplitOptions.RemoveEmptyEntries);
                    for (int k = 0; k < commands.Length; k++)   // w
                    {
                        grid[example.Length - 1 - i, j, k] = commands[k];
                    }
                }
            }

            string ball = Console.ReadLine();
            string[] balls = ball.Split(' ');
            int ballRow = int.Parse(balls[1]);
            int ballCol = int.Parse(balls[0]);

            bool foundPath = false;
            int currentD = d - 1;
            int currentH = ballRow;
            int currentW = ballCol;


            while (true)
            {
                if (grid[currentD, currentH, currentW] == "B")
                {
                    foundPath = false;
                    break;
                }
                else if (grid[currentD, currentH, currentW] == "E")
                {
                    if (currentD > 0)
                    {
                        currentD--;
                    }
                    else
                    {
                        foundPath = true;
                        break;
                    }

                }
                else if (grid[currentD, currentH, currentW][0] == 'T')
                {
                    string[] pars = grid[currentD, currentH, currentW].Split(' ');
                    currentH = int.Parse(pars[1]);
                    currentW = int.Parse(pars[2]);
                }
                else
                {
                    if (currentD == 0)
                    {
                        foundPath = true;
                        break;
                    }
                    string sl = grid[currentD, currentH, currentW].Substring(2);

                    if (sl == "L")
                        currentW--;
                    else if (sl == "R")
                        currentW++;
                    else if (sl == "F")
                        currentH--;
                    else if (sl == "B")
                        currentH++;
                    else if (sl == "FL")
                    {
                        currentW--;
                        currentH--;
                    }
                    else if (sl == "FR")
                    {
                        currentW++;
                        currentH--;
                    }
                    else if (sl == "BL")
                    {
                        currentW--;
                        currentH++;
                    }
                    else if (sl == "BR")
                    {
                        currentW++;
                        currentH++;
                    }
                    currentD--;
                    if (currentH > h - 1 || currentW > w - 1 || currentH < 0 || currentW < 0)
                    {
                        if (currentH > h - 1)
                        {
                            currentH--;
                        }
                        else if (currentH < 0)
                        {
                            currentH++;
                        }
                        else if (currentW < w - 1)
                        {
                            currentW--;
                        }
                        else if (currentW < 0)
                        {
                            currentW++;
                        }
                        foundPath = false;
                        break;
                    }

                }
            }
            if (foundPath)
            {
                Console.WriteLine("Yes");
                Console.WriteLine("{0} {1} {2}", currentW, d - currentD - 1, currentH);
            }
            else
            {
                Console.WriteLine("No");
                Console.WriteLine("{0} {1} {2}", currentW, d - currentD - 1, currentH);
            }

        }
    }
}
