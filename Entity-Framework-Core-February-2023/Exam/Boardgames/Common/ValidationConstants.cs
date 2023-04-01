namespace Boardgames.Common
{
    public static class ValidationConstants
    {
        public const int BoardgameNameMinLength = 10;
        public const int BoardgameNameMaxLength = 20;
        public const int BoardgameMinRating = 1;
        public const int BoardgameMaxRating = 10;
        public const int BoardgameMinYearPublished = 2018;
        public const int BoardgameMaxYearPublished = 2023;
        public const int BoardgameMinCategoryType = 0;
        public const int BoardgameMaxCategoryType = 4;

        public const int SellerNameMinLength = 5;
        public const int SellerNameMaxLength = 20;
        public const int SellerAddressMinLength = 2;
        public const int SellerAddressMaxLength = 30;
        public const string SellerWebsiteRegEx = @"www\.[\dA-Za-z-]+\.com";

        public const int CreatorNameMinLength = 2;
        public const int CreatorNameMaxLength = 7;
    }
}
