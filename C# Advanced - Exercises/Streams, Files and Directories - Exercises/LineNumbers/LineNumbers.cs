using System.IO;
using System.Linq;

namespace LineNumbers
{
    using System;
    public class LineNumbers
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";
            string outputFilePath = @"..\..\..\output.txt";

            ProcessLines(inputFilePath, outputFilePath);
        }

        public static void ProcessLines(string inputFilePath, string outputFilePath)
        {
            var specialsSymbols = new char[] { '-', ',', '.', '!', '?', '\'', ':', ';' };

            var reader = new StreamReader(inputFilePath);
            using (reader)
            {
                var writer = new StreamWriter(outputFilePath);
                using (writer)
                {
                    var lineCount = 0;

                    while (!reader.EndOfStream)
                    {
                        lineCount++;

                        var line = reader.ReadLine();
                        var symbols = 0;
                        foreach (var sym in line)
                        {
                            if (Array.IndexOf(specialsSymbols, sym)!=-1)
                            {
                                symbols++;
                            }
                        }

                        var letters = line.Split(new char[] { '-', ',', '.', '!', '?', ' ', '\'', ';', ':' },
                            StringSplitOptions.RemoveEmptyEntries).Sum(x => x.Length);

                        writer.WriteLine($"Line {lineCount}: {line} ({letters})({symbols})");
                    }
                }

            }
        }
    }
}
