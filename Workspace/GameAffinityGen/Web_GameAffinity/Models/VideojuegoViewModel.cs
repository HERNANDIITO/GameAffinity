// Este modelo va a permitr mostrar unicamente lo que nos interesa en una pagina concreta
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
//// using nuestro
//using GameAffinityGen.ApplicationCore.CEN.GameAffinity;
//using GameAffinityGen.ApplicationCore.EN.GameAffinity;
//using GameAffinityGen.Infraestructure.Repository.GameAffinity;

namespace Web_GameAffinity.Models
{
    public class VideojuegoViewModel
    {
        // Declaramos la id del Model en el ViewModel
        [ScaffoldColumn(false)] // indicamos que no debe mostrarse en las vistas
        public int Id { get; set; } // he quitado set porque no le veo el sentido a cambiarlo

        [Display(
            Prompt = "Da nombre al videojuego", // texto para el input vacio
            Description = "Nombre del videojuego", // texto para el alt
            Name = "Nombre" // nombre para el label
            )]
        [Required(ErrorMessage = "Es obligatorio indicar un nombre.")]
        [StringLength(maximumLength: 200, ErrorMessage = "El nombre no puede superar 200 caracteres.")]
        public string Nombre { get; set; }

        // Declaracion de la descripcion
        // Display define unos atributos que nos ayudan a la hora de mostrar esta descripcion tanto si 
        // es de la BD o si es un formulario para introducirla
        [Display( 
            Prompt = "Describe el videojuego", // texto para el input vacio
            Description = "Descripción del videojuego", // texto para el alt
            Name = "Descripción" // nombre para el label
            )]
        [Required(ErrorMessage = "Es obligatorio indicar una descripcion.")]
        [StringLength(maximumLength:200, ErrorMessage = "La descripcion no puede superar 200 caracteres.")]
        public string Descripcion { get; set; }

        // Declaracion de la imagen
        // Display define unos atributos que nos ayudan a la hora de mostrar esta imagen tanto si 
        // es de la BD o si es un formulario para introducirla
        [Display(
            Prompt = "Pega aquí la ruta de la portada del videojuego.",
            Description = "Portada del videojuego.",
            Name = "Imagen")]
        [Required(ErrorMessage = "Es obligatorio indicar una imagen.")]
        public IFormFile Imagen { get; set; }

        // Declaracion de la descripcion
        [Display(
            Prompt = "Nota media del videojuego", // texto para el input vacio
            Description = "Nota media del videojuego", // texto para el alt
            Name = "Nota media" // nombre para el label
            )]
        // no es obligatorio poner nota media, se debe calcular automaticamente al poner valoraciones
        // no se deberia ni poner aqui
        //[Required(ErrorMessage = "Es obligatorio indicar una Nota media.")]
        public float NotaMedia { get; set; }

        [Display(
            Prompt = "Fecha de lanzamiento del videojuego", // texto para el input vacio
            Description = "Fecha de lanzamiento del videojuego", // texto para el alt
            Name = "Fecha de lanzamiento" // nombre para el label
            )]
        public DateTime? FechaLanzamiento { get; set; }

        [Display(
            Prompt = "Género del videojuego", // texto para el input vacio
            Description = "Género del videojuego", // texto para el alt
            Name = "Género" // nombre para el label
            )]
        [Required(ErrorMessage = "Es obligatorio indicar un genero.")]
        public GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.GenerosEnum Genero { get; set; }

        public bool showResenyaModal { get; set; } = false;


    }

    public class FResenyaViewModel
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

    public class VideojuegoDetailsViewModel
    {
        public VideojuegoViewModel Videojuego { get; set; }
        public IList<ResenyaViewModel> Resenyas { get; set; }
        public IList<ValoracionEN> Valoraciones {get; set; }
    }
}
