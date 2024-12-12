using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Web_GameAffinity.Models
{
    public class LoginRegistradoViewModel
    {
        [Display(Prompt = "Email de usuario", Description = "Email de Usuario", Name = "email")]
        [Required(ErrorMessage = "El email es obligatorio")]

        public required string email { get; set; }

        [Display(Prompt = "Contraseña", Description = "Contraseña", Name = "contraseña")]
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        public required string password { get; set; }

        public bool ShowErrorModal { get; set; } = false;
    }





    public class RegistroRegistradoViewModel
    {
        [Display(Prompt = "Nombre de usuario", Description = "Nombre de Usuario", Name = "nombre")]
        [Required(ErrorMessage = "El nombre es obligatorio")]

        public required string nombre { get; set; }

        [Display(Prompt = "Email de usuario", Description = "Email de Usuario", Name = "email")]
        [Required(ErrorMessage = "El email es obligatorio")]

        public required string email { get; set; }

        [Display(Prompt = "Nick de usuario", Description = "Nick de Usuario", Name = "nick")]
        [Required(ErrorMessage = "El nick es obligatorio")]

        public required string nick { get; set; }

        [Display(Prompt = "Contraseña", Description = "Contraseña", Name = "contraseña")]
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        public required string password { get; set; }

        public bool ShowErrorModal { get; set; } = false;
    }




    public class ConfiguracionPerfilViewModel
    {
        [ScaffoldColumn(false)]
        public int id { get; set; }

        [Display(Prompt = "Nombre del User", Description = "Nombre del usuario", Name = "Nombre")]
        [Required(ErrorMessage = "Este campo no puede quedar vacío")]
        [StringLength(maximumLength: 20, ErrorMessage = "El nombre no puede tener más de 20 caracteres")]
        public string nombre { get; set; }

        [Display(Prompt = "Email del User", Description = "Email del usuario", Name = "Email")]
        [Required(ErrorMessage = "Este campo no puede quedar vacío")]
        public string email { get; set; }

        [Display(Prompt = "Nick del User", Description = "Nick del usuario", Name = "Nick")]
        [Required(ErrorMessage = "Este campo no puede quedar vacío")]
        [StringLength(maximumLength: 20, ErrorMessage = "El Nick no puede tener más de 20 caracteres")]
        public string nick { get; set; }

        [Display(Prompt = "Contraseña", Description = "Contraseña del usuario", Name = "Password")]
        [Required(ErrorMessage = "Este campo no puede quedar vacío")]
        public string password { get; set; }

        [Display(Prompt = "Mentoria", Description = "Mentoria del usuario", Name = "Mentoria")]
        [Required(ErrorMessage = "Este campo no puede quedar vacío")]
        public bool mentor { get; set; }

        [Display(Prompt = "Notificaciones", Description = "Notificaciones del usuario", Name = "Notificaciones")]
        [Required(ErrorMessage = "Este campo no puede quedar vacío")]
        public bool notificaciones { get; set; }

        public bool ShowSaveModal { get; set; } = false;
    }
}