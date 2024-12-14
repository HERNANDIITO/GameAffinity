

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
