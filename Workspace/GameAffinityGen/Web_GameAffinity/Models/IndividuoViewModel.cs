using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Web_GameAffinity.Models
{
    public class IndividuoViewModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(
            Prompt = "Especifica el nombre.", // texto para el input vacio
            Description = "Nombre", // texto para el alt
            Name = "Biografía" // nombre para el label
            )]
        [Required(ErrorMessage = "Es obligatorio indicar un nombre.")]
        [StringLength(maximumLength: 100, ErrorMessage = "La descripcion no puede superar 100 caracteres.")]
        public string Nombre { get; set; }

        [Display(
            Prompt = "Especifica el o los apellidos.", // texto para el input vacio
            Description = "Apellido o apellidos", // texto para el alt
            Name = "Apellido" // nombre para el label
            )]
        [Required(ErrorMessage = "Es obligatorio indicar al menos un apellido.")]
        [StringLength(maximumLength: 200, ErrorMessage = "La descripcion no puede superar 200 caracteres.")]
        public string Apellido { get; set; }

        [Display(
            Prompt = "Indica la fecha de nacimiento.", // texto para el input vacio
            Description = "Fecha de nacimiento", // texto para el alt
            Name = "Fecha de nacimiento" // nombre para el label
            )]
        public Nullable<DateTime> FechaNac { get; set; }

        public GameAffinityGen.ApplicationCore.EN.GameAffinity.PaisesEN Nacionalidad { get; set; }

        [Display(
            Prompt = "Especifica un rol.", // texto para el input vacio
            Description = "Rol", // texto para el alt
            Name = "Rol" // nombre para el label
            )]
        [Required(ErrorMessage = "Es obligatorio indicar un rol.")]
        public GameAffinityGen.ApplicationCore.Enumerated.GameAffinity.RolesEnum Rol { get; set; }

        [Display(
            Prompt = "Escribe una breve biografía.", // texto para el input vacio
            Description = "Biografía", // texto para el alt
            Name = "Biografía" // nombre para el label
            )]
        [Required(ErrorMessage = "Es obligatorio indicar una biografía.")]
        [StringLength(maximumLength: 1000, ErrorMessage = "La descripcion no puede superar 1000 caracteres.")]
        public string Biografia { get; set; }
        public string Imagen { get; set; }

    }
}
