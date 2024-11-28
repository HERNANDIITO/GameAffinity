

using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using Web_GameAffinity.Models;

namespace Web_GameAffinity.Assembler
{
    public class VideojuegoAssembler
    {
        public VideojuegoViewModel ConvertirENToViewModel(VideojuegoEN en)
        {
            VideojuegoViewModel videojuego = new VideojuegoViewModel();
            videojuego.Id = en.Id;
            videojuego.Nombre = en.Nombre;
            videojuego.Descripcion = en.Descripcion;
            videojuego.Genero = en.Genero;
            //poner en otro momento el resto de cosas
            return videojuego;

        }

        public IList<VideojuegoViewModel> ConvertirListaENtoViewModel(IList<VideojuegoEN> ens)
        {
            IList<VideojuegoViewModel> lista_videojuegos = new List<VideojuegoViewModel>();
            foreach ( VideojuegoEN en in ens)
            {
                lista_videojuegos.Add(ConvertirENToViewModel(en));
            }
            return lista_videojuegos;
        }
    }
}
