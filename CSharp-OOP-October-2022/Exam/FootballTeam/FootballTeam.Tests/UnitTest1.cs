using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace FootballTeam.Tests
{
    public class Tests
    {
        private const string DEFAULT_NAME = "Barcelona";
        private const int DEFAULT_CAPACITY = 20;

        private FootballTeam team;

        [SetUp]
        public void Setup()
        {
            team = new FootballTeam(DEFAULT_NAME, DEFAULT_CAPACITY);
        }

        [Test]
        public void ConstructorShouldInitializeData()
        {
            Assert.AreEqual(DEFAULT_NAME, team.Name);
            Assert.AreEqual(DEFAULT_CAPACITY, team.Capacity);
            Assert.IsNotNull(team.Players);
        }

        [TestCase("")]
        [TestCase(null)]
        public void NameSetterShouldThrowExceptionIfNameIsNullOrEmpty(string name)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team = new FootballTeam(name, DEFAULT_CAPACITY);
            });
        }

        [TestCase(14)]
        [TestCase(0)]
        [TestCase(-5)]
        public void CapacitySetterShouldThrowExceptionIfCapacityIsLessThan15(int capacity)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                FootballTeam team = new FootballTeam(DEFAULT_NAME, capacity);
            });
        }

        [Test]
        public void AddNewPlayersShouldAddPlayersToACollection()
        {
            List<FootballPlayer> players = new List<FootballPlayer>();
            for (int i = 1; i <= 5; i++)
            {
                FootballPlayer player = new FootballPlayer($"Player{i}", i * 3, "Forward");
                team.AddNewPlayer(player);
                players.Add(player);
            }

            CollectionAssert.AreEqual(players, team.Players);
        }

        [Test]
        public void AddNewPlayerShouldReturnCorrectMessage()
        {
            for (int i = 1; i <= DEFAULT_CAPACITY; i++)
            {
                FootballPlayer player = new FootballPlayer($"Player{i}", i, "Midfielder");

                string message = $"Added player {player.Name} in position {player.Position} with number {player.PlayerNumber}";
                Assert.AreEqual(message, team.AddNewPlayer(player));
            }

            string expectedMessage = "No more positions available!";
            Assert.AreEqual(expectedMessage, team.AddNewPlayer(new FootballPlayer("Player", 21, "Goalkeeper")));
        }

        [Test]
        public void PickPlayerShouldReturnTheCorrectPlayer()
        {
            List<FootballPlayer> players = new List<FootballPlayer>();
            for (int i = 1; i <= 5; i++)
            {
                FootballPlayer player = new FootballPlayer($"Player{i}", i * 3, "Forward");
                team.AddNewPlayer(player);
                players.Add(player);
            }
            FootballPlayer expectedPlayer = players[2];

            Assert.AreEqual(expectedPlayer, team.PickPlayer("Player3"));
        }

        [Test]
        public void PlayerScoreShouldIncreaseCountOfPlayerScoredGoals()
        {
            FootballPlayer player = new FootballPlayer("Messi", 10, "Forward");
            team.AddNewPlayer(player);

            int goals = 10;

            for (int i = 0; i < goals; i++)
            {
                team.PlayerScore(10);
            }

            string expectedMessage = $"{player.Name} scored and now has {goals + 1} for this season!";

            Assert.AreEqual(expectedMessage, team.PlayerScore(10));
        }
    }
}