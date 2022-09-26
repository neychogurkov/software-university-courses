namespace DirectoryTraversal
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class DirectoryTraversal
    {
        static void Main()
        {
            string path = Console.ReadLine();
            string reportFileName = @"\report.txt";

            string reportContent = TraverseDirectory(path);
            Console.WriteLine(reportContent);

            WriteReportToDesktop(reportContent, reportFileName);
        }

        public static string TraverseDirectory(string inputFolderPath)
        {
            Dictionary<string, Dictionary<string, decimal>> filesByExtension = new Dictionary<string, Dictionary<string, decimal>>();

            var dir = new DirectoryInfo(inputFolderPath);

            var files = dir.GetFiles("*", SearchOption.TopDirectoryOnly);

            foreach (var file in files)
            {
                string extension = file.Extension;
                string fileName = file.Name;
                decimal size = file.Length / 1000;

                if (!filesByExtension.ContainsKey(extension))
                {
                    filesByExtension[extension] = new Dictionary<string, decimal>();
                }

                filesByExtension[extension][fileName] = size;
            }

            StringBuilder output = new StringBuilder();

            foreach (var (extension, fileInfo) in filesByExtension.OrderByDescending(e => e.Value.Count).ThenBy(e => e.Key))
            {
                output.AppendLine(extension);

                foreach (var (fileName, fileSize) in fileInfo.OrderBy(f => f.Value))
                {
                    output.AppendLine($"--{fileName} - {fileSize}kb");
                }
            }

            return output.ToString();
        }

        public static void WriteReportToDesktop(string textContent, string reportFileName)
        {
            File.WriteAllText(reportFileName, textContent);
        }
    }
}
