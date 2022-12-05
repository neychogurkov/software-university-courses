namespace Gym.Models.Athletes
{
    using System;

    using Utilities.Messages;

    public class Weightlifter : Athlete
    {
        private const int DEFAULT_STAMINA = 50;

        public Weightlifter(string fullName, string motivation, int numberOfMedals)
            : base(fullName, motivation, numberOfMedals, DEFAULT_STAMINA)
        {
        }

        public override void Exercise()
        {
            this.Stamina += 10;

            if (this.Stamina > 100)
            {
                this.Stamina = 100;

                throw new ArgumentException(ExceptionMessages.InvalidStamina);
            }
        }
    }
}
