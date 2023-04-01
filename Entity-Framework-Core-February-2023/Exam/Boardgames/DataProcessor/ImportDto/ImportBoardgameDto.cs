namespace Boardgames.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    using Common;

    [XmlType("Boardgame")]
    public class ImportBoardgameDto
    {
        [XmlElement("Name")]
        [Required]
        [MinLength(ValidationConstants.BoardgameNameMinLength)]
        [MaxLength(ValidationConstants.BoardgameNameMaxLength)]
        public string Name { get; set; } = null!;

        [XmlElement("Rating")]
        [Range(ValidationConstants.BoardgameMinRating, ValidationConstants.BoardgameMaxRating)]
        public double Rating { get; set; }

        [XmlElement("YearPublished")]
        [Range(ValidationConstants.BoardgameMinYearPublished, ValidationConstants.BoardgameMaxYearPublished)]
        public int YearPublished { get; set; }

        [XmlElement("CategoryType")]
        [Range(ValidationConstants.BoardgameMinCategoryType, ValidationConstants.BoardgameMaxCategoryType)]
        public int CategoryType { get; set; }

        [XmlElement("Mechanics")]
        [Required]
        public string Mechanics { get; set; } = null!;
    }
}
