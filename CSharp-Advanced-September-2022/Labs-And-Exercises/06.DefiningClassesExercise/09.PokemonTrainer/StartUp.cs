using System;
using System.Collections.Generic;
using System.Linq;

namespace DefiningClasses
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<string, Trainer> trainers = GetTrainersInfo();

            ModifyPokemonsOfTrainers(trainers);

            foreach (var trainer in trainers.OrderByDescending(t => t.Value.Badges))
            {
                Console.WriteLine(trainer.Value);
            }
        }

        private static void ModifyPokemonsOfTrainers(Dictionary<string, Trainer> trainers)
        {
            while (true)
            {
                string element = Console.ReadLine();

                if (element == "End")
                {
                    break;
                }

                foreach (var trainer in trainers)
                {
                    if (trainer.Value.Pokemons.Any(p => p.Element == element))
                    {
                        trainer.Value.Badges++;
                    }
                    else
                    {
                        trainer.Value.Pokemons.ForEach(p => p.Health -= 10);
                        trainer.Value.Pokemons.RemoveAll(p => p.Health <= 0);
                    }
                }
            }
        }

        private static Dictionary<string, Trainer> GetTrainersInfo()
        {
            Dictionary<string, Trainer> trainers = new Dictionary<string, Trainer>();

            while (true)
            {
                string[] command = Console.ReadLine().Split();

                if (command[0] == "Tournament")
                {
                    break;
                }

                string trainerName = command[0];
                string pokemonName = command[1];
                string pokemonElement = command[2];
                int pokemonHealth = int.Parse(command[3]);

                if (!trainers.ContainsKey(trainerName))
                {
                    trainers[trainerName] = new Trainer(trainerName);
                }

                trainers[trainerName].Pokemons.Add(new Pokemon(pokemonName, pokemonElement, pokemonHealth));
            }

            return trainers;
        }
    }
}
