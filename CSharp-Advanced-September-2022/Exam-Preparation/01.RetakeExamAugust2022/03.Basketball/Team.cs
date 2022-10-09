using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        public List<Player> Players { get; set; }
        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public int Count => this.Players.Count;

        public Team(string name, int openPositions, char group)
        {
            this.Players = new List<Player>();
            this.Name = name;
            this.OpenPositions = openPositions;
            this.Group = group;
        }

        public string AddPlayer(Player player)
        {
            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }
            if (this.OpenPositions == 0)
            {
                return "There are no more open positions.";
            }
            if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }

            this.OpenPositions--;
            this.Players.Add(player);
            return $"Successfully added {player.Name} to the team. Remaining open positions: {this.OpenPositions}.";
        }

        public bool RemovePlayer(string name)
        {
            Player playerToRemove = this.Players.Find(p => p.Name == name);

            if (playerToRemove != null)
            {
                this.Players.Remove(playerToRemove);
                this.OpenPositions++;
            }

            return playerToRemove != null;
        }

        public int RemovePlayerByPosition(string position)
        {
            int countOfRemovedPlayers = this.Players.RemoveAll(p => p.Position == position);
            this.OpenPositions += countOfRemovedPlayers;

            return countOfRemovedPlayers;
        }

        public Player RetirePlayer(string name)
        {
            Player player = this.Players.Find(p => p.Name == name);

            if (player != null)
            {
                player.Retired = true;
            }

            return player;
        }

        public List<Player> AwardPlayers(int games)
        {
            return this.Players.Where(p => p.Games >= games).ToList();
        }

        public string Report()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Active players competing for Team {this.Name} from Group {this.Group}:");

            foreach (Player player in this.Players.Where(p => !p.Retired))
            {
                sb.AppendLine(player.ToString());
            }

            return sb.ToString().TrimEnd();
        }
    }
}
