using NHibernate.Linq.Expressions;
using System.Net;
using System.Net.Mail;

namespace Web_GameAffinity.Servicios
{
    public interface IServicioEmail
    {
        Task SendEmail(string emailReceptor, string tema, string cuerpo);
    }



    public class ServicioEmail : IServicioEmail
    {
        private readonly IConfiguration _configuration;
        public ServicioEmail(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task SendEmail(string emailReceptor, string tema, string cuerpo)
        {
            var emailEmisor = _configuration.GetValue<string>("CONFIGURACIONES_EMAIL:EMAIL");
            var password = _configuration.GetValue<string>("CONFIGURACIONES_EMAIL:PASSWORD");
            var host = _configuration.GetValue<string>("CONFIGURACIONES_EMAIL:HOST");
            var puerto = _configuration.GetValue<int>("CONFIGURACIONES_EMAIL:PUERTO");

            var smtpClient = new SmtpClient(host, puerto)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(emailEmisor, password)
            };

            // Leer el contenido del archivo CSS
            var cssPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "css", "EmailStyle.css");
            var cssContent = File.ReadAllText(cssPath);

            // Incrustar el CSS en el cuerpo del mensaje HTML
            var htmlBody = $@"
            <!DOCTYPE html>
            <html lang='es'>
            <head>
                <meta charset='UTF-8'>
                <meta name='viewport' content='width=device-width, initial-scale=1.0'>
                <style>
                    {cssContent}
                </style>
                <title>{tema}</title>
            </head>
            <body>
                {cuerpo}
            </body>
            </html>";

            var mensaje = new MailMessage(emailEmisor, emailReceptor, tema, htmlBody)
            {
                IsBodyHtml = true // Si el cuerpo del correo es HTML
            };

            try
            {
                await smtpClient.SendMailAsync(mensaje);
            }
            catch (SmtpException ex)
            {
                // Manejar la excepción de SMTP
                throw new Exception("Error al enviar el correo: " + ex.Message);
            }
        }
    }
}
