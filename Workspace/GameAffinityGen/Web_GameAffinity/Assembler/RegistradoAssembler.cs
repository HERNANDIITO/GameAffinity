using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using Web_GameAffinity.Models;

namespace Web_GameAffinity.Assembler
{
    public class RegistradoAssembler
    {
        public PerfilViewModel ConvertirENToViewModel(RegistradoEN registrado)
        {
            PerfilViewModel config = new PerfilViewModel();

            config.id = registrado.Id;
            config.nombre = registrado.Nombre;
            config.email = registrado.Email;
            config.nick = registrado.Nick;
            config.password = registrado.Contrasenya;
            config.notificaciones = registrado.Notificaciones;
            config.imagen = registrado.Img;
            return config;
        }
    }
}
