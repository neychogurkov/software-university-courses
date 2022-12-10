namespace ChristmasPastryShop.Core
{
    using System;
    using System.Linq;

    using Contracts;
    using Models.Booths.Contracts;
    using Models.Booths;
    using Models.Cocktails;
    using Models.Cocktails.Contracts;
    using Models.Delicacies;
    using Models.Delicacies.Contracts;
    using Repositories;
    using Repositories.Contracts;
    using Utilities.Messages;

    public class Controller : IController
    {
        private IRepository<IBooth> booths;

        public Controller()
        {
            this.booths = new BoothRepository();
        }

        public string AddBooth(int capacity)
        {
            int boothId = this.booths.Models.Count + 1;
            IBooth booth = new Booth(boothId, capacity);
            this.booths.AddModel(booth);

            return string.Format(OutputMessages.NewBoothAdded, boothId, capacity);
        }

        public string AddCocktail(int boothId, string cocktailTypeName, string cocktailName, string size)
        {
            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            ICocktail cocktail;
            if (cocktailTypeName == "MulledWine")
            {
                cocktail = new MulledWine(cocktailName, size);
            }
            else if (cocktailTypeName == "Hibernation")
            {
                cocktail = new Hibernation(cocktailName, size);
            }
            else
            {
                return string.Format(OutputMessages.InvalidCocktailType, cocktailTypeName);
            }

            if (size != "Large" && size != "Middle" && size != "Small")
            {
                return string.Format(OutputMessages.InvalidCocktailSize, size);
            }

            if (booth.CocktailMenu.Models.Any(c => c.Name == cocktailName && c.Size == size))
            {
                return string.Format(OutputMessages.CocktailAlreadyAdded, size, cocktailName);
            }

            booth.CocktailMenu.AddModel(cocktail);

            return string.Format(OutputMessages.NewCocktailAdded, size, cocktailName, cocktailTypeName);
        }

        public string AddDelicacy(int boothId, string delicacyTypeName, string delicacyName)
        {
            IDelicacy delicacy;
            if (delicacyTypeName == "Gingerbread")
            {
                delicacy = new Gingerbread(delicacyName);
            }
            else if (delicacyTypeName == "Stolen")
            {
                delicacy = new Stolen(delicacyName);
            }
            else
            {
                return string.Format(OutputMessages.InvalidDelicacyType, delicacyTypeName);
            }

            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            if (booth.DelicacyMenu.Models.Any(d => d.Name == delicacyName))
            {
                return string.Format(OutputMessages.DelicacyAlreadyAdded, delicacyName);
            }

            booth.DelicacyMenu.AddModel(delicacy);

            return string.Format(OutputMessages.NewDelicacyAdded, delicacyTypeName, delicacyName);
        }

        public string BoothReport(int boothId)
        {
            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            return booth.ToString();
        }

        public string LeaveBooth(int boothId)
        {
            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);
            double currentBill = booth.CurrentBill;
            booth.Charge();
            booth.ChangeStatus();

            return $"Bill {currentBill:f2} lv" + Environment.NewLine + $"Booth {boothId} is now available!";
        }

        public string ReserveBooth(int countOfPeople)
        {
            var boothsAvailable = this.booths.Models
                .Where(b => !b.IsReserved && b.Capacity >= countOfPeople)
                .OrderBy(b => b.Capacity)
                .ThenByDescending(b => b.BoothId)
                .ToList();

            if (boothsAvailable.Count == 0)
            {
                return string.Format(OutputMessages.NoAvailableBooth, countOfPeople);
            }

            IBooth booth = boothsAvailable.First();
            booth.ChangeStatus();

            return string.Format(OutputMessages.BoothReservedSuccessfully, booth.BoothId, countOfPeople);
        }

        public string TryOrder(int boothId, string order)
        {
            IBooth booth = this.booths.Models.FirstOrDefault(b => b.BoothId == boothId);

            string[] orderItems = order.Split('/');
            string itemTypeName = orderItems[0];
            string itemName = orderItems[1];
            int countOfOrderedPieces = int.Parse(orderItems[2]);

            if (itemTypeName == "Gingerbread" || itemTypeName == "Stolen")
            {
                IDelicacy delicacy = booth.DelicacyMenu.Models.FirstOrDefault(d => d.GetType().Name == itemTypeName && d.Name == itemName);

                if (delicacy == null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }

                booth.UpdateCurrentBill(delicacy.Price * countOfOrderedPieces);

                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfOrderedPieces, itemName);
            }
            else if (itemTypeName == "MulledWine" || itemTypeName == "Hibernation")
            {
                string size = orderItems[3];

                ICocktail cocktail = booth.CocktailMenu.Models.FirstOrDefault(c => c.GetType().Name == itemTypeName && c.Name == itemName);

                if (cocktail == null)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, itemTypeName, itemName);
                }

                if (cocktail.Size != size)
                {
                    return string.Format(OutputMessages.NotRecognizedItemName, size, itemName);
                }

                booth.UpdateCurrentBill(cocktail.Price * countOfOrderedPieces);

                return string.Format(OutputMessages.SuccessfullyOrdered, boothId, countOfOrderedPieces, itemName);
            }
            else
            {
                return string.Format(OutputMessages.NotRecognizedType, itemTypeName);
            }
        }
    }
}