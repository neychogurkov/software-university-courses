namespace Raiding.Core
{
    using System;
    using System.Collections.Generic;

    using Contracts;
    using Factories.Contracts;
    using IO.Contracts;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly IHeroFactory heroFactory;

        private readonly ICollection<IBaseHero> heroes;

        private Engine()
        {
            this.heroes = new HashSet<IBaseHero>();
        }

        public Engine(IReader reader, IWriter writer, IHeroFactory heroFactory)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
            this.heroFactory = heroFactory;
        }

        public void Run()
        {
            this.CreateAllHeroes();
            this.FightBoss();
        }

        private void CreateAllHeroes()
        {
            int heroesCount = int.Parse(Console.ReadLine()); ;

            for (int i = 0; i < heroesCount; i++)
            {
                IBaseHero hero = this.CreateHeroUsingFactory();

                if (hero == null)
                {
                    this.writer.WriteLine("Invalid hero!");
                    i--;
                    continue;
                }

                this.heroes.Add(hero);
            }
        }

        private IBaseHero CreateHeroUsingFactory()
        {
            string name = this.reader.ReadLine();
            string type = this.reader.ReadLine();

            IBaseHero hero = this.heroFactory.CreateHero(type, name);
            return hero;
        }

        private void FightBoss()
        {
            int bossPower = int.Parse(this.reader.ReadLine());

            foreach (var hero in this.heroes)
            {
                this.writer.WriteLine(hero.CastAbility());
                bossPower -= hero.Power;
            }

            this.writer.WriteLine(bossPower <= 0
                ? "Victory!"
                : "Defeat...");
        }
    }
}
