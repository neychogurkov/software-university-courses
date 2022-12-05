namespace Gym.Models.Gyms
{
    public class BoxingGym : Gym
    {
        private const int DEFAULT_CAPACITY = 15;

        public BoxingGym(string name) 
            : base(name, DEFAULT_CAPACITY)
        {
        }
    }
}
