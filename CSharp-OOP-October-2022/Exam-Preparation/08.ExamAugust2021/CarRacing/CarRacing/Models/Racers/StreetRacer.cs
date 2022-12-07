namespace CarRacing.Models.Racers
{
    using Cars.Contracts;

    public class StreetRacer : Racer
    {
        private const string DEFAULT_RACING_BEHAVIOR = "aggressive";
        private const int DEFAULT_DRIVING_EXPERIENCE = 10;

        public StreetRacer(string username, ICar car)
            : base(username, DEFAULT_RACING_BEHAVIOR, DEFAULT_DRIVING_EXPERIENCE, car)
        {
        }

        public override void Race()
        {
            base.Race();
            this.DrivingExperience += 5;
        }
    }
}
