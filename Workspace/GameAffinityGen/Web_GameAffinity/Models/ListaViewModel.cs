using System.ComponentModel.DataAnnotations;
using System.Security.Policy;
using System.Collections.Generic;

namespace Web_GameAffinity.Models
{
    public class ListaViewModel
    {
        //para generar id autogenerado
        //[ScaffoldColumn(false)]


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





    }
}
