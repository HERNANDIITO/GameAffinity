using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using System.Collections.Generic;

namespace Web_GameAffinity.Models
{
    public class ListaViewModel
    {
        //para generar id autogenerado
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Nombre de la lista", Description = "Nombre de la lista", Name = "Nombre")]
        [Required(ErrorMessage = "Debe indicar un nombre para la lista")]
        [StringLength(maximumLength: 50, ErrorMessage = "El nombre no puede tener mas de 50 caracteres")]
        public string Nombre { get; set; } //el required porque no acepta valores null puede que haya que ponerlo

        [Display(Prompt ="Introduce descripcion de la lista", Description ="Descripcion de la lista", Name ="Descripcion")]
        [Required(ErrorMessage ="Debe indicar una descripcion para la lista")]
        [StringLength(maximumLength:200, ErrorMessage ="La descripcion no puede tener mas de 200 caracteres")]
        public string Descripcion {  get; set; } //el required porque no acepta valores null puede que haya que ponerlo

        public Boolean Por_defecto { get; set; }

        public  GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN Autor_lista { get; set; }

        public  System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> Videojuegos { get; set; }

        // Declaracion de la imagen
        // Display define unos atributos que nos ayudan a la hora de mostrar esta imagen tanto si 
        // es de la BD o si es un formulario para introducirla
        [Display(
            Prompt = "Pega aquí la ruta de la portada de la lista.",
            Description = "Portada de la lista.",
            Name = "Imagen")]
        [Required(ErrorMessage = "Es obligatorio indicar una imagen.")]
        public IFormFile Imagen { get; set; }



        // Todos los videojuegos de la base de datos (para el modal)
        public IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> TodosLosVideojuegos { get; set; }


    }
}
