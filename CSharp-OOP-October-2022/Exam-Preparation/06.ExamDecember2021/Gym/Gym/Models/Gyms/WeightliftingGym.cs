namespace Gym.Models.Gyms
{
    public class WeightliftingGym : Gym
    {
        private const int DEFAULT_CAPACITY = 20;

        public WeightliftingGym(string name)
            : base(name, DEFAULT_CAPACITY)
        {
        }
    }
}
