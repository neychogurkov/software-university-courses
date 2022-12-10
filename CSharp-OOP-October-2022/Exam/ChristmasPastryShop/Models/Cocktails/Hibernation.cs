namespace ChristmasPastryShop.Models.Cocktails
{
    public class Hibernation : Cocktail
    {
        private const double DEFAULT_PRICE = 10.5;

        public Hibernation(string name, string size) 
            : base(name, size, DEFAULT_PRICE)
        {
        }
    }
}
