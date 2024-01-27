namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            var reader = new StreamReader(inputFilePath);
            var specialsSymbols = new char[] { '-', ',', '.', '!', '?' };
            string resultLine;

            using (reader)
            {
                var lineCount = 0;
                while (!reader.EndOfStream)
                {
                    if (lineCount%2==0)
                    {
                        var line = reader.ReadLine().Split('-', ',', '.', '!', '?');
                        resultLine=(string.Join("@",line));
                      var  result=resultLine.Split(" ").ToArray().Reverse();
                        
                        return string.Join(" ",result);
                    }

                    lineCount++;
                }
                
            }
            return "";
        }
    }
}
