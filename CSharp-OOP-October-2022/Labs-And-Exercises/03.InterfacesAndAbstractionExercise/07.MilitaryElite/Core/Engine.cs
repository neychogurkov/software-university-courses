namespace MilitaryElite.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Contracts;
    using IO.Contracts;
    using Models;
    using Models.Enums;
    using Models.Contracts;

    public class Engine : IEngine
    {
        private readonly IReader reader;
        private readonly IWriter writer;

        private readonly ICollection<ISoldier> soldiers;

        private Engine()
        {
            this.soldiers = new HashSet<ISoldier>();
        }

        public Engine(IReader reader, IWriter writer)
            : this()
        {
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            this.CreateSoldiers();
            this.PrintSoldiers();
        }

        private void CreateSoldiers()
        {
            string command;
            while ((command = this.reader.ReadLine()) != "End")
            {
                string[] soldierInfo = command.Split();

                string type = soldierInfo[0];
                int id = int.Parse(soldierInfo[1]);
                string firstName = soldierInfo[2];
                string lastName = soldierInfo[3];

                ISoldier soldier;
                if (type == "Private")
                {
                    decimal salary = decimal.Parse(soldierInfo[4]);
                    soldier = new Private(id, firstName, lastName, salary);
                }
                else if (type == "LieutenantGeneral")
                {
                    decimal salary = decimal.Parse(soldierInfo[4]);
                    ICollection<IPrivate> privates = this.GetPrivates(soldierInfo);

                    soldier = new LieutenantGeneral(id, firstName, lastName, salary, privates);
                }
                else if (type == "Engineer")
                {
                    decimal salary = decimal.Parse(soldierInfo[4]);
                    string corpsText = soldierInfo[5];
                    bool isCorpsValid = Enum.TryParse<Corps>(corpsText, false, out Corps corps);
                    if (!isCorpsValid)
                    {
                        continue;
                    }

                    ICollection<IRepair> repairs = this.GetRepairs(soldierInfo);
                    soldier = new Engineer(id, firstName, lastName, salary, corps, repairs);
                }
                else if (type == "Commando")
                {
                    decimal salary = decimal.Parse(soldierInfo[4]);
                    string corpsText = soldierInfo[5];
                    bool isCorpsValid = Enum.TryParse<Corps>(corpsText, false, out Corps corps);
                    if (!isCorpsValid)
                    {
                        continue;
                    }

                    ICollection<IMission> missions = this.GetMissions(soldierInfo);
                    soldier = new Commando(id, firstName, lastName, salary, corps, missions);
                }
                else if (type == "Spy")
                {
                    int codeNumber = int.Parse(soldierInfo[4]);
                    soldier = new Spy(id, firstName, lastName, codeNumber);
                }
                else
                {
                    continue;
                }

                this.soldiers.Add(soldier);
            }
        }

        private ICollection<IPrivate> GetPrivates(string[] soldierInfo)
        {
            int[] privatesIds = soldierInfo
                .Skip(5)
                .Select(int.Parse)
                .ToArray();

            ICollection<IPrivate> privates = new HashSet<IPrivate>();

            foreach (var privateId in privatesIds)
            {
                privates.Add((IPrivate)soldiers.FirstOrDefault(s => s.Id == privateId));
            }

            return privates;
        }

        private ICollection<IRepair> GetRepairs(string[] soldierInfo)
        {
            string[] repairsInfo = soldierInfo
                .Skip(6)
                .ToArray();

            ICollection<IRepair> repairs = new HashSet<IRepair>();

            for (int i = 0; i < repairsInfo.Length; i += 2)
            {
                string repairPart = repairsInfo[i];
                int repairHours = int.Parse(repairsInfo[i + 1]);

                repairs.Add(new Repair(repairPart, repairHours));
            }

            return repairs;
        }

        private ICollection<IMission> GetMissions(string[] soldierInfo)
        {
            string[] missionsInfo = soldierInfo
                .Skip(6)
                .ToArray();

            ICollection<IMission> missions = new HashSet<IMission>();

            for (int i = 0; i < missionsInfo.Length; i += 2)
            {
                string codeName = missionsInfo[i];
                string stateText = missionsInfo[i + 1];
                bool isStateValid = Enum.TryParse<State>(stateText, false, out State state);
                if (!isStateValid)
                {
                    continue;
                }

                missions.Add(new Mission(codeName, state));
            }

            return missions;
        }

        private void PrintSoldiers()
        {
            foreach (var soldier in this.soldiers)
            {
                this.writer.WriteLine(soldier.ToString());
            }
        }
    }
}
