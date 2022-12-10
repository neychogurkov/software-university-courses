namespace ChristmasPastryShop.Models.Delicacies
{
    public class Stolen : Delicacy
    {
        private const double DEFAULT_PRICE = 3.5;
      
        public Stolen(string name) 
            : base(name, DEFAULT_PRICE)
        {
        }
    }
}
