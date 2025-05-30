﻿using GameAffinityGen.ApplicationCore.CEN.GameAffinity;
using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using GameAffinityGen.Infraestructure.Repository.GameAffinity;
using Microsoft.AspNetCore.Mvc;
using Web_GameAffinity.Servicios;

namespace Web_GameAffinity.Controllers
{
    [Route("Email")]
    public class EmailController : BasicController
    {

        private readonly IServicioEmail servicioemail;
        private readonly IConfiguration configuration;
        public EmailController(IServicioEmail servicioemail, IConfiguration configuration)
        {
            this.servicioemail = servicioemail;
            this.configuration = configuration;
        }

        [HttpPost]
        public async Task<ActionResult> Enviar(string emailReceptor, string tema, string cuerpo)
        {
            await servicioemail.SendEmail(emailReceptor, tema, cuerpo);
            return Ok();
        }

        [HttpPost("restablecer-contrasena")]
        public async Task<ActionResult> RestablecerContrasena([FromForm] string emailReceptor)
        {
            // Validar el email del usuario en la base de datos (simulado)
            SessionInitialize();
            RegistradoCEN registradoCEN = new RegistradoCEN(new RegistradoRepository(session));
            RegistradoEN registradoEN = registradoCEN.GetByEmail(emailReceptor);
            if(registradoEN == null)
            {
                TempData["ErrorMessage"] = "El correo proporcionado no está registrado.";
                return RedirectToAction("Login", "Registrado");
            }
            // Generar un token único (puedes usar un JWT o un GUID simple)
            var token = Guid.NewGuid().ToString();

            HttpContext.Session.SetString("ResetToken", token);
            HttpContext.Session.SetString("ResetEmail", emailReceptor);

            // Crear el enlace con el token
            var enlace = $"https://localhost:44338/Registrado/CambiarContrasena";

            // Mensaje del email
            var tema = "Restablecer tu contraseña";
            var cuerpo = $@"
                <div class='container-email'>
                    <div class='header-email'>
                        <h1>Restablecer tu contraseña</h1>
                    </div>
                    <div class='content-email'>
                        <p>Haz clic en el siguiente botón para restablecer tu contraseña:</p>
                        <a href='{enlace}' class='button-email'>Restablecer Contraseña</a>
                    </div>
                    <div class='footer-email'>
                        <p>Si no solicitaste este cambio, puedes ignorar este correo.</p>
                        <p>Gracias por confiar en GameAffinity</p>
                    </div>
                </div>";

            // Enviar el email
            await servicioemail.SendEmail(emailReceptor, tema, cuerpo);

            // Devuelve una respuesta de éxito
            TempData["SuccessMessage"] = "Hemos enviado un enlace a tu correo electrónico.";
            return RedirectToAction("Login", "Registrado");
        }
    }
}
