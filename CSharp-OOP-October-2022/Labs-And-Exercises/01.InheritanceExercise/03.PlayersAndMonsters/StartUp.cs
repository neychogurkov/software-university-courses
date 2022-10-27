using System.Collections.Generic;
using System;

namespace PlayersAndMonsters
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<Hero> heroes = new List<Hero>();

            Elf elf = new Elf("Elf", 3);
            heroes.Add(elf);
            MuseElf museElf = new MuseElf("Muse Elf", 5);
            heroes.Add(museElf);
            Wizard wizard = new Wizard("Wizard", 1);
            heroes.Add(wizard);
            DarkWizard darkWizard = new DarkWizard("Dark Wizard", 4);
            heroes.Add(darkWizard);
            SoulMaster soulMaster = new SoulMaster("Soul Master", 10);
            heroes.Add(soulMaster);
            Knight knight = new Knight("Knight", 2);
            heroes.Add(knight);
            DarkKnight darkKnight = new DarkKnight("Dark Knight", 8);
            heroes.Add(darkKnight);
            BladeKnight bladeKnight = new BladeKnight("Blade Knight", 9);
            heroes.Add(bladeKnight);

            foreach (Hero hero in heroes)
            {
                Console.WriteLine(hero.ToString());
            }
        }
    }
}