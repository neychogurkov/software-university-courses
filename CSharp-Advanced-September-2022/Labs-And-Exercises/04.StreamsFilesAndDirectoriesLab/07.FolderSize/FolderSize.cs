namespace FolderSize
{
    using System;
    using System.IO;
    public class FolderSize
    {
        static void Main(string[] args)
        {
            string folderPath = @"..\..\..\Files\TestFolder";
            string outputPath = @"..\..\..\Files\output.txt";

            GetFolderSize(folderPath, outputPath);
        }

        public static void GetFolderSize(string folderPath, string outputFilePath)
        {
            var dir = new DirectoryInfo(folderPath);
            var files = dir.GetFiles("*", SearchOption.AllDirectories);
            decimal folderSizeSum = 0;

            foreach (var file in files)
            {
                folderSizeSum += file.Length;
            }

            File.WriteAllText(outputFilePath, (folderSizeSum / 1024).ToString() + " KB");
        }
    }
}
