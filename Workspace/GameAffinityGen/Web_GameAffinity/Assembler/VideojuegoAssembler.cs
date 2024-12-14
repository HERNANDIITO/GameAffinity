

using GameAffinityGen.ApplicationCore.EN.GameAffinity;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.FileIO;
using System.IO;
using Web_GameAffinity.Models;
using 

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
            videojuego.Imagen = ConvertToIFormFile(en.Imagen);
            videojuego.NotaMedia = en.Nota_media;
            videojuego.FechaLanzamiento = en.FechaDeLanzamiento;
            return videojuego;

        }

        public IFormFile ConvertToIFormFile(string filePath)
        {
            filePath = "./wwwroot/" + filePath;
            if (!File.Exists(filePath))
            {
                filePath = "wwwroot/Images/missing_img.jpg";
            }

            string contentType = GetContentType(filePath);

            var stream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            var fileName = Path.GetFileName(filePath);

            var formFile = new FormFile(stream, 0, stream.Length, "file", fileName)
            {
                Headers = new HeaderDictionary(),
                ContentType = contentType
            };

            return formFile;
        }

        private string GetContentType(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();

            return extension switch
            {
                ".jpg" or ".jpeg" => "image/jpeg",
                ".png" => "image/png",
                ".gif" => "image/gif",
                ".bmp" => "image/bmp",
                ".tiff" => "image/tiff",
                ".webp" => "image/webp",
                _ => "application/octet-stream"
            };
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
