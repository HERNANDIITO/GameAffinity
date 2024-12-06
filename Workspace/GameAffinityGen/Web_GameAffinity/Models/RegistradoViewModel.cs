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
}