using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Web_GameAffinity.Models
{
    public class LoginRegistradoViewModel
    {
        [Display(Prompt = "Email de usuario", Description = "Email User", Name = "emailUser")]
        [Required(ErrorMessage = "El email es obligatorio")]

        public required string email { get; set; }

        [Display(Prompt = "Contraseña", Description = "Contraseña", Name = "password")]
        [Required(ErrorMessage = "La contraseña es obligatoria")]
        [DataType(DataType.Password)]
        public required string password { get; set; }
    }
}
