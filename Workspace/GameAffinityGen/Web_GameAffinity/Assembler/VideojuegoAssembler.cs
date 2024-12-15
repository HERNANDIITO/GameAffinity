

using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using Web_GameAffinity.Models;

namespace Web_GameAffinity.Assembler
{
    public class VideojuegoAssembler
    {
        public VideojuegoViewModel ConvertirENToViewModel(VideojuegoEN en)
        {
            if (en == null)
            {
                throw new ArgumentNullException(nameof(en), "El objeto VideojuegoEN no puede ser null.");
            }

            VideojuegoViewModel videojuego = new VideojuegoViewModel
            {
                Id = en.Id,
                Nombre = en.Nombre,
                Descripcion = en.Descripcion,
                Genero = en.Genero,
                Imagen = ConvertToIFormFile(en.Imagen),
                NotaMedia = en.Nota_media,
                FechaLanzamiento = en.FechaDeLanzamiento
            };

            VideojuegoViewModel videojuego = new VideojuegoViewModel();
            videojuego.Id = en.Id;
            videojuego.Nombre = en.Nombre;
            videojuego.Descripcion = en.Descripcion;
            videojuego.Genero = en.Genero;
            videojuego.Imagen = FileHelper.ConvertToIFormFile(en.Imagen);
            videojuego.NotaMedia = en.Nota_media;
            videojuego.FechaLanzamiento = en.FechaDeLanzamiento;
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
