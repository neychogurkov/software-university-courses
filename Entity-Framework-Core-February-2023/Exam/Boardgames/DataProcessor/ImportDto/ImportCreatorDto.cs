namespace Boardgames.DataProcessor.ImportDto
{
    using System.ComponentModel.DataAnnotations;
    using System.Xml.Serialization;

    using Common;

    [XmlType("Creator")]
    public class ImportCreatorDto
    {
        [XmlElement("FirstName")]
        [Required]
        [MinLength(ValidationConstants.CreatorNameMinLength)]
        [MaxLength(ValidationConstants.CreatorNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [XmlElement("LastName")]
        [Required]
        [MinLength(ValidationConstants.CreatorNameMinLength)]
        [MaxLength(ValidationConstants.CreatorNameMaxLength)]
        public string LastName { get; set; } = null!;

        [XmlArray("Boardgames")]
        public ImportBoardgameDto[] Boardgames { get; set; }
    }
}
