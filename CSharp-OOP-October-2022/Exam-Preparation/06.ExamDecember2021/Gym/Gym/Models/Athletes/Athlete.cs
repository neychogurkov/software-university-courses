namespace Gym.Models.Athletes
{
    using System;

    using Contracts;
    using Utilities.Messages;

    public abstract class Athlete : IAthlete
    {
        private string fullName;
        private string motivation;
        private int numberOfMedals;

        public Athlete(string fullName, string motivation, int numberOfMedals, int stamina)
        {
            this.FullName = fullName;
            this.Motivation = motivation;
            this.NumberOfMedals = numberOfMedals;
            this.Stamina = stamina;
        }

        public string FullName
        {
            get { return this.fullName; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteName);
                }

                this.fullName = value;
            }
        }

        public string Motivation
        {
            get { return this.motivation; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMotivation);
                }

                this.motivation = value;
            }
        }

        public int Stamina { get; protected set; }

        public int NumberOfMedals
        {
            get { return this.numberOfMedals; }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException(ExceptionMessages.InvalidAthleteMedals);
                }

                this.numberOfMedals = value;
            }
        }

        public abstract void Exercise();
    }
}
