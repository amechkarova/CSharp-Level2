

using System.Collections.Generic;

namespace WordOccurrencesInFile
{
    public class Program
    {
        static Dictionary<string, int> wordsToFind = new Dictionary<string, int>();
        static void Main(string[] args)
        {
            try
            {
                string words = "../../words.txt";
                string test = "../../test.txt";
                string occurrences = "../../occurrences.txt";
                GetWords(words);
                CountOccurrences(test, occurrences);
                WriteWordOccurencesToFile(occurrences);
            }
            catch (FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (DirectoryNotFoundException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            catch (FileLoadException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            catch (DriveNotFoundException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            catch (EndOfStreamException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
            catch (PathTooLongException ex)
            {
                Console.Error.WriteLine(ex.Message);
            }
        }

        private static void WriteWordOccurencesToFile(string occurrences)
        {
            using (StreamWriter sWriter = new StreamWriter(occurrences))
            {
                foreach(var word in wordsToFind)
                {
                    sWriter.WriteLine(word.Key + ": " + word.Value + " times.");
                }
            }

        }

        private static void CountOccurrences(string test, string occurrences)
        {
                using (StreamReader sReader = new StreamReader(test))
                {
                    while(!sReader.EndOfStream)
                    {
                        string line = sReader.ReadLine();
                        for (int i = 0; i < wordsToFind.Count; i++)
                        {
                            KeyValuePair<string, int> word = wordsToFind.ElementAt(i);
                            if (line.Contains(word.Key))
                            {
                                wordsToFind[word.Key]++;
                            }
                        }
                    }
                }
            wordsToFind.OrderByDescending(word => word.Value);
        }

        private static void GetWords(string wordsFile)
        {
            using (StreamReader sReader = new StreamReader(wordsFile))
            {
                while (!sReader.EndOfStream)
                {
                    string line = sReader.ReadLine();
                    string[] words = line.Split(new char[] { ' ', ',', '\n' });
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (!wordsToFind.ContainsKey(words[i]))
                        {
                            wordsToFind.Add(words[i], 0);
                        }
                    }
                }
            }
        }
    }
}
