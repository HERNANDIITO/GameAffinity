﻿using GameAffinityGen.ApplicationCore.EN.GameAffinity;
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

        // Declaracion de la imagen
        // Display define unos atributos que nos ayudan a la hora de mostrar esta imagen tanto si 
        // es de la BD o si es un formulario para introducirla
        [Display(
            Prompt = "Pega aquí la ruta de la portada del videojuego.",
            Description = "Portada del videojuego.",
            Name = "Imagen")]
        [Required(ErrorMessage = "Es obligatorio indicar una imagen.")]
        public IFormFile Imagen { get; set; }

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

        public string Nombre { get; set; }

        [Display(Prompt = "Descripcion de empresa", Description = "Descripcion de empresa", Name = "descripcion")]
        [Required(ErrorMessage = "La descripcion es obligatorio")]

        public string Descripcion { get; set; }

        [Display(Prompt = "Nota de empresa", Description = "Nota de empresa", Name = "nota")]
        [Required(ErrorMessage = "La nota es obligatorio")]
        [Range(minimum: 0, maximum: 10, ErrorMessage = "La nota debe ser entre 0 y 10")]

        public float Nota { get; set; }

        [Display(Prompt = "Videojuegos de la empresa", Description = "Videojuegos de la empresa", Name = "videojuegos")]
        [Required(ErrorMessage = "Los videojuegos son obligatorios")]

        public System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.VideojuegoEN> Videojuegos { get; set; }
        public System.Collections.Generic.IList<GameAffinityGen.ApplicationCore.EN.GameAffinity.IndividuoEN> Individuos { get; set; }
        // Declaracion de la imagen
        // Display define unos atributos que nos ayudan a la hora de mostrar esta imagen tanto si 
        // es de la BD o si es un formulario para introducirla
        [Display(
            Prompt = "Pega aquí la ruta de la portada del videojuego.",
            Description = "Icono de la empresa.",
            Name = "Imagen")]
        [Required(ErrorMessage = "Es obligatorio indicar una imagen.")]
        public IFormFile Imagen { get; set; }
    }
}
