using System;
using System.Collections.Generic;
using System.Linq;

namespace _05.FootballTeamGenerator
{
    internal class Team
    {
        private string name;
        private List<Player> players;

        public Team(string name)
        {
            this.players = new List<Player>();
            this.Name = name;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("A name should not be empty.");
                }

                this.name = value;
            }
        }
        public int Rating => this.CalculateRating();

        public void AddPlayer(Player player)
        {
            this.players.Add(player);
        }
        public void RemovePlayer(string playerName)
        {
            Player player = this.players.Find(p => p.Name == playerName);

            if (player == null)
            {
                Console.WriteLine($"Player {playerName} is not in {this.Name} team.");
                return;
            }

            this.players.Remove(player);
        }
        private int CalculateRating()
        {
            double totalSkill = players.Sum(p => (double)(p.Endurance + p.Sprint + p.Dribble + p.Passing + p.Shooting) / 5);
            return (int)Math.Round(totalSkill);
        }
    }
}
