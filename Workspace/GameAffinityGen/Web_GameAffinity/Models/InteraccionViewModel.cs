using System.ComponentModel.DataAnnotations;

namespace Web_GameAffinity.Models
{
    public class InteraccionViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display( Name ="Like" )]
        public bool Liked { get; set; }

        [Display(Name = "Disike")]
        public bool Disliked { get; set; }

        [ScaffoldColumn(false)]
        public int IdAutor { get; set; }

        [ScaffoldColumn(false)]
        public int IdResenya { get; set; }
    }
}
