namespace ChristmasPastryShop.Models.Delicacies
{
    public class Gingerbread : Delicacy
    {
        private const double DEFAULT_PRICE = 4;

        public Gingerbread(string name) 
            : base(name, DEFAULT_PRICE)
        {
        }
    }
}
