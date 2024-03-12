using System.Text.RegularExpressions;

namespace RemoveWordsFromFile
{
    public class Program
    {
        static List<string> wordsToRemove = new List<string>();
        static void Main(string[] args)
        {
            try
            {
                string fileName = "../../text.txt";
                string wordsToRemoveFile = "../../wordsToRemove.txt";
                string fileWithRemovedWords = "../../fileWithRemovedWords.txt";

                GetWordsToRemove(wordsToRemoveFile);
                DeleteWords(fileName, fileWithRemovedWords);
            }
            catch (FileNotFoundException ex)
            {
                Console.Error.WriteLine(ex.Message);
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

        private static void DeleteWords(string fileName, string fileWithRemovedWords)
        {
            using (StreamWriter sWriter = new StreamWriter(fileWithRemovedWords))
            {
                using (StreamReader sReader = new StreamReader(fileName))
                {
                    while (!sReader.EndOfStream)
                    {
                        string line = sReader.ReadLine();
                        for (int i = 0; i < wordsToRemove.Count; i++)
                        {
                            line = Regex.Replace(line, $"\\b{wordsToRemove[i]}\\b", String.Empty).Trim();
                        }
                        sWriter.WriteLine(line);
                    }
                }
            }
        }

        private static void GetWordsToRemove(string wordsToRemoveFile)
        {
            using (StreamReader sReader = new StreamReader(wordsToRemoveFile))
            {
                while (!sReader.EndOfStream)
                {
                    string line = sReader.ReadLine();
                    string[] words = line.Split(new char[] { ' ', ',', '\n' });
                    for (int i = 0; i < words.Length; i++)
                    {
                        if (!wordsToRemove.Contains(words[i]))
                        {
                            wordsToRemove.Add(words[i]);
                        }
                    }
                }
            }
        }
    }
}
