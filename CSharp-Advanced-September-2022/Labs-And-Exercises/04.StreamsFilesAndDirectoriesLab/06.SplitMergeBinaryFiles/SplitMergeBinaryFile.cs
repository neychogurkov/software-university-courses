namespace SplitMergeBinaryFile
{
    using System;
    using System.IO;
    using System.Linq;

    public class SplitMergeBinaryFile
    {
        static void Main()
        {
            string sourceFilePath = @"..\..\..\Files\example.png";
            string joinedFilePath = @"..\..\..\Files\example-joined.png";
            string partOnePath = @"..\..\..\Files\part-1.bin";
            string partTwoPath = @"..\..\..\Files\part-2.bin";

            SplitBinaryFile(sourceFilePath, partOnePath, partTwoPath);
            MergeBinaryFiles(partOnePath, partTwoPath, joinedFilePath);
        }

        public static void SplitBinaryFile(string sourceFilePath, string partOneFilePath, string partTwoFilePath)
        {
            byte[] bytes = File.ReadAllBytes(sourceFilePath);

            using (var foutOne = new FileStream(partOneFilePath, FileMode.Create))
            {
                using (var foutTwo = new FileStream(partTwoFilePath, FileMode.Create))
                {
                    if (bytes.Length % 2 == 0)
                    {
                        foutOne.Write(bytes, 0, bytes.Length / 2);
                        foutTwo.Write(bytes, bytes.Length / 2, bytes.Length / 2);
                    }
                    else
                    {
                        foutOne.Write(bytes, 0, bytes.Length / 2 + 1);
                        foutTwo.Write(bytes, bytes.Length / 2 + 1, bytes.Length / 2);
                    }
                }
            }
        }

        public static void MergeBinaryFiles(string partOneFilePath, string partTwoFilePath, string joinedFilePath)
        {
            using (var fs = new FileStream(joinedFilePath, FileMode.Create))
            {
                byte[] bytes = File.ReadAllBytes(partOneFilePath);
                fs.Write(bytes);
                bytes = File.ReadAllBytes(partTwoFilePath);
                fs.Write(bytes);
            }
        }
    }
}