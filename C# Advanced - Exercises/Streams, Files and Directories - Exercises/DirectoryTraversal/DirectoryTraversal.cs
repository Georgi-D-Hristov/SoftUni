namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            var reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static Dictionary<string, List<FileInfo>> TraverseDirectory(string inputFolderPath)
        {
            var reportInfo = new Dictionary<string, List<FileInfo>>();
            if (!Directory.Exists(inputFolderPath))
            {
                Console.WriteLine("Directory doesn`t exists.");
            }

            var folderInfo = Directory.GetFiles(inputFolderPath);
            foreach (var file in folderInfo)
            {
                var fileInfo = new FileInfo(file);
                var extension = fileInfo.Extension;
                var fileSize= fileInfo.Length;

                if (!reportInfo.ContainsKey(extension))
                {
                    reportInfo.Add(extension, new List<FileInfo>());
                }
                reportInfo[extension].Add(fileInfo);
            }

            return reportInfo;
        }

        public static void WriteReportToDesktop(Dictionary<string, List<FileInfo>> textContent, string reportFileName)
        {
            var path = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), reportFileName);
            using (StreamWriter writer = new StreamWriter(path))
            {
                throw new NotImplementedException();
            }
        }
    }
}
