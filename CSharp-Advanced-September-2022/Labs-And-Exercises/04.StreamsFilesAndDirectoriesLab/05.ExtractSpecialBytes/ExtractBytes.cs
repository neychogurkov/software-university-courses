namespace ExtractBytes
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    public class ExtractBytes
    {
        static void Main()
        {
            string binaryFilePath = @"..\..\..\Files\example.png";
            string bytesFilePath = @"..\..\..\Files\bytes.txt";
            string outputPath = @"..\..\..\Files\output.bin";

            ExtractBytesFromBinaryFile(binaryFilePath, bytesFilePath, outputPath);
        }

        public static void ExtractBytesFromBinaryFile(string binaryFilePath, string bytesFilePath, string outputPath)
        {
            HashSet<byte> bytesToExtract = new HashSet<byte>();

            using (var reader = new StreamReader(bytesFilePath))
            {
                while (true)
                {
                    string line = reader.ReadLine();

                    if (line == null)
                    {
                        break;
                    }

                    bytesToExtract.Add(byte.Parse(line));
                }
            }

            using (var fin = new FileStream(binaryFilePath, FileMode.Open))
            {
                using (var fout = new FileStream(outputPath, FileMode.Create))
                {
                    byte[] buffer = new byte[1024];

                    while (true)
                    {
                        int bytesRead = fin.Read(buffer);

                        if (bytesRead == 0)
                        {
                            break;
                        }

                        for (int i = 0; i < bytesRead; i++)
                        {
                            if (bytesToExtract.Contains(buffer[i]))
                            {
                                fout.Write(buffer, i, 1);
                            }
                        }
                    }
                }
            }
        }
    }
}
