namespace CarDealer.DTOs.Export
{
    public class ExportCarDto
    {
        public int Id { get; set; }

        public string Make { get; set; } = null!;

        public string Model { get; set; } = null!;

        public long TraveledDistance { get; set; }
    }
}
