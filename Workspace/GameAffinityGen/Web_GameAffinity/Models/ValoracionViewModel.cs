using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using System.ComponentModel.DataAnnotations;

namespace Web_GameAffinity.Models
{
    public class ValoracionViewModel
    {
        /**
 *	Atributo nota
 */

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Nota", Description = "Nota", Name = "Nota")]
        [Required(ErrorMessage = "Introduce nota")]
        [DataType(DataType.Currency, ErrorMessage ="El precio debe ser numerico")]
        [Range(minimum: 0, maximum: 10, ErrorMessage ="La nota debe ser entre 0 y 10")]
        public int Nota { get; set; }

        [Display(Prompt = "Autor", Description = "Autor", Name = "Autor")]
        [Required(ErrorMessage = "La valoracion la debe hacer un autor")]
        public GameAffinityGen.ApplicationCore.EN.GameAffinity.RegistradoEN Autor_valoracion { get; set; }

        [Display(Prompt = "Videojuego", Description = "Videojuego", Name = "Videojuego")]
        [Required(ErrorMessage = "La valoracion debe ser de un juego")]
        public GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN Videojuego_valorado { get; set; }

    }
}
