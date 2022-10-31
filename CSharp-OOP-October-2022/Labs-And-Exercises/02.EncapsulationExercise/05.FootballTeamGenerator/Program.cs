using System;
using System.Collections.Generic;

namespace _05.FootballTeamGenerator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Team> teams = new List<Team>();

            while (true)
            {
                string[] teamInfo = Console.ReadLine().Split(';');

                if (teamInfo[0] == "END")
                {
                    break;
                }

                string action = teamInfo[0];
                string teamName = teamInfo[1];
                Team team = teams.Find(t => t.Name == teamName);

                if (action != "Team" && team == null)
                {
                    Console.WriteLine($"Team {teamName} does not exist.");
                    continue;
                }

                try
                {
                    switch (action)
                    {
                        case "Team":
                            teams.Add(new Team(teamName));
                            break;
                        case "Add":
                            {
                                string playerName = teamInfo[2];
                                int endurance = int.Parse(teamInfo[3]);
                                int sprint = int.Parse(teamInfo[4]);
                                int dribble = int.Parse(teamInfo[5]);
                                int passing = int.Parse(teamInfo[6]);
                                int shooting = int.Parse(teamInfo[7]);

                                Player player = new Player(playerName, endurance, sprint, dribble, passing, shooting);
                                team.AddPlayer(player);
                                break;
                            }
                        case "Remove":
                            {
                                string playerName = teamInfo[2];
                                team.RemovePlayer(playerName);
                                break;
                            }
                        case "Rating":
                            Console.WriteLine($"{team.Name} - {team.Rating}");
                            break;
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}
