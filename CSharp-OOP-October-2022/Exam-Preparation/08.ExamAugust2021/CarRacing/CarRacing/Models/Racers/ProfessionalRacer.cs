namespace CarRacing.Models.Racers
{
    using Cars.Contracts;

    public class ProfessionalRacer : Racer
    {
        private const string DEFAULT_RACING_BEHAVIOR = "strict";
        private const int DEFAULT_DRIVING_EXPERIENCE = 30;

        public ProfessionalRacer(string username, ICar car)
            : base(username, DEFAULT_RACING_BEHAVIOR, DEFAULT_DRIVING_EXPERIENCE, car)
        {
        }

        public override void Race()
        {
            base.Race();
            this.DrivingExperience += 10;
        }
    }
}
