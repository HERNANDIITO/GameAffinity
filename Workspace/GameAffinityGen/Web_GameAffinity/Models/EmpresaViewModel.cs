using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using System.ComponentModel.DataAnnotations;

namespace Web_GameAffinity.Models
{
    public class EmpresaViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Nombre de empresa", Description = "Nombre de empresa", Name = "nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio")]
        public string Nombre { get; set; }

        [Display(Prompt = "Descripcion de empresa", Description = "Descripcion de empresa", Name = "descripcion")]
        [Required(ErrorMessage = "La descripcion es obligatorio")]
        public string Descripcion { get; set; }

        [Display(Prompt = "Nota de empresa", Description = "Nota de empresa", Name = "nota")]
        [Required(ErrorMessage = "La nota es obligatorio")]
        public float Nota { get; set; }

        //[Display(Prompt = "Videojuegos hechos por la empresa.", Description = "Videojuegos de la empresa", Name = "Videojuegos")]
        //[Required(ErrorMessage = "Los videojuegos son obligatorios")]
        //public IList<VideojuegoEN> Videojuegos { get; set; }

        //[Display(Prompt = "Personas relacionadas con esta empresa.", Description = "Personas de la empresa", Name = "Individuos")]
        //[Required(ErrorMessage = "Añade al menos una persona")]
        //public IList<IndividuoEN> Individuos { get; set; }
    }

    // Codigo del silva
    public class DetailsEmpresaViewModel
    {

        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(Prompt = "Nombre de empresa", Description = "Nombre de empresa", Name = "nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio")]

        public required string nombre { get; set; }

        [Display(Prompt = "Descripcion de empresa", Description = "Descripcion de empresa", Name = "descripcion")]
        [Required(ErrorMessage = "La descripcion es obligatorio")]

        public required string descripcion { get; set; }

        [Display(Prompt = "Nota de empresa", Description = "Nota de empresa", Name = "nota")]
        [Required(ErrorMessage = "La nota es obligatorio")]

        public required float nota { get; set; }

        [Display(Prompt = "Videojuegos de la empresa", Description = "Videojuegos de la empresa", Name = "videojuegos")]
        [Required(ErrorMessage = "Los videojuegos son obligatorios")]

        public required IList<VideojuegoEN> videojuegos { get; set; }
    }
}
