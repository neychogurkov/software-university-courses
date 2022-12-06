namespace SpaceStation.Models.Astronauts
{
    public class Geodesist : Astronaut
    {
        private const double DEFAULT_OXYGEN = 50;

        public Geodesist(string name) 
            : base(name, DEFAULT_OXYGEN)
        {
        }
    }
}
