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

            var smtpClient = new SmtpClient(host, puerto);
            smtpClient.EnableSsl = true;
            smtpClient.UseDefaultCredentials = true;

            smtpClient.Credentials = new NetworkCredential(emailEmisor, password);
            var mensaje = new MailMessage(emailEmisor!, emailReceptor, tema, cuerpo);
            await smtpClient.SendMailAsync(mensaje);
        }
    }
}
