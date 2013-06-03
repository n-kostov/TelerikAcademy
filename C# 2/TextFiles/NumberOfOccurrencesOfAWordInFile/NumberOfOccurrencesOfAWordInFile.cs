using System;
using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;

    class NumberOfOccurrencesOfAWordInFile
    {

        static List<string> FindWords(string fileName)
        {
            List<string> words = new List<string>();
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(fileName);
                while (!streamReader.EndOfStream)
                {
                    words.Add(streamReader.ReadLine());
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file {0} cannot be found", fileName);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The file {0} is not in this directory", fileName);
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("You gave too long path");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Cannot use null arguments");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("You cannot use blank path or special characters for a path");
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Dispose();
                }
            }
            return words;
        }

        static List<int> FindOccurrences(string fileName, List<string> words)
        {
            List<int> occurences = new List<int>();
            StreamReader streamReader = null;
            try
            {
                streamReader = new StreamReader(fileName);
                string text = streamReader.ReadToEnd();
                foreach (var item in words)
                {
                    string pattern = string.Format(@"\b{0}\b", item);
                    Regex regex = new Regex(pattern);
                    occurences.Add(regex.Split(text).Length - 1);
                }
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The file {0} cannot be found", fileName);
            }
            catch (DirectoryNotFoundException)
            {
                Console.WriteLine("The file {0} is not in this directory", fileName);
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("You gave too long path");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Cannot use null arguments");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("You cannot use blank path or special characters for a path");
            }
            finally
            {
                if (streamReader != null)
                {
                    streamReader.Dispose();
                }
            }
            return occurences;
        }

        static void WriteResult(string fileName, List<int> occurrences, List<string> words)
        {
            StreamWriter streamWriter = null;
            try
            {
                streamWriter = new StreamWriter(fileName);
                while (occurrences.Count > 0)
                {
                    // finds the index of the greatest occurrence
                    int max = 0;
                    for (int i = 1; i < occurrences.Count; i++)
                    {
                        if (occurrences[i] > occurrences[max])
                        {
                            max = i;
                        }
                    }
                    streamWriter.WriteLine("{0} - {1}", words[max], occurrences[max]);
                    // now remove max index so other cycle other index will be max
                    words.RemoveAt(max);
                    occurrences.RemoveAt(max);
                }
            }
            catch (PathTooLongException)
            {
                Console.WriteLine("You gave too long path");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("Cannot use null arguments");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("You cannot use blank path or special characters for a path");
            }
            finally
            {
                if (streamWriter != null)
                {
                    streamWriter.Dispose();
                }
            }
        }

        static void Main()
        {
            string wordsFileName = "words.txt";
            string fileName = "test.txt";
            List<string> words = FindWords(wordsFileName);
            List<int> occurrences = FindOccurrences(fileName, words);
            string resultFileName = "result.txt";
            WriteResult(resultFileName, occurrences, words);
        }
    }

