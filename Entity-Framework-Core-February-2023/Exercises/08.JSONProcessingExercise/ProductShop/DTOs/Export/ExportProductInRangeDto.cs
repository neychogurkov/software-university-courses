namespace ProductShop.DTOs.Export
{
    using Newtonsoft.Json;

    public class ExportProductInRangeDto
    {
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        [JsonProperty("price")]
        public decimal Price { get; set; }

        [JsonProperty("seller")]
        public string SellerName { get; set; } = null!;
    }
}
