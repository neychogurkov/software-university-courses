namespace MergeFiles
{
    using System;
    using System.IO;
    public class MergeFiles
    {
        static void Main()
        {
            var firstInputFilePath = @"..\..\..\Files\input1.txt";
            var secondInputFilePath = @"..\..\..\Files\input2.txt";
            var outputFilePath = @"..\..\..\Files\output.txt";

            MergeTextFiles(firstInputFilePath, secondInputFilePath, outputFilePath);
        }

        public static void MergeTextFiles(string firstInputFilePath, string secondInputFilePath, string outputFilePath)
        {
            using (var firstReader = new StreamReader(firstInputFilePath))
            {
                using (var secondReader = new StreamReader(secondInputFilePath))
                {
                    using (var writer = new StreamWriter(outputFilePath))
                    {
                        while (true)
                        {
                            string firstLine = firstReader.ReadLine();
                            string secondLine = secondReader.ReadLine();

                            if (firstLine == null && secondLine == null)
                            {
                                break;
                            }

                            if (firstLine != null)
                            {
                                writer.WriteLine(firstLine);
                            }
                            if (secondLine != null)
                            {
                                writer.WriteLine(secondLine);
                            }
                        }
                    }
                }
            }
        }
    }
}
