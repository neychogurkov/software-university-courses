using System;
using System.Collections.Generic;
using System.Linq;

namespace _03.Songs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfSongs = int.Parse(Console.ReadLine());
            List<Song> songs = new List<Song>();

            for (int i = 0; i < numberOfSongs; i++)
            {
                string[] songData = Console.ReadLine().Split('_');
                string songType = songData[0];
                string songName = songData[1];
                string songTime = songData[2];

                Song song = new Song(songType, songName, songTime);
                songs.Add(song);
            }

            string type = Console.ReadLine();

            if (type != "all")
            {
                songs = songs.Where(s => s.Type == type).ToList();
            }

            foreach (var song in songs)
            {
                Console.WriteLine(song.Name);
            }

        }
    }

    class Song
    {
        public string Type { get; set; }

        public string Name { get; set; }

        public string Time { get; set; }

        public Song(string type, string name, string time)
        {
            Type = type;
            Name = name;
            Time = time;
        }

    }
}
