using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PHP_Variables
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
                if (line == "?>") break; // Last line
            }
            return inputData.ToString();
        }

        static void Main(string[] args)
        {
            //string example = "<?php\n$browser = $_SERVER['HTTP_USER_AGENT'] ;\n$arr = array();\n$arr[$zero] = $browser;\nvar_dump($arr);\n?>";
            //Console.WriteLine(example);
            string example = ReadInput();
            SortedSet<string> sortedSet = new SortedSet<string>();

            bool isMultiComment = false;
            string[] lines = example.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                bool isInString = false;
                char stringStartChar = '\0';
                for (int j = 0; j < lines[i].Length; j++)
                {
                    if (isMultiComment)
                    {
                        if (lines[i].IndexOf("*/") == -1)
                        {
                            break;
                        }
                        else
                        {
                            j = lines[i].IndexOf("*/") + 1;
                            isMultiComment = false;
                        }
                    }
                    else
                    {
                        if (lines[i][j] == '$')
                        {
                            int k = j + 1;
                            if (lines[i][k] == '_' || char.IsLetter(lines[i][k]))
                            {
                                k++;
                                while (lines[i][k] == '_' || char.IsLetterOrDigit(lines[i][k]))
                                {
                                    k++;
                                }
                                sortedSet.Add(lines[i].Substring(j + 1, k - j - 1));
                                j = k - 1;
                            }
                        }
                        else if (lines[i][j] == '#' && !isInString)
                        {
                            break;
                        }
                        else if (lines[i][j] == '/' && lines[i][j + 1] == '/' && !isInString)
                        {
                            break;
                        }
                        else if (!isInString && lines[i][j] == '/' && lines[i][j + 1] == '*')
                        {
                            isMultiComment = true;
                            j++;
                        }
                        else if (lines[i][j] == '\\')
                        {
                            j++;
                        }
                        else if (lines[i][j] == '"' || lines[i][j] == '\'')
                        {
                            if (stringStartChar != '\0' && stringStartChar == lines[i][j])
                            {
                                isInString = false;
                                stringStartChar = '\0';
                            } 
                            else
                            {
                                if (stringStartChar == '\0')
                                {
                                    stringStartChar = lines[i][j];
                                    isInString = true;
                                }
                            }

                        }
                    }
                }
            }
            Console.WriteLine(sortedSet.Count);
            foreach (var item in sortedSet)
            {
                Console.WriteLine(item);
            }
        }
    }
}
