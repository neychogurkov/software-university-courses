using System;
using System.Collections.Generic;
using System.Text;

namespace Guild
{
    public class Guild
    {
        private List<Player> roster;

        public Guild(string name, int capacity)
        {
            this.roster = new List<Player>();
            this.Name = name;
            this.Capacity = capacity;
        }

        public string Name { get; set; }
        public int Capacity { get; set; }
        public int Count => this.roster.Count;

        public void AddPlayer(Player player)
        {
            if (this.Count < this.Capacity)
            {
                this.roster.Add(player);
            }
        }

        public bool RemovePlayer(string name) => this.roster.Remove(this.roster.Find(p => p.Name == name));

        public void PromotePlayer(string name) => this.roster.Find(p => p.Name == name).Rank = "Member";

        public void DemotePlayer(string name) => this.roster.Find(p => p.Name == name).Rank = "Trial";

        public Player[] KickPlayersByClass(string @class)
        {
            Player[] players = this.roster.FindAll(p => p.Class == @class).ToArray();
            this.roster.RemoveAll(p => p.Class == @class);
            return players;
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"Players in the guild: {this.Name}");

            foreach (var player in this.roster)
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
