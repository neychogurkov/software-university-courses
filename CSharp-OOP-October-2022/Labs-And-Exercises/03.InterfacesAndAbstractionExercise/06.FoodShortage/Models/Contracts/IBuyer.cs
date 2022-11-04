namespace FoodShortage.Models.Contracts
{
    public interface IBuyer
    {
        string Name { get; set; }
        int Food { get; set; }
        void BuyFood();
    }
}
