namespace Boardgames.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    using Boardgames.Common;

    public class Creator
    {
        public Creator()
        {
            this.Boardgames = new HashSet<Boardgame>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(ValidationConstants.CreatorNameMaxLength)]
        public string FirstName { get; set; } = null!;

        [Required]
        [MaxLength(ValidationConstants.CreatorNameMaxLength)]
        public string LastName { get; set; } = null!;

        public virtual ICollection<Boardgame> Boardgames { get; set; } = null!;
    }
}
