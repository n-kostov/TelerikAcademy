using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Basic_Language
{
    class Program
    {

        static string ReadInput()
        {
            StringBuilder inputData = new StringBuilder();
            while (true)
            {
                string line = Console.ReadLine().Trim(); // optimization: trimming redundant whitespace characters 
                inputData.AppendLine(line);
                if (line.IndexOf("EXIT;") != -1)
                {
                    break;
                }
                // Last line
            }
            return inputData.ToString();
        }

        static void Main(string[] args)
        {
            string example = ReadInput();
            char[] arr = { ';' };
            string[] lines = example.Split(arr, StringSplitOptions.RemoveEmptyEntries);
            //bool isInFor = false;
            int n = 1;

            for (int i = 0; i < lines.Length; i++)
            {
                int prIndex = lines[i].IndexOf("PRINT", 0);
                int forIndex = lines[i].IndexOf("FOR", 0);
                if (prIndex == forIndex)    // -1
                {
                    break;
                }
                else
                {

                    while (prIndex != -1 && forIndex != -1)
                    {
                        if (prIndex < forIndex)
                        {
                            //if (isInFor)
                            //{
                            int leftBracket = lines[i].IndexOf('(', prIndex);
                            int rightBracket = lines[i].IndexOf(')', prIndex);
                            for (int j = 0; j < n; j++)
                            {
                                Console.Write(lines[i].Substring(leftBracket + 1, rightBracket - leftBracket - 1));
                            }
                            //isInFor = false;
                            n = 1;
                            //}
                            //else
                            //{
                            //    int leftBracket = lines[i].IndexOf('(', prIndex);
                            //    int rightBracket = lines[i].IndexOf(')', prIndex);
                            //    Console.Write(lines[i].Substring(leftBracket + 1, rightBracket - leftBracket - 1));
                            //}
                            prIndex = lines[i].IndexOf("PRINT", rightBracket);
                        }
                        else
                        {
                            //isInFor = true;
                            int leftBracket = lines[i].IndexOf('(', forIndex);
                            int rightBracket = lines[i].IndexOf(')', forIndex);
                            if (lines[i].Substring(leftBracket + 1, rightBracket - leftBracket - 1).Contains(','))
                            {
                                int delim = lines[i].IndexOf(',', forIndex);
                                n *= -int.Parse(lines[i].Substring(leftBracket + 1, delim - leftBracket - 1).Trim()) +
                                    int.Parse(lines[i].Substring(delim + 1, rightBracket - delim - 1).Trim()) + 1;
                            }
                            else
                            {
                                n *= int.Parse(lines[i].Substring(leftBracket + 1, rightBracket - leftBracket - 1).Trim());
                            }
                            forIndex = lines[i].IndexOf("FOR", forIndex + 1);
                        }
                    }

                    //if (prIndex == -1)
                    //{
                    //    while (forIndex != -1)
                    //    {
                    //        isInFor = true;
                    //        int leftBracket = lines[i].IndexOf('(');
                    //        int delim = lines[i].IndexOf(',', forIndex);
                    //        int rightBracket = lines[i].IndexOf(')', forIndex);
                    //        if (delim < rightBracket && delim != -1)
                    //        {
                    //            n *= int.Parse(lines[i].Substring(leftBracket + 1, delim - leftBracket).Trim()) +
                    //                int.Parse(lines[i].Substring(delim + 1, rightBracket - delim - 1).Trim());
                    //        }
                    //        else
                    //        {
                    //            n *= int.Parse(lines[i].Substring(leftBracket + 1, rightBracket - leftBracket - 1).Trim());
                    //        }
                    //        forIndex = lines[i].IndexOf("FOR", forIndex + 1);
                    //    }
                    //}

                    while (prIndex != -1)
                    {
                        //if (isInFor)
                        //{
                        int leftBracket = lines[i].IndexOf('(', prIndex);
                        int rightBracket = lines[i].IndexOf(')', prIndex);
                        if (rightBracket == -1)
                        {
                            StringBuilder sb = new StringBuilder();
                            sb.Append(lines[i].Substring(leftBracket + 1, lines[i].Length - leftBracket - 1));
                            sb.Append(';');
                            while( rightBracket == -1)
                            {
                                i++;
                                rightBracket = lines[i].IndexOf(')', prIndex);
                                if (rightBracket == -1)
                                {
                                    sb.Append(lines[i].Substring(leftBracket + 1, lines[i].Length  - leftBracket - 1));
                                    sb.Append(';');
                                } 
                                else
                                {
                                    if (rightBracket != 0)
                                    {
                                        sb.Append(lines[i].Substring(0, rightBracket - 1));
                                    }
                                }
                            }
                            Console.Write(sb);

                        }
                        else
                        {

                            for (int j = 0; j < n; j++)
                            {
                                Console.Write(lines[i].Substring(leftBracket + 1, rightBracket - leftBracket - 1));
                            }
                        }
                        //isInFor = false;
                        n = 1;
                        //}
                        //else
                        //{
                        //    int leftBracket = lines[i].IndexOf('(', prIndex);
                        //    int rightBracket = lines[i].IndexOf(')', prIndex);
                        //    Console.Write(lines[i].Substring(leftBracket + 1, rightBracket - leftBracket - 1));
                        //}
                        prIndex = lines[i].IndexOf("PRINT", rightBracket);
                    }

                }
            }
            Console.WriteLine();
        }
    }

}

