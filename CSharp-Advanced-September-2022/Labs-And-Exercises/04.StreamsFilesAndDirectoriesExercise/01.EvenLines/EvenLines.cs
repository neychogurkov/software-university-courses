namespace EvenLines
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class EvenLines
    {
        static void Main()
        {
            string inputFilePath = @"..\..\..\text.txt";

            Console.WriteLine(ProcessLines(inputFilePath));
        }

        public static string ProcessLines(string inputFilePath)
        {
            StringBuilder output = new StringBuilder();

            using (var reader = new StreamReader(inputFilePath))
            {
                int lineNumber = 0;

                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                     
                    if(lineNumber++ % 2 == 0)
                    {
                        output.AppendLine(string.Join(" ", line.Split().Reverse()));
                    }
                }
            }

            output.Replace('-', '@');
            output.Replace(',', '@');
            output.Replace('.', '@');
            output.Replace('!', '@');
            output.Replace('?', '@');

            return output.ToString();
        }
    }
}
