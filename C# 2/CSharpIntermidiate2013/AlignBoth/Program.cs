using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlignBoth
{
    class Program
    {
        static void Main(string[] args)
        {
            short n = short.Parse(Console.ReadLine());
            short w = short.Parse(Console.ReadLine());
            string[] lines = new string[n];
            List<string> words = new List<string>();
            char[] delims = { ' ' };
            for (int i = 0; i < n; i++)
            {
                lines[i] = Console.ReadLine();
                string[] lineWords = lines[i].Split(delims, StringSplitOptions.RemoveEmptyEntries);
                for (int j = 0; j < lineWords.Length; j++)
                {
                    words.Add(lineWords[j]);
                }
            }

            
            for (int i = 0; i < words.Count; i++)
            {
                int count = 1;
                int currentWidth = 0;
                int whitespaces = 0;
                Console.Write(words[i]);
                currentWidth += words[i].Length;
                if (i < words.Count - 1 && currentWidth + words[i + 1].Length + 1 > w)
                {
                    Console.WriteLine();
                }
                else if (i >= words.Count - 1)
                {

                }
                else
                {
                    StringBuilder sb = new StringBuilder();
                    //whitespaces++;
                    i++;
                    //currentWidth += words[i].Length;
                    do
                    {
                        currentWidth += words[i].Length;
                        sb.Append(' ');
                        sb.Append(words[i]);
                        whitespaces++;
                        i++;
                        count++;
                    } while (i < words.Count && currentWidth + whitespaces + words[i].Length  < w) ;
                    //currentWidth -= words[i - 1].Length;
                    i--;
                    //i--;
                    whitespaces = w - currentWidth - count + 1;
                    //count--;
                    string line = sb.ToString();
                    int index = line.IndexOf(' ');
                    for (int j = i - count + 1; j < i; j++)
                    {
                        if (index == -1)
                        {

                        }
                        else
                        {
                            //if (whitespaces == 1)
                            //{
                            //    sb.Insert(index, ' ');
                            //    break;
                            //}
                            //else
                            //{
                                sb.Insert(index, new string(' ', (int)Math.Ceiling(whitespaces / (float)(i - j))));
                            //}

                            index = sb.ToString().IndexOf(' ', index + (int)Math.Ceiling(whitespaces / (float)(i - j)) + 1);
                        }
                        whitespaces -= (int)Math.Ceiling((whitespaces / (float)(i - j)));
                        if (whitespaces == 0)
                        {
                            break;
                        }

                    }
                    Console.WriteLine(sb);

                }
            }

        }
    }
}
