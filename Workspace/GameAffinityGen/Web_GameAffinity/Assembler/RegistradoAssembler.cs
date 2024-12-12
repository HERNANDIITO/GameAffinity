using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using Web_GameAffinity.Models;

namespace Web_GameAffinity.Assembler
{
    public class RegistradoAssembler
    {
        public ConfiguracionPerfilViewModel ConvertirENToViewModel(RegistradoEN registrado)
        {
            ConfiguracionPerfilViewModel config = new ConfiguracionPerfilViewModel();

            config.id = registrado.Id;
            config.nombre = registrado.Nombre;
            config.email = registrado.Email;
            config.nick = registrado.Nick;
            config.password = registrado.Contrasenya;
            config.notificaciones = registrado.Notificaciones;

            return config;
        }
    }
}
