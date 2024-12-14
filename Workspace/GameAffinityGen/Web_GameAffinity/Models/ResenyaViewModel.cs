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
        public int IdVideojuego { get; set; }

        //public IList<> Interacciones

        //public float Valoracion { get; set; }
    }
}
