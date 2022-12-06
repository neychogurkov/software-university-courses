namespace SpaceStation.Models.Astronauts
{
    public class Meteorologist : Astronaut
    {
        private const double DEFAULT_OXYGEN = 90;

        public Meteorologist(string name) 
            : base(name, DEFAULT_OXYGEN)
        {
        }
    }
}
