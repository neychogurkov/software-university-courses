namespace CopyDirectory
{
    using System;
    using System.IO;

    public class CopyDirectory
    {
        static void Main()
        {
            string inputPath = @$"{Console.ReadLine()}";
            string outputPath = @$"{Console.ReadLine()}";

            CopyAllFiles(inputPath, outputPath);
        }

        public static void CopyAllFiles(string inputPath, string outputPath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(inputPath);

            var files = dirInfo.GetFiles("*", SearchOption.TopDirectoryOnly);
            var dirs = dirInfo.GetDirectories("*", SearchOption.TopDirectoryOnly);

            Directory.CreateDirectory(outputPath);

            foreach (var file in files)
            {
                File.Create($"{outputPath}\\{file.Name}");
            }

            foreach (var dir in dirs)
            {
                Directory.CreateDirectory($"{outputPath}\\{dir.Name}");
            }
        }
    }
}
