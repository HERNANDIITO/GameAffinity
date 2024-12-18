using System.ComponentModel.DataAnnotations;

namespace Web_GameAffinity.Models
{
    public class ResenyaViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(
            Prompt = "Añade un titulo a tu reseña.", // texto para el input vacio
            Description = "Titulo", // texto para el alt
            Name = "Reseña" // nombre para el label
            )]
        public string Titulo { get; set; }

        [Display(
            Prompt = "Escribe tu reseña.", // texto para el input vacio
            Description = "Titulo", // texto para el alt
            Name = "Titulo" // nombre para el label
            )]
        public string Texto { get; set; }

        [Display(
            Description = "Likes de la reseña", // texto para el alt
            Name = "Likes" // nombre para el label
        )]
        public int Likes_contador { get; set; }

        [Display(
        Description = "Dislikes de la reseña", // texto para el alt
        Name = "Dislikes" // nombre para el label
        )]
        public int Dislikes_contador { get; set; }

        [ScaffoldColumn(false)]
        public int IdAutor { get; set; }

        [Display(
            Description = "Nombre de autor de la reseña", // texto para el alt
            Name = "Autor" // nombre para el label
            )]
        public string NombreAutor { get; set; }

        [ScaffoldColumn(false)]
        public int VideojuegoId { get; set; }

        public int Valoracion { get; set; }
        
        public IList<InteraccionViewModel> Interacciones {  get; set; }

        public string NombreVideojuego { get; set; }

        public string imageVideojuego { get; set; }
        //public IList<> Interacciones

        //public float Valoracion { get; set; }
    }

    public class PostResenyaViewModel
    {
        [ScaffoldColumn(false)]

        [Display(
            Prompt = "Título de la reseña",
            Description = "Título de la reseña",
            Name = "Título"
        )]
        [Required(ErrorMessage = "Es obligatorio indicar un título.")]
        [StringLength(maximumLength: 100, ErrorMessage = "El título no puede superar 100 caracteres.")]
        public string Titulo { get; set; }

        [Display(
            Prompt = "Texto de la reseña",
            Description = "Texto de la reseña",
            Name = "Texto"
        )]
        [Required(ErrorMessage = "Es obligatorio indicar un texto.")]
        [StringLength(maximumLength: 1000, ErrorMessage = "El texto no puede superar 1000 caracteres.")]
        public string Texto { get; set; }

        [Display(
            Prompt = "Valoración (0-10)",
            Description = "Valoración del videojuego",
            Name = "Valoración"
        )]
        [Range(0, 10, ErrorMessage = "La valoración debe estar entre 0 y 10.")]
        public int Valoracion { get; set; }

        [ScaffoldColumn(false)]
        public int VideojuegoId { get; set; }
    }
}
