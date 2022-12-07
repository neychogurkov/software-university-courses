namespace CarRacing.Models.Maps
{
    using Contracts;
    using Racers.Contracts;
    using Utilities.Messages;

    public class Map : IMap
    {
        public string StartRace(IRacer racerOne, IRacer racerTwo)
        {
            if (!racerOne.IsAvailable() && !racerTwo.IsAvailable())
            {
                return OutputMessages.RaceCannotBeCompleted;
            }
            else if (!racerOne.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerTwo.Username, racerOne.Username);
            }
            else if (!racerTwo.IsAvailable())
            {
                return string.Format(OutputMessages.OneRacerIsNotAvailable, racerOne.Username, racerTwo.Username);
            }
            else
            {
                double racerOneChanceOfWinning = this.CalculateRacerChanceOfWinning(racerOne);
                double racerTwoChanceOfWinning = this.CalculateRacerChanceOfWinning(racerTwo);

                racerOne.Race();
                racerTwo.Race();

                IRacer winner = racerOneChanceOfWinning > racerTwoChanceOfWinning ? racerOne : racerTwo;

                return string.Format(OutputMessages.RacerWinsRace, racerOne.Username, racerTwo.Username, winner.Username);
            }
        }

        private double CalculateRacerChanceOfWinning(IRacer racer)
        {
            double racingBehaviorMultiplier = 0;

            if(racer.RacingBehavior == "strict")
            {
                racingBehaviorMultiplier = 1.2;
            }
            else if(racer.RacingBehavior == "aggressive")
            {
                racingBehaviorMultiplier = 1.1;
            }

            return racer.Car.HorsePower * racer.DrivingExperience * racingBehaviorMultiplier;
        }
    }
}
