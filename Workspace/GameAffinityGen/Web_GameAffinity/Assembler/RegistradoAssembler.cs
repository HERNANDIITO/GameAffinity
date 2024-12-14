using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using Web_GameAffinity.Models;

namespace Web_GameAffinity.Assembler
{
    public class RegistradoAssembler
    {
        public PerfilViewModel ConvertirENToViewModel(RegistradoEN en)
        {
            PerfilViewModel config = new PerfilViewModel();
            config.id = en.Id;
            config.nombre = en.Nombre;
            config.email = en.Email;
            config.nick = en.Nick;
            config.password = en.Contrasenya;
            config.notificaciones = en.Notificaciones;
            config.imagen = en.Img;
            return config;
        }
    }
}
