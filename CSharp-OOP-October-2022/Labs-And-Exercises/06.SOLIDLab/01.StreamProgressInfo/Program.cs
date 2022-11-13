namespace StreamProgress
{
    using System;

    public class Program
    {
        static void Main()
        {
            StreamProgressInfo music = new StreamProgressInfo(new Music("Chawki", "Time Of Our Lives", "Time Of Our Lives", 1024, 200));
            Console.WriteLine(music.CalculateCurrentPercent());

            StreamProgressInfo text = new StreamProgressInfo(new Text("text.txt", 100, 10));
            Console.WriteLine(text.CalculateCurrentPercent());
        }
    }
}
