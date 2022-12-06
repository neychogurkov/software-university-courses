namespace SpaceStation.Models.Astronauts
{
    public class Biologist : Astronaut
    {
        private const double DEFAULT_OXYGEN = 70;

        public Biologist(string name) 
            : base(name, DEFAULT_OXYGEN)
        {
        }

        public override void Breath()
        {
            this.Oxygen -= 5;

            if (this.Oxygen < 0)
            {
                this.Oxygen = 0;
            }
        }
    }
}
