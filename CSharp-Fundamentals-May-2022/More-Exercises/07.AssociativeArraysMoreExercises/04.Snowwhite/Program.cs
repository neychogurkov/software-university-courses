using System;
using System.Collections.Generic;
using System.Linq;

namespace _04.Snowwhite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<Dwarf, int> dwarfs = new Dictionary<Dwarf, int>();
            Dictionary<string, int> colors = new Dictionary<string, int>();

            while (true)
            {
                string[] dwarfsInfo = Console.ReadLine().Split(" <:> ");

                if (dwarfsInfo[0] == "Once upon a time")
                {
                    break;
                }

                string dwarfName = dwarfsInfo[0];
                string dwarfHatColor = dwarfsInfo[1];
                int dwarfPhysics = int.Parse(dwarfsInfo[2]);


                if (dwarfs.Any(d => d.Key.Name == dwarfName && d.Key.HatColor == dwarfHatColor))
                {
                    Dwarf currentDwarf = dwarfs.Keys.FirstOrDefault(d => d.Name == dwarfName && d.HatColor == dwarfHatColor);

                    if (dwarfs[currentDwarf] < dwarfPhysics)
                    {
                        dwarfs[currentDwarf] = dwarfPhysics;
                    }
                }
                else
                {
                    Dwarf dwarf = new Dwarf(dwarfName, dwarfHatColor);
                    dwarfs[dwarf] = dwarfPhysics;
                }
            }

            foreach (var dwarf in dwarfs)
            {
                if (!colors.ContainsKey(dwarf.Key.HatColor))
                {
                    colors[dwarf.Key.HatColor] = 0;
                }

                colors[dwarf.Key.HatColor]++;
            }

            dwarfs = dwarfs
                .OrderByDescending(d => d.Value)
                .ThenByDescending(d => colors[d.Key.HatColor])
                .ToDictionary(d => d.Key, d => d.Value);

            foreach (var dwarf in dwarfs)
            {
                Console.WriteLine($"({dwarf.Key.HatColor}) {dwarf.Key.Name} <-> {dwarf.Value}");
            }
        }

        class Dwarf
        {
            public string Name { get; set; }
            public string HatColor { get; set; }

            public Dwarf(string name, string hatColor)
            {
                Name = name;
                HatColor = hatColor;
            }
        }
    }
}
