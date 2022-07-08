using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;

namespace _03.MOBAChallenger
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> players =
                new Dictionary<string, Dictionary<string, int>>();

            string[] delimiters = { " -> ", " vs " };

            while (true)
            {
                string[] command = Console.ReadLine().Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                if (command[0] == "Season end")
                {
                    break;
                }

                if (command.Length == 3)
                {
                    string playerName = command[0];
                    string position = command[1];
                    int skill = int.Parse(command[2]);

                    if (players.ContainsKey(playerName))
                    {
                        if (players[playerName].ContainsKey(position))
                        {
                            if (players[playerName][position] < skill)
                            {
                                players[playerName][position] = skill;
                            }
                        }
                        else
                        {
                            players[playerName].Add(position, skill);
                        }
                    }
                    else
                    {
                        players[playerName] = new Dictionary<string, int>() { { position, skill } };
                    }
                }
                else
                {
                    string firstPlayerName = command[0];
                    string secondPlayerName = command[1];

                    if (players.ContainsKey(firstPlayerName) && players.ContainsKey(secondPlayerName))
                    {
                        if (CheckIfPlayersHavePositionInCommon(players[firstPlayerName], players[secondPlayerName]))
                        {
                            int firstPlayerTotalSkillPoints = players[firstPlayerName].Values.Sum();
                            int secondPlayerTotalSkillPoints = players[secondPlayerName].Values.Sum();

                            if (firstPlayerTotalSkillPoints > secondPlayerTotalSkillPoints)
                            {
                                players.Remove(secondPlayerName);
                            }
                            else if (secondPlayerTotalSkillPoints > firstPlayerTotalSkillPoints)
                            {
                                players.Remove(firstPlayerName);
                            }
                        }
                    }
                }
            }

            foreach (var player in players.OrderByDescending(p => p.Value.Values.Sum()).ThenBy(p => p.Key))
            {
                Console.WriteLine($"{player.Key}: {player.Value.Values.Sum()} skill");

                foreach (var kvp in player.Value.OrderByDescending(p => p.Value).ThenBy(p => p.Key))
                {
                    Console.WriteLine($"- {kvp.Key} <::> {kvp.Value}");
                }
            }
        }

        static bool CheckIfPlayersHavePositionInCommon(Dictionary<string, int> firstPlayerSkills, Dictionary<string, int> secondPlayerSkills)
        {
            foreach (var firstPlayerPosition in firstPlayerSkills)
            {
                foreach (var secondPlayerPosition in secondPlayerSkills)
                {
                    if (firstPlayerPosition.Key == secondPlayerPosition.Key)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
