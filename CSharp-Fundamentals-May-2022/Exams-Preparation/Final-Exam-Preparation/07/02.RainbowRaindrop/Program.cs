using System;
using System.Collections.Generic;
using System.Linq;

namespace _02.RainbowRaindrop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Raindrop> rainbowRaindrops = new List<Raindrop>();

            while (true)
            {
                string[] input = Console.ReadLine().Split();

                if (input[0] == "End")
                {
                    break;
                }

                if (input.Length == 4)
                {
                    double volume = double.Parse(input[0]);
                    int redColorValue = int.Parse(input[1]);
                    int greenColorValue = int.Parse(input[2]);
                    int blueColorValue = int.Parse(input[3]);

                    Raindrop raindrop = new Raindrop(volume, redColorValue, greenColorValue, blueColorValue);

                    if ((raindrop.RedColorValue > 200 && raindrop.GreenColorValue < 100 && raindrop.BlueColorValue < 100) ||
                        (raindrop.GreenColorValue > 200 && raindrop.RedColorValue < 100 && raindrop.BlueColorValue < 100) ||
                        (raindrop.BlueColorValue > 200 && raindrop.RedColorValue < 100 && raindrop.GreenColorValue < 100))
                    {
                        rainbowRaindrops.Add(raindrop);
                    }
                }
            }

            Console.WriteLine($"Rainbow Raindrops: {rainbowRaindrops.Count}");

            int index = 0;

            foreach (var rainbowRaindrop in rainbowRaindrops.OrderBy(r => r.Volume))
            {
                index++;

                Console.WriteLine($"{index}. V:{rainbowRaindrop.Volume:f2} -> R:{rainbowRaindrop.RedColorValue} G:{rainbowRaindrop.GreenColorValue} B:{rainbowRaindrop.BlueColorValue}");
            }
        }
    }

    class Raindrop
    {
        private int redColorValue;
        private int greenColorValue;
        private int blueColorValue;

        public double Volume { get; set; }

        public int RedColorValue
        {
            get
            {
                return redColorValue;
            }
            set
            {
                if (value < 0 || value > 255)
                {
                    value = 0;
                }

                redColorValue = value;
            } 

        }
        public int GreenColorValue
        {
            get
            {
                return greenColorValue;
            }
            set
            {
                if (value < 0 || value > 255)
                {
                    value = 0;
                }

                greenColorValue = value;
            }

        }
        public int BlueColorValue
        {
            get
            {
                return blueColorValue;
            }
            set
            {
                if (value < 0 || value > 255)
                {
                    value = 0;
                }

                blueColorValue = value;
            }

        }

        public Raindrop(double volume, int redColorValue, int greenColorValue, int blueColorValue)
        {
            Volume = volume;
            RedColorValue = redColorValue;
            GreenColorValue = greenColorValue;
            BlueColorValue = blueColorValue;
        }
    }
}
