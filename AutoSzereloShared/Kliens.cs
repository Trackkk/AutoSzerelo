using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AutoSzereloShared
{
    public class Kliens
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid KliensId { get; set; }

        [Required]
        [RegularExpression(@"\S")]
        public string KliensNev {get; set; }

        [Required]
        [RegularExpression(@"\S")]
        public string Lakcim { get; set; }

        [Required]
        [EmailAddress]
        [RegularExpression(@"\S")]
        public string Email { get; set; }
    }
}
