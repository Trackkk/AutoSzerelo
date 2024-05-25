using System.ComponentModel.DataAnnotations;

namespace AutoSzereloShared
{
    public class Kliens
    {
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
