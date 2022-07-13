using System;

namespace _03.ExtractFile
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string filePath = Console.ReadLine();
            string[] fileNameAndExtension = filePath.Substring(filePath.LastIndexOf('\\') + 1).Split('.');
            string fileName = fileNameAndExtension[0];
            string fileExtension = fileNameAndExtension[1];
            
            Console.WriteLine($"File name: {fileName}");
            Console.WriteLine($"File extension: {fileExtension}");
        }
    }
}
