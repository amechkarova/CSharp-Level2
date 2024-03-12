using System.Text.RegularExpressions;

namespace WorkingWithFiles
{
    internal class Program
    { 
        static void Main(string[] args)
        {
            string filePath = "C:\\Users\\Anelia Mechkarova\\source\\repos\\amechkarova\\CSharp-Level2\\WorkingWithFiles\\OddLines.txt";

            using (StreamReader sReader = new StreamReader(filePath))
            {
                int currentLine = 1;

                while (!sReader.EndOfStream)
                {
                    string line = sReader.ReadLine();

                    if (currentLine++ % 2 != 0)
                    {
                        Console.WriteLine(line);
                    }
                }
            }

            string firstFilePath = "../../firstFile.txt";
            string secondFilePath = "../../secondFile.txt";
            string resultFilePath = "../../resultFile.txt";

            ReadFiles(firstFilePath, resultFilePath);
            ReadFiles(secondFilePath, resultFilePath);
            PrintResult(resultFilePath);

            string fileWithoutLineNumbers = "../../fileWithoutLineNumbers.txt";
            string pathInsertedLinesResult = "../../InsertedLinesResult.txt";

            InsertLines(fileWithoutLineNumbers, pathInsertedLinesResult);
            PrintResult(pathInsertedLinesResult);

            CompareFiles(firstFilePath, secondFilePath);

            string testFile = "../../test.txt";
            string fileWithoutTest = "../../fileWithoutTest.txt";
            DeleteWordsWithPrefixTest(testFile, fileWithoutTest);
        }
        private static void ReadFiles(string filePath, string resultFile)
        {
            using (StreamWriter sWriter = new StreamWriter(resultFile, true))
            {
                using (StreamReader sReader = new StreamReader(filePath))
                {
                    while (!sReader.EndOfStream)
                    {
                        sWriter.WriteLine(sReader.ReadLine());
                    }
                }
            }
        }

        private static void PrintResult(string filePath)
        {
            using (StreamReader sReader = new StreamReader(filePath))
            {
                while (!sReader.EndOfStream)
                {
                    Console.WriteLine(sReader.ReadLine());
                }     
            }
        }

        private static void InsertLines(string filePath, string resultFile)
        {
            int lineCount = 1;

            using (StreamWriter sWriter = new StreamWriter(resultFile))
            {
                using (StreamReader sReader = new StreamReader(filePath))
                {
                    while (!sReader.EndOfStream)
                    {
                        sWriter.WriteLine($"{lineCount++}: {sReader.ReadLine()}");
                    }
                }
            }
        }

        private static void CompareFiles(string firstFile, string secondFile)
        {
            int numberOfSameLines = 0;
            int numberOfDifferentLines = 0;
            using (StreamReader sReader1 = new StreamReader(firstFile))
            {
                using (StreamReader sReader2 = new StreamReader(secondFile))
                {
                    while (!sReader1.EndOfStream || !sReader2.EndOfStream)
                    {
                        string line1 = sReader1.ReadLine();
                        string line2 = sReader2.ReadLine();

                        if (line1.CompareTo(line2) == 0)
                        {
                            numberOfSameLines++;
                        }
                        else
                        {
                            numberOfDifferentLines++;
                        }
                    }
                }
            }

            Console.WriteLine($"Same lines: {numberOfSameLines}");
            Console.WriteLine($"Different lines: {numberOfDifferentLines}");
        }

        private static void DeleteWordsWithPrefixTest(string file, string resultFile)
        {
            using (StreamWriter sWriter = new StreamWriter(resultFile))
            {
                using (StreamReader sReader = new StreamReader(file))
                {
                    while (!sReader.EndOfStream)
                    {
                        string line = Regex.Replace(sReader.ReadLine(), @"\btest\s+", String.Empty).Trim();
                        sWriter.Write(line + "\n");
                    }
                }
            }
        }
    }
}
